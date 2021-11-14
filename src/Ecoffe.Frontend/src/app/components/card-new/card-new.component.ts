import { Router } from '@angular/router';
import { SnackbarService } from './../../services/snackbar.service';
import { CardsService } from './../../services/cards.service';
import { Cartao, TipoCartao } from './../../models/cartao.model';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-card-new',
  templateUrl: './card-new.component.html',
  styleUrls: ['./card-new.component.css']
})
export class CardNewComponent implements OnInit {

  cardHelper: any = {};

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private cardsService: CardsService, private snackbarService: SnackbarService, private router: Router) { }

  ngOnInit(): void {
  }

  save(){
    let userId: any;
    userId = localStorage.getItem("usuarioId");

    if(!userId || userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    let card: Cartao = {
      id: 0,
      usuarioId: userId,
      numero: this.cardHelper.numero,
      vencimento: new Date(this.cardHelper.ano + "/" + this.cardHelper.mes + "/01"),
      nomeTitular: this.cardHelper.nomeTitular,
      bandeira: this.getCardBrandByNumber(this.cardHelper.numero),
      csv: this.cardHelper.csv,
      tipoCartao: this.cardHelper.tipoCartao,
      principal: this.cardHelper.principal
    }

    console.log(card);

    return;


    this.cardsService.save(card).subscribe(card => {
      this.snackbarService.showMessage("Cartão cadastrado com sucesso!");
    })
  }

  getCardBrandByNumber(cardNumber: string): string{
    if(!cardNumber)
      return '';

    if(cardNumber.substring(0,1) == '4') return 'visa';
    if(['51','52','53','54','55'].includes(cardNumber.substring(0,2))) return 'mastercard';
    if(['36,38'].includes(cardNumber.substring(0,2))) return 'dinersclub';
    if(cardNumber.substring(0,2) == '65') return 'discover';
    if(cardNumber.substring(0,4) == '6011') return 'discover';
    if(cardNumber.substring(0,2) == '35') return 'jcb';
    if(['34,37'].includes(cardNumber.substring(0,2))) return 'americanexpress';
    return '';
  }
}
