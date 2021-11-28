import { Produto } from './../../models/produto.model';
import { ProductsService } from './../../services/products.service';
import { CardsService } from './../../services/cards.service';
import { Component, OnInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-products-details',
  templateUrl: './products-details.component.html',
  styleUrls: ['./products-details.component.css']
})

export class ProductsDetailsComponent implements OnInit {
  
  product: any;
  conterval: any

  constructor(private productService:ProductsService, private render: Renderer2) { }

  getById(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    });
  }

  counterVal = 0;

  incrementClick(){
      this.updateDisplay(++this.counterVal);
  }
  
  resetCounter() {
     // this.counterVal = 0;
      this.updateDisplay(--this.counterVal);
  }
  
  updateDisplay(val: any) {
      this.render.selectRootElement('#qtd').innerHTML = val;
  }

  ngOnInit(): void {
    this.getById(15);
  }
  

  
}
