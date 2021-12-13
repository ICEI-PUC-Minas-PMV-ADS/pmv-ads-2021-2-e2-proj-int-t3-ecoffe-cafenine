import { Produto } from './../../models/produto.model';
import { ProductsService } from './../../services/products.service';
import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';
import { ProductsDetailsComponent } from 'src/app/components/products-details/products-details.component';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  product: any;

di(){
    let di = document.createElement('div')
    di.style.width = "72px";
    di.style.height = "25px";
    di.style.background = "rgba(190, 54, 54, 0.836)";
    di.style.color = "black";
    di.style.position = "relative";
    di.style.bottom = "320px";
    di.style.left = "540px";
    di.style.borderRadius = "5px";
    di.innerHTML = "Bem Vindo";
    document.body.appendChild(di);
    setTimeout(function(){di.style.display = "none";}, 3000);
}

  constructor(private render: Renderer2, private productsService: ProductsService) {
      this.di();
   }


  ngOnInit(): void {
    this.getById(8);
    this.getById2(12);
    this.getById3(14);
    this.getById4(13);
    this.getById5(9);
    this.getById6(10);
  }
  
  public getById(productId: number){
    this.productsService.getById(productId).subscribe((result) =>{
      this.product = result;
    });
  }

  getById2(productId: number){
    this.productsService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  getById3(productId: number){
    this.productsService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  getById4(productId: number){
    this.productsService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  getById5(productId: number){
    this.productsService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  getById6(productId: number){
    this.productsService.getById(productId).subscribe((result) =>{
      this.product = result;
    })
  }

  troca(){
    this.render.selectRootElement('h1').innerHTML = 'Alguns de nossos Produtos:';
    this.render.selectRootElement('p').innerHTML = 'Nossos deliciosos produtos sortidos, conheça mais na aba Produtos.';
    this.render.selectRootElement('.img').src = '../../../assets/img1.png';
  }

  troca2(){
    this.render.selectRootElement('h1').innerHTML = 'Alguns de nossos Produtos:';
    this.render.selectRootElement('p').innerHTML = 'Conheça nossos produtos aparecendo de forma sortida, para se ter um gostinho do nosso café.';
    this.render.selectRootElement('.img').src = '../../../assets/cafeDesnho.png';
  }

  abre_mod(){
    this.productsService.openProductModal().afterClosed().subscribe(() =>{
    });
  }
 

}



