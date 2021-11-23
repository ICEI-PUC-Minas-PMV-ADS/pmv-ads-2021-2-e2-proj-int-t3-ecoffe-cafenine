import { CartService } from './../../services/cart.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart-sidenav',
  templateUrl: './cart-sidenav.component.html',
  styleUrls: ['./cart-sidenav.component.css']
})
export class CartSidenavComponent implements OnInit {

  constructor(private cartService: CartService) {}

  get isCartSidenavOpened(): boolean {
    return this.cartService.isOpened;
  }

  toggleCartSidenav(){
    this.cartService.toggleCartSidenav();
  }

  ngOnInit(): void {
  }




}
