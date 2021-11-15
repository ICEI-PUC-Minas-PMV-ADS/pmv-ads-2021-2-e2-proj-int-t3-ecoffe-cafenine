import { Router } from '@angular/router';
import { SnackbarService } from './../../services/snackbar.service';
import { CardsService } from './../../services/cards.service';
import { Cartao, TipoCartao } from './../../models/cartao.model';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-card-new',
  templateUrl: './card-new.component.html',
  styleUrls: ['./card-new.component.css']
})
export class CardNewComponent implements OnInit {

  cardHelper: any = {};
  validateErrors: string[] = [];

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private cardsService: CardsService, private snackbarService: SnackbarService, private router: Router, private matDialog: MatDialog) { }

  ngOnInit(): void {
  }

  save(){
    let userId: any;
    userId = localStorage.getItem("usuarioId");

    if(!userId || userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    this.validate();

    if(this.validateErrors.length > 0)
      return;

    let card: Cartao = {
      id: 0,
      usuarioId: userId,
      numero: this.cardHelper.numero,
      vencimento: new Date(this.cardHelper.ano + "/" + this.cardHelper.mes + "/01"),
      dataAdicao: new Date(),
      nomeTitular: this.cardHelper.nomeTitular,
      bandeira: this.getCardBrandByNumber(this.cardHelper.numero),
      csv: this.cardHelper.csv,
      tipoCartao: Number(this.cardHelper.tipoCartao),
      principal: this.cardHelper.principal
    }

    this.cardsService.save(card).subscribe(() => {    
      this.snackbarService.showMessage("Cartão cadastrado com sucesso!");
      this.matDialog.closeAll();
    }, (error) => {
      this.validateErrors.push(JSON.stringify(error.error).replace(/"/g,''));
    })
  }

  validate(){
    this.validateErrors = [];

    if(!this.cardHelper.numero || this.cardHelper.numero.length > 16 || this.cardHelper.numero.length < 15)
      this.validateErrors.push('Número do cartão inválido');

    let currentYear = new Date().getFullYear();
    let currentMonth = new Date().getMonth();

    this.cardHelper.ano = Number(this.cardHelper.ano);
    this.cardHelper.mes = Number(this.cardHelper.mes);

    if(!this.cardHelper.ano || typeof(this.cardHelper.ano) != typeof(0) || this.cardHelper.ano < currentYear)
      this.validateErrors.push('Ano de expiração do cartão inválido');

    if(!this.cardHelper.mes || typeof(this.cardHelper.mes) != typeof(0) || this.cardHelper.mes < 0 || this.cardHelper.mes > 12 || (this.cardHelper.ano == currentYear && this.cardHelper.mes < currentMonth))
      this.validateErrors.push('Mês de expiração do cartão inválido');

    if(!this.cardHelper.nomeTitular)
      this.validateErrors.push('Nome do titular inválido');

    if(!this.cardHelper.csv || this.cardHelper.csv.length > 4)
      this.validateErrors.push('Código de segurança inválido');

    if(!this.cardHelper.tipoCartao)
      this.validateErrors.push('Tipo de cartão deve ser selecionado');

    if(this.getCardBrandByNumber(this.cardHelper.numero) == '')
      this.validateErrors.push('Bandeira não reconhecida');
  }

  getCardBrandByNumber(cardNumber: string): string{
    if(!cardNumber)
      return '';

    if(cardNumber.substring(0,1) == '4') return 'visa';
    if(['51','52','53','54','55'].includes(cardNumber.substring(0,2))) return 'mastercard';
    if(['36','38'].includes(cardNumber.substring(0,2))) return 'dinersclub';
    if(cardNumber.substring(0,2) == '65') return 'discover';
    if(cardNumber.substring(0,4) == '6011') return 'discover';
    if(cardNumber.substring(0,2) == '35') return 'jcb';
    if(['34','37'].includes(cardNumber.substring(0,2))) return 'americanexpress';
    return '';
  }
}
