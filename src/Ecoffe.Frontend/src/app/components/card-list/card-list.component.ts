import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { CardsService } from './../../services/cards.service';

@Component({
  selector: 'app-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.css']
})
export class CardListComponent implements OnInit {

  cards: any = {};

  constructor(private cardsService: CardsService, private router: Router) { }

  ngOnInit(): void {
    let userId: any;
    userId = localStorage.getItem("usuarioId");

    if(!userId || userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    this.cardsService.getCardsByUserId(userId).subscribe(cards => {
      this.cards = cards;
      console.log(this.cards);
    });

  }

}
