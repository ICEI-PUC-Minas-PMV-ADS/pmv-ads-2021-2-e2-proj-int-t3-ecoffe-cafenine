import { CardNewComponent } from './../components/card-new/card-new.component';
import { MatDialog } from '@angular/material/dialog';
import { Cartao } from './../models/cartao.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CardsService {

  constructor(private http: HttpClient, private matDialog: MatDialog) { }

  baseUrl = "https://ecoofeeback.azurewebsites.net/api/Cartao";

  save(card: Cartao): Observable<Cartao>{
    return this.http.post<Cartao>(this.baseUrl, card);
  }

  getCardsByUserId(id: string): Observable<Cartao[]>{
    return this.http.get<Cartao[]>(this.baseUrl + "/usuario/" + id);
  }

  turnPrincipal(cardId: number): Observable<Cartao>{
    return this.http.get<Cartao>(this.baseUrl + "/principal/" + cardId);
  }

  delete(cardId: number): Observable<Cartao>{
    return this.http.delete<Cartao>(this.baseUrl + "/" + cardId);
  }

  openCardNewModal(){
    return this.matDialog.open(CardNewComponent, {
      width: '600px',
      disableClose: false
    });
  }
}
