import { SnackbarService } from './../../services/snackbar.service';
import { CartService } from './../../services/cart.service';
import { Router } from '@angular/router';
import { Carrinho } from './../../models/carrinho.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchase-finish',
  templateUrl: './purchase-finish.component.html',
  styleUrls: ['./purchase-finish.component.css']
})
export class PurchaseFinishComponent implements OnInit {

  cart: Carrinho = {
    id: 0,
    produtos: []
  };
  userId: any;
  totalValue = 0;

  constructor(private router: Router, private cartService: CartService, private snackbarService: SnackbarService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("usuarioId");

    if(!this.userId || this.userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    this.loadCart();
  }

  loadCart(){
    this.cartService.getCartByUserId(this.userId).subscribe((data) => { 
      this.cart = data;
      this.getTotalValue();
    });
  }

  getTotalValue(){
    this.totalValue = 0;

    this.cart.produtos.forEach(produto => {
      this.totalValue += produto.valorTotal;
    })
  }

  removeProductFromCart(productCartId: number){
    this.cartService.removeProductFromCart(productCartId).subscribe((data) => {
      this.loadCart();
      this.snackbarService.showMessage("Produto removido com sucesso!");
    })
  }

  updateProductCart(productCart: any){
    this.cartService.update(productCart).subscribe((data) => {
      this.loadCart(); //todo mapear retorno do data
    })
  }

}
