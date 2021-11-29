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

  getById(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    });
  }

  ngOnInit(): void {
    this.getById(8);
  }
  

  
}
