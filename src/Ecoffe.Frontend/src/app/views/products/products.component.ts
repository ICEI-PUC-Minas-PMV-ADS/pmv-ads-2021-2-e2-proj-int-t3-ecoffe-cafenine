import { Component, OnInit } from '@angular/core';
import { ProductsService } from './../../services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  product: any;
  y: any;
  ultimos: any;

  constructor(private productService:ProductsService) { }

  getById(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    });
  }
  busca(){
    for(let x = 0; x < 16; x++){
      if(x = 15)
        this.getById(x);
    }
  }

  ngOnInit(): void {
    this.busca();
  }

}
