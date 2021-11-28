import { CardNewComponent } from '../components/card-new/card-new.component';
import { MatDialog } from '@angular/material/dialog';
import { Compra } from '../models/compra.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PurchaseDetailsComponent } from '../components/purchase-details/purchase-details.component';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {

  constructor(private http: HttpClient, private matDialog: MatDialog) { }

  baseUrl = "https://localhost:44362/api/Compra";

  save(compra: Compra): Observable<Compra>{
    return this.http.post<Compra>(this.baseUrl, compra);
  }

  getLatestByUserId(userId: number): Observable<Compra>{
    return this.http.get<Compra>(this.baseUrl + "/usuario/recente/" + userId);
  }

  getListByUserId(userId: number): Observable<Compra[]>{
  return this.http.get<Compra[]>(this.baseUrl + "/usuario/" + userId);
  }

  openPurchaseDetailsModal(){
    return this.matDialog.open(PurchaseDetailsComponent, {
      width: '90%',
      height: '90%',
      disableClose: false
    });
  }
}