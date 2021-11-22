import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cart-sidenav',
  templateUrl: './cart-sidenav.component.html',
  styleUrls: ['./cart-sidenav.component.css']
})
export class CartSidenavComponent implements OnInit {

  opened = false;


  constructor() { }

  ngOnInit(): void {
  }

}
