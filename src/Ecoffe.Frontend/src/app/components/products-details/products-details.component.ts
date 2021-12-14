import { Produto } from './../../models/produto.model';
import { ProductsService } from './../../services/products.service';
import { CardsService } from './../../services/cards.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products-details',
  templateUrl: './products-details.component.html',
  styleUrls: ['./products-details.component.css']
})

export class ProductsDetailsComponent implements OnInit {
     
  product: any;

  constructor(private productService:ProductsService) { }

  public getById(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    });
  }

  getById2(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  getById3(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  getById4(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  getById5(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  getById6(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  ngOnInit(): void {
    this.getById(8);
    this.getById2(12);
    this.getById3(14);
    this.getById4(13);
    this.getById5(9);
    this.getById6(10);
  }
  

  
}
