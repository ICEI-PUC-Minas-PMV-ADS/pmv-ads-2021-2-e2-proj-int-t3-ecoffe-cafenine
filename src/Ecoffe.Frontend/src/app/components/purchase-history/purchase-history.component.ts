import { PurchaseService } from '../../services/purchase.service';
import { Router } from '@angular/router';
import { Compra, StatusCompraLabel, FormaPagamentoLabel } from './../../models/compra.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchase-history',
  templateUrl: './purchase-history.component.html',
  styleUrls: ['./purchase-history.component.css']
})
export class PurchaseHistoryComponent implements OnInit {

  userId: any;
  compras: Compra[] = [];

  formaPagamentoLabel = FormaPagamentoLabel;
  statusCompraLabel = StatusCompraLabel;

  constructor(private router: Router, private purchaseService: PurchaseService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("usuarioId");

    if(!this.userId || this.userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    this.loadPurchases();
  }

  loadPurchases(){
    this.purchaseService.getListByUserId(this.userId).subscribe((data) => {
      this.compras = data;
    });
  }

  openPurchaseDetailsModal(compraId: any){
    this.purchaseService.openPurchaseDetailsModal(compraId).afterClosed().subscribe(() =>{
      
    });
  }

}
