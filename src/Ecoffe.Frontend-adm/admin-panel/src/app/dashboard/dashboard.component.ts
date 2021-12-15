import { Produto } from './../models/produto.model';
import { productsService } from './../services/products.service';
import { SnackbarService } from './../services/snackbar.service';
import { ConfirmDialogService } from './../services/confirm-dialog.service';
import { Component, OnInit, NgModule } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  product: any;
  products: Produto[] 
  
  constructor(private productsService: productsService,
    private route: ActivatedRoute,
    private confirmDialogService: ConfirmDialogService, 
    private snackbarService: SnackbarService,
    private matDialog: MatDialog
   ) {}
   
   ngOnInit(): void {
     this.loadProducts();
   }
   
  loadProducts(){
    this.productsService.getAll().subscribe((data) => {
      this.products = data; 
    })
  }

  deleteConfirm(id: number){
    this.confirmDialogService.openConfirmDialog("Tem certeza que deseja deletar este Produto?").afterClosed().subscribe(confirm => {
      if(confirm)
        this.delete(id);  
    })
  }

  delete(id: number){
    this.productsService.deleteById(id).subscribe(() =>{
      this.snackbarService.showMessage("Produto deletado com sucesso!");
      this.loadProducts();
    });
  }
  openProductNewModal(id: number, tela: number){
    this.productsService.openProductNewModal(id,tela).afterClosed().subscribe(() =>{
      this.loadProducts();
    });
  }
  
}
