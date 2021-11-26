import { HttpClient } from '@angular/common/http';
import { Produto } from './../models/produto.model';
import { Injectable } from '@angular/core';
import { ProductsDetailsComponent } from '../components/products-details/products-details.component';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ProductsService {

  constructor(private matDialog: MatDialog, private http: HttpClient) { }

  baseUrl = "https://localhost:44365/api/Produto";

  getById(id: number): Observable<Produto> {
    return this.http.get<Produto>(this.baseUrl+"/"+id);
  }

  openProductModal() {
    return this.matDialog.open(ProductsDetailsComponent, {
      width: '600px',
      disableClose: false
    });
  }
}

