import { Endereco } from './../../models/endereco.model';
import { PersonalInfoService } from './../../services/personal-info.service';
import { SnackbarService } from './../../services/snackbar.service';
import { CartService } from './../../services/cart.service';
import { Router } from '@angular/router';
import { Carrinho } from './../../models/carrinho.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchase-finish',
  templateUrl: './purchase-finish.component.html',
  styleUrls: ['./purchase-finish.component.css']
})
export class PurchaseFinishComponent implements OnInit {

  cart: Carrinho = {
    id: 0,
    produtos: []
  };

  endereco: Endereco = {
    bairro: '',
    cep: '',
    cidade: '',
    complemento: '',
    id: 0,
    numero: '',
    rua: '',
    uf: ''
  };

  userId: any;
  totalValue = 0;

  constructor(private router: Router, private cartService: CartService, private snackbarService: SnackbarService, private personalInfoService: PersonalInfoService) { }

  ngOnInit(): void {
    this.userId = localStorage.getItem("usuarioId");

    if(!this.userId || this.userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    this.loadCart();
    this.loadAdress();
  }

  loadCart(){
    this.cartService.getCartByUserId(this.userId).subscribe((data) => { 
      this.cart = data;
      this.getTotalValue();
    });
  }

  loadAdress(){
    this.personalInfoService.getEnderecoByUserId(this.userId).subscribe((data) => {
      this.endereco = data;
    });
  }

  getTotalValue(){
    this.totalValue = 0;

    this.cart.produtos.forEach(produto => {
      this.totalValue += produto.valorTotal;
    })
  }

  getAdress(){
    this.personalInfoService.getAdress(this.endereco.cep)?.subscribe(adress => {
      this.endereco.rua = adress.logradouro;
      this.endereco.complemento = adress.complemento;
      this.endereco.bairro = adress.bairro;
      this.endereco.cidade = adress.localidade;
      this.endereco.uf = adress.uf;
    })
  }

  removeProductFromCart(productCartId: number){
    this.cartService.removeProductFromCart(productCartId).subscribe((data) => {
      this.loadCart();
      this.snackbarService.showMessage("Produto removido com sucesso!");
    })
  }

  updateProductCart(productCart: any){
    this.cartService.update(productCart).subscribe((data) => {
      this.loadCart(); //todo mapear retorno do data
    })
  }

}
