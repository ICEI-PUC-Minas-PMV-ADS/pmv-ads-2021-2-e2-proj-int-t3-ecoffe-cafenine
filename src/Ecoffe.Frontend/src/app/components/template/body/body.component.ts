import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHandler, HttpXhrBackend } from '@angular/common/http';


const httpClient = new HttpClient(new HttpXhrBackend({ build: () => new XMLHttpRequest()}));

@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
    produtos: any;

  carregarProdutos(){
    console.log("Inicio do Método");
    httpClient.get<any>('https://ecoofeeback.azurewebsites.net/api/produto/GetAll').subscribe(data => {
      console.log(data);
    })
    console.log(this.produtos);
  };
  
  

}
