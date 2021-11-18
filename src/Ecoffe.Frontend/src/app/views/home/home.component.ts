import { BooleanInput } from '@angular/cdk/coercion';
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

  constructor(private render: Renderer2) {
      this.di();
   }

  ngOnInit(): void {
  }
  
  troca(){
    this.render.selectRootElement('h1').innerHTML = "teste";
    this.render.selectRootElement('p').innerHTML = "Teste no para";
    this.render.selectRootElement('#price').innerHTML = "Preço";
    this.render.selectRootElement('.img').src = "../../../assets/img2.png";
    this.render.selectRootElement('.img2').src = "../../../assets/img1.png";
  }

  troca2(){
    this.render.selectRootElement('h1').innerHTML = "Titulo 2";
    this.render.selectRootElement('p').innerHTML = "paragrafo 2 teste 2";
    this.render.selectRootElement('#price').innerHTML = "preço 2";
    this.render.selectRootElement('.img').src = "../../../assets/img3.png";
    this.render.selectRootElement('#img3').src = "../../../assets/img1.png";
  }
    


}



