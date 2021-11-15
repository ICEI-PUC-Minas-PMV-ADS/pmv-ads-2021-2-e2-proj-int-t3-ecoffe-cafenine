import { SnackbarService } from './../../services/snackbar.service';
import { ConfirmDialogService } from './../../services/confirm-dialog.service';
import { Cartao } from './../../models/cartao.model';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { CardsService } from './../../services/cards.service';

@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.css']
})
export class CardListComponent implements OnInit {

  cards: Cartao[] = [];

  constructor(
    private cardsService: CardsService, 
    private router: Router, 
    private confirmDialogService: ConfirmDialogService, 
    private snackbarService: SnackbarService) { }

  ngOnInit(): void {
    this.loadCards();
  }

  loadCards(){
    let userId: any;
    userId = localStorage.getItem("usuarioId");

    if(!userId || userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    this.cardsService.getCardsByUserId(userId).subscribe(cards => {  
      let sortedCards = cards.sort(function (a,b) {
        if(a.principal && !b.principal) return -1;
        if(!a.principal && b.principal) return 1;
        return 0;
      });

      this.cards = sortedCards;
    });
  }

  getCardBrandLogo(brand: string){
    let base = 'assets/card-brands/'
    switch(brand){
      case 'visa':
        return base + 'visa.png';
      case 'mastercard':
        return base + 'mastercard.png';
      case 'dinersclub':
        return base + 'dinersclub.png';
      case 'jcb':
        return base + 'jcb.png';
      case 'americanexpress':
        return base + 'americanexpress.png';
      case 'discover':
        return base + 'discover.png';
      default:
        return;
    }
  }

  turnPrincipalConfirm(cardId: number){
    this.confirmDialogService.openConfirmDialog("Tem certeza que deseja tornar este cartão principal?").afterClosed().subscribe(confirm => {
      if(confirm)
        this.turnPrincipal(cardId);  
    })
  }

  turnPrincipal(cardId: number){
    this.cardsService.turnPrincipal(cardId).subscribe(() =>{
      this.snackbarService.showMessage("Cartão principal alterado com sucesso!");
      this.loadCards();
    });
  }

  deleteConfirm(cardId: number){
    this.confirmDialogService.openConfirmDialog("Tem certeza que deseja deletar este cartão?").afterClosed().subscribe(confirm => {
      if(confirm)
        this.delete(cardId);  
    })
  }

  delete(cardId: number){
    this.cardsService.delete(cardId).subscribe(() =>{
      this.snackbarService.showMessage("Cartão deletado com sucesso!");
      this.loadCards();
    });
  }

  openCardNewModal(){
    this.cardsService.openCardNewModal().afterClosed().subscribe(() =>{
      this.loadCards();
    });
  }

}