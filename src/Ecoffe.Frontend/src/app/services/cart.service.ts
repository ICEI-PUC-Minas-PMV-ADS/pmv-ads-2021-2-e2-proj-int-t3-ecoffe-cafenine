import { Carrinho } from './../models/carrinho.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  isOpened: boolean = false;

  isOpenedChange: Subject <boolean> = new Subject<boolean>();

  baseUrl = "https://localhost:44362/api/Carrinho";

  constructor(private http: HttpClient) { 
      this.isOpenedChange.subscribe((value) => {
        this.isOpened = value
    });
  }

  toggleCartSidenav(){
    this.isOpenedChange.next(!this.isOpened);
  }

  getCartByUserId(userId: number): Observable<Carrinho>{
    return this.http.get<Carrinho>(this.baseUrl + "/usuario/" + userId);
  }

  removeProductFromCart(productCartId: number): Observable<Carrinho>{
    return this.http.get<Carrinho>(this.baseUrl + "/remove/" + productCartId);
  }

}
