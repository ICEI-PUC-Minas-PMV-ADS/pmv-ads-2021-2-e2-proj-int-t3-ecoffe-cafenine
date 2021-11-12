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

  constructor(private cardsService: CardsService, private router: Router) { }

  ngOnInit(): void {
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
}