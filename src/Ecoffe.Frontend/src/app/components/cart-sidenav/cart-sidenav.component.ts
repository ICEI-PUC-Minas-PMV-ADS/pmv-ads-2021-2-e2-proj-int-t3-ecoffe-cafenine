import { Router } from '@angular/router';
import { CartService } from './../../services/cart.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart-sidenav',
  templateUrl: './cart-sidenav.component.html',
  styleUrls: ['./cart-sidenav.component.css']
})
export class CartSidenavComponent implements OnInit {
  cart: any;
  userId: any;

  constructor(private cartService: CartService, private router: Router) {}

  get isCartSidenavOpened(): boolean {
    return this.cartService.isOpened;
  }

  toggleCartSidenav(){
    this.cartService.toggleCartSidenav();
  }

  ngOnInit(): void {

    console.log("iniciando...");
    
    this.userId = localStorage.getItem("usuarioId");

    if(!this.userId || this.userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    this.loadCart();
  }

  loadCart(){
    console.log("carregando carrinho...");
    this.cartService.getCartByUserId(this.userId).subscribe((data) => { 
      this.cart = data;
      console.log(data);
    });
  }



}
