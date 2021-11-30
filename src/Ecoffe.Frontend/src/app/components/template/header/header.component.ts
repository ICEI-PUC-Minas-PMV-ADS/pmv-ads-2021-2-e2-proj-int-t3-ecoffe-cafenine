import { CartService } from './../../../services/cart.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  isLogged: any;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
     let userId = localStorage.getItem("usuarioId");
     
    if(!userId || userId == "")
      this.isLogged = false;
    else
      this.isLogged = true;
  }

  toggleCartSidenav(){
    this.cartService.toggleCartSidenav();
  }

}
