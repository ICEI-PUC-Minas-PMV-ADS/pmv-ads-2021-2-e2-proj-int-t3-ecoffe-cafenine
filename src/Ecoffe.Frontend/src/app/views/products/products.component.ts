import { SnackbarService } from './../../services/snackbar.service';
import { Router } from '@angular/router';
import { ProdutoCarrinho } from './../../helpers/produtoCarrinho.model';
import { ProductsService } from './../../services/products.service';
import { Produto } from './../../models/produto.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  userId: any;

  products: Produto[] = [];
  
  constructor(private productsService: ProductsService, private router: Router, private snackbarService: SnackbarService) { }

  ngOnInit(): void {
    this.loadProducts();
  }
  addProductToCart(produto: Produto){
    this.userId = localStorage.getItem("usuarioId");

    if(!this.userId || this.userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    let newProductCarrinho: ProdutoCarrinho = {
      id: 0,
      produtoId: produto.id,
      quantidade: 1,
      usuarioId: this.userId,
      valorTotal: produto.valor,
      produto: produto
    }

    this.productsService.addProductToCart(newProductCarrinho).subscribe(() => {
      this.snackbarService.showMessage("Produto adicionado ao carrinho com sucesso");
    })
    
  }

  loadProducts(){
    this.productsService.getAll().subscribe((data) => {
      this.products = data; 
    })
  }
}
