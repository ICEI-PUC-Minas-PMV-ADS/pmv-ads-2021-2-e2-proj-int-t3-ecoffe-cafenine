import { ProductsService } from './../../services/products.service';
import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

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
  }
  
  troca(titulo: string, desc: string, price: string, url: string){
    this.render.selectRootElement('h1').innerHTML = titulo;
    this.render.selectRootElement('p').innerHTML = desc;
    this.render.selectRootElement('#price').innerHTML = price;
    this.render.selectRootElement('.img').src = url;
  }

  troca2(titulo: string, desc: string, price: string, url: string){
    this.render.selectRootElement('h1').innerHTML = titulo;
    this.render.selectRootElement('p').innerHTML = desc;
    this.render.selectRootElement('#price').innerHTML = price;
    this.render.selectRootElement('.img').src = url;
  }

  abre_mod(){
    this.productsService.openProductModal().afterClosed().subscribe(() =>{
    });
  }
 

}



