import { PurchaseService } from '../../services/purchase.service';
import { Compra } from '../../models/compra.model';
import { CardsService } from '../../services/cards.service';
import { Cartao } from '../../models/cartao.model';
import { FormaPagamento, FormaPagamentoLabel } from '../../models/compra.model';
import { Endereco } from '../../models/endereco.model';
import { PersonalInfoService } from '../../services/personal-info.service';
import { SnackbarService } from '../../services/snackbar.service';
import { CartService } from '../../services/cart.service';
import { Router } from '@angular/router';
import { Carrinho } from '../../models/carrinho.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {

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

  validateErrorsProducts: string[] = [];
  validateErrorsPayment: string[] = [];
  validateErrorsAdress: string[] = [];

  afterFinish = false;

  constructor(private router: Router, private cartService: CartService, private snackbarService: SnackbarService, private personalInfoService: PersonalInfoService, private cardsService: CardsService, private purchaseService: PurchaseService) { }

  ngOnInit(): void {
    this.afterFinish = false;

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
    this.cardSelected = undefined;

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
      this.endereco.id = 0;
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

  savePurchase(){
    let purchase: Compra = {
      id: 0,
      dataCompra: new Date(),
      usuarioId: this.userId,
      statusCompra: 0,
      enderecoId: this.endereco?.id,
      endereco: this.endereco,
      formaPagamento: this.formaPagamentoSelected?.key,
      cartaoId: this.cardSelected?.id,
      //cartao: this.cardSelected,
      parcelas: this.parcelas,
      valorBruto: this.totalValue,
      valorParcela: this.totalValue / this.parcelas,
      produtosCompraIdList: this.cart.produtos.map(p => p.id)
    }

    this.validate(purchase);

    if(this.validateErrorsProducts.length > 0 || this.validateErrorsPayment.length > 0 || this.validateErrorsAdress.length > 0 )
      return;

    purchase.produtos = undefined;
    
    if(this.endereco.id != 0)
      purchase.endereco = undefined;

    this.purchaseService.save(purchase).subscribe(() => {
      this.afterFinish = true;
    })
  }

  validate(purchase: Compra){
    this.validateErrorsProducts = [];
    this.validateErrorsPayment = [];
    this.validateErrorsAdress = [];

    if(!purchase.usuarioId || purchase.usuarioId == 0){
      this.router.navigate(["/login"]);  
      return;
    }
  

    if(!purchase.produtosCompraIdList || purchase.produtosCompraIdList.length == 0)
      this.validateErrorsProducts.push("Não é possível realizar compra sem nenhum produto");

    if(purchase.formaPagamento == null || purchase.formaPagamento == undefined)
      this.validateErrorsPayment.push("Deve ser selecionada uma forma de pagamento");  

    if((purchase.formaPagamento == FormaPagamento.Debito || purchase.formaPagamento == FormaPagamento.Credito) && (!purchase.cartaoId || purchase.cartaoId == 0))
      this.validateErrorsPayment.push("Deve ser selecionado um cartão");


    //todo reutiliar validacao endereco
    if(!this.endereco.cep || this.endereco.cep.length != 8)
      this.validateErrorsAdress.push("CEP inválido");

    if(!this.endereco.rua)
      this.validateErrorsAdress.push("Rua deve ser informada");   

    if(!this.endereco.numero)
      this.validateErrorsAdress.push("Número deve ser informado"); 

    if(!this.endereco.bairro)
      this.validateErrorsAdress.push("Bairro deve ser informado"); 

    if(!this.endereco.cidade)
      this.validateErrorsAdress.push("Cidade deve ser informada"); 

    if(!this.endereco.uf)
      this.validateErrorsAdress.push("UF deve ser informado"); 
  }

}
