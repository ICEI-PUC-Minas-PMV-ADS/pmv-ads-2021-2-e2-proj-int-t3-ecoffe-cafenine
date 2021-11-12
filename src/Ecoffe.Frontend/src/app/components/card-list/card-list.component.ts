import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.css']
})
export class CardListComponent implements OnInit {

  cards: any = {};

  constructor() { }

  ngOnInit(): void {
    this.cards = [
        {
          bandeira: 'VISA',
          numero: '0000.0000.0000.0000',
          nomeTitular: 'João Alberto Silva',
          tipoCartao: 'DÉBITO',
          dataVencimento: '09/2024'
        },
        {
          bandeira: 'MASTERCARD',
          numero: '1111.1111.1111.1111',
          nomeTitular: 'Castro Damaceno Tadeu',
          tipoCartao: 'CRÉDITO',
          dataVencimento: '10/2025'
        },
        {
          bandeira: 'MASTERCARD',
          numero: '1111.1111.1111.1111',
          nomeTitular: 'Castro Damaceno Tadeu',
          tipoCartao: 'CRÉDITO',
          dataVencimento: '10/2025'
        }
    ]





  }

}
