import { PurchaseService } from '../../services/purchase.service';
import { Compra, StatusCompraLabel, FormaPagamentoLabel } from './../../models/compra.model';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchase-details',
  templateUrl: './purchase-details.component.html',
  styleUrls: ['./purchase-details.component.css']
})
export class PurchaseDetailsComponent implements OnInit {

  userId: any;

  compraId: any;

  compra: Compra = {} as Compra;

  statusCompraLabel = StatusCompraLabel;
  formaPagamentoLabel = FormaPagamentoLabel;

  constructor(private router: Router, private purchaseService: PurchaseService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("usuarioId");

    if(!this.userId || this.userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    if(this.compraId)
      this.loadPurchase(this.compraId);
    else
      this.loadPurchase();
  }

  loadPurchase(compraId?: any){
    if(compraId){
      this.purchaseService.getByPurchaseId(compraId).subscribe((data) => {
        this.compra = data;
      });
    }
    else{
      this.purchaseService.getLatestByUserId(this.userId).subscribe((data) => { 
        this.compra = data;
      });
    }
  }

}
