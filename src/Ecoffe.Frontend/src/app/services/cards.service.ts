import { Cartao } from './../models/cartao.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CardsService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://localhost:44362/api/Cartao";

  getCardsByUserId(id: string): Observable<Cartao[]>{
    return this.http.get<Cartao[]>(this.baseUrl + "/usuario/" + id);
  }

  turnPrincipal(cardId: number): Observable<Cartao>{
    return this.http.get<Cartao>(this.baseUrl + "/principal/" + cardId);
  }

}
