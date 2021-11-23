import { Injectable } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  isOpened: boolean = false;

  isOpenedChange: Subject <boolean> = new Subject<boolean>();

  constructor() { 
      this.isOpenedChange.subscribe((value) => {
        this.isOpened = value
    });
  }
  
  toggleCartSidenav(){
    this.isOpenedChange.next(!this.isOpened);
  }
}
