import { SnackbarService } from './../../services/snackbar.service';
import { Carrinho } from './../../models/carrinho.model';
import { Router } from '@angular/router';
import { CartService } from './../../services/cart.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart-sidenav',
  templateUrl: './cart-sidenav.component.html',
  styleUrls: ['./cart-sidenav.component.css']
})
export class CartSidenavComponent implements OnInit {
  cart: Carrinho = {
    id: 0,
    produtos: []
  };
  userId: any;

  constructor(private cartService: CartService, private router: Router, private snackbarService: SnackbarService) {}

  get isCartSidenavOpened(): boolean {
    return this.cartService.isOpened;
  }

  toggleCartSidenav(){
    this.loadCart();
    this.cartService.toggleCartSidenav();
  }

  ngOnInit(): void {    
    this.userId = localStorage.getItem("usuarioId");

    if(!this.userId || this.userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    if(this.cartService.isOpened == true)
      this.cartService.toggleCartSidenav();

    this.loadCart();
  }

  loadCart(){
    this.cartService.getCartByUserId(this.userId).subscribe((data) => { 
      this.cart = data;
    });
  }

  removeProductFromCart(productCartId: number){
    this.cartService.removeProductFromCart(productCartId).subscribe((data) => {
      this.loadCart();
      this.snackbarService.showMessage("Produto removido com sucesso!");
    })
  }

  updateProductCart(productCart: any){
    this.cartService.update(productCart).subscribe(() => {
      
    })
  }

}
