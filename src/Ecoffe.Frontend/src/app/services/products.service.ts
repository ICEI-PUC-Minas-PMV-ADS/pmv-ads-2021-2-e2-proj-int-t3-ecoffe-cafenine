import { Carrinho } from './../models/carrinho.model';
import { ProdutoCarrinho } from './../helpers/produtoCarrinho.model';
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

  baseUrl = "https://ecoofeeback.azurewebsites.net/api/Produto";

  getById(id: number): Observable<Produto> {
    return this.http.get<Produto>(this.baseUrl+"/"+id);
  }

  getAll(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.baseUrl);
  }

  addProductToCart(productCart: ProdutoCarrinho): Observable<Carrinho>{
    return this.http.post<Carrinho>("https://ecoofeeback.azurewebsites.net/api/carrinho/addProduct", productCart);
  }

  openProductModal() {
    return this.matDialog.open(ProductsDetailsComponent, {
      width: '600px',
      disableClose: false
    });
  }
}

