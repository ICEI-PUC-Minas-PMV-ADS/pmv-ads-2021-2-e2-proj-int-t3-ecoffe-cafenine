import { HttpClient } from '@angular/common/http';
import { Produto } from './../models/produto.model';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { AlterNewsComponent } from '../alter-news/alter-news.component';


@Injectable({
    providedIn: 'root'
})
  
export class productsService {
  
  constructor(private matDialog: MatDialog, private http: HttpClient) { }
  
    baseUrl = "https://ecoofeeback.azurewebsites.net/api/Produto";
  
    getById(id: number): Observable<Produto> {
      return this.http.get<Produto>(this.baseUrl+"/"+id);
    }
  
    getAll(): Observable<Produto[]> {
      return this.http.get<Produto[]>(this.baseUrl);
    }
    
    deleteById(id: number): Observable<Produto> {
      return this.http.delete<Produto>(this.baseUrl+"/"+id);
    }
    alterProduct(produto: Produto): Observable<Produto>{
      return this.http.put<Produto>(this.baseUrl, produto);
    }

    openProductNewModal(id: number, tela:number){
     let result=  this.matDialog.open((AlterNewsComponent), {
        width: '600px',
        disableClose: false
      });
      result.componentInstance.prodId = id;
      result.componentInstance.telas = tela;
      return result;
    }  
    saveProduct(produto: Produto): Observable<Produto>{
      return this.http.post<Produto>(this.baseUrl, produto);
    }
      

}