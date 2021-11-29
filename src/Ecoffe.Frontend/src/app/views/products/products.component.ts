import { Component, OnInit, Renderer2 } from '@angular/core';
import { ProductsService } from './../../services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  product: any;
  product2: any;
  product3: any;
  product4: any;
  product5: any;

  constructor(private productService:ProductsService, private render: Renderer2) { }

  getById(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    });
  }

  getById2(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product2 = result;
    })
  }

  getById3(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product3 = result;
    })
  }

  getById4(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product4 = result;
    })
  }

  getById5(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product5 = result;
    })
  }

  buscaProduto(id1: number, id2: number, id3: number, id4: number, id5: number){
    this.getById(id1);
    this.getById2(id2);
    this.getById3(id3);
    this.getById4(id4);
    this.getById5(id5);
  }

  cleanLoad(){
    setTimeout(()=>{
      this.render.selectRootElement('.C-Loader').style.display = "none";
    }, 3000);
    
  }

  ngOnInit(): void {
    this.buscaProduto(8,15,9,10,11);
    this.cleanLoad();
  }

}
