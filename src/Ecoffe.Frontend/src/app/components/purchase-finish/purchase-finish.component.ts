import { CardsService } from './../../services/cards.service';
import { Cartao } from './../../models/cartao.model';
import { FormaPagamento, FormaPagamentoLabel } from './../../models/compra.model';
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

  formaPagamentoLabel = FormaPagamentoLabel;
  formaPagamentoSelected: any;

  cardList: Cartao[] = [];
  cardSelected: any;

  parcelas = 1;

  userId: any;
  totalValue = 0;

  constructor(private router: Router, private cartService: CartService, private snackbarService: SnackbarService, private personalInfoService: PersonalInfoService, private cardsService: CardsService) { }

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

  loadCardList(){
    this.cardsService.getCardsByUserId(this.userId).subscribe((data) => {
      this.cardList = data.filter(p => p.tipoCartao == this.formaPagamentoSelected.key);

      if(this.cardList.filter(p => p.principal == true).length > 0)
        this.cardSelected = this.cardList.filter(p => p.principal == true)[0];
    })
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

  openCardNewModal(){
    this.cardsService.openCardNewModal().afterClosed().subscribe(() =>{
      this.loadCardList();
    });
  }

}
