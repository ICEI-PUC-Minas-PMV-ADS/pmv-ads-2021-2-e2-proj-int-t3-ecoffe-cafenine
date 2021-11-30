import { Component, OnInit, Renderer2 } from '@angular/core';
import { ProductsService } from './../../services/products.service';
import { Produto } from './../../models/produto.model';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

 // product: any;

produto: Produto[] = [];

  constructor(private productService:ProductsService, private render: Renderer2) { 
  }


 /* getById(productId: number){
    this.productService.getById(productId).subscribe((result) =>{
      this.product = result;
    });
  }

  buscaProduto(id1: number, id2: number, id3: number, id4: number, id5: number){
    this.getById(id1);
    this.getById2(id2);
    this.getById3(id3);
    this.getById4(id4);
    this.getById5(id5);
  } */

  ngOnInit(): void {
    this.productService.list().subscribe(dados => this.produto = dados);
    this.cleanLoad();
  }

  cleanLoad(){
    setTimeout(()=>{
      this.render.selectRootElement('.C-Loader').style.display = "none";
    }, 2000); 
  }

}