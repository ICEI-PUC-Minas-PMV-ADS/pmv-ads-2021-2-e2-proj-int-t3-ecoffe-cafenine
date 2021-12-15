import { Usuario } from './../models/usuario.model';
import { usersService } from './../services/users.service';

import { SnackbarService } from './../services/snackbar.service';
import { ConfirmDialogService } from './../services/confirm-dialog.service';
import { productsService } from './../services/products.service';
import { Component, Inject, OnInit } from '@angular/core';
import { Produto } from '../models/produto.model';
import { ActivatedRoute } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-alter-news',
  templateUrl: './alter-news.component.html',
  styleUrls: ['./alter-news.component.scss']
})
export class AlterNewsComponent implements OnInit {
 prodId = 0;
 telas = 0;
  productHelper: any = {};
  userHelper: any = {};



  constructor(private productsService: productsService,
    private route: ActivatedRoute,
    private confirmDialogService: ConfirmDialogService, 
    private snackbarService: SnackbarService,
    private matDialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private usersService: usersService,

   ) {}

  ngOnInit(): void {
      if(this.prodId != null ){
        this.alterarCss();
      }
  }

  loadProduct(){
    this.productsService.getById(this.prodId).subscribe((result)=> {
      this.productHelper.nome = result.nome;
      this.productHelper.peso = result.peso;
      this.productHelper.altura = result.altura;
      this.productHelper.largura = result.largura;
      this.productHelper.comprimento = result.comprimento;
      this.productHelper.valor = result.valor;
      this.productHelper.imgUrl = result.imgUrl;

    })
  }

  
  saveProd(){
    
    let prod: Produto = {
      id: this.prodId,
      nome: this.productHelper.nome,
      peso: this.productHelper.peso,
      altura: this.productHelper.altura,
      largura: this.productHelper.largura,
      comprimento: this.productHelper.comprimento,
      valor: this.productHelper.valor,
      imgUrl: this.productHelper.imgUrl
    }
    if(prod.id != 0){
        this.productsService.alterProduct(prod).subscribe(() => {    
          this.snackbarService.showMessage("Produto cadastrado com sucesso!");
          this.matDialog.closeAll();
        })
      }
      else{
        this.productsService.saveProduct(prod).subscribe(() =>{
          this.snackbarService.showMessage("Produto cadastrado com sucesso!");
          this.matDialog.closeAll();
        })
      }
      
    }

    loadUser(){
      this.usersService.getById(this.prodId).subscribe((result)=> {
        this.userHelper.nome = result.nome;
        this.userHelper.email = result.email;
        this.userHelper.ativo = result.ativo;
        this.userHelper.admin = result.admin;
        this.userHelper.telefone = result.telefone;
        this.userHelper.cpf = result.cpf;
      })
    }
    
    saveUser(){
   
    let user: Usuario = {
      id: this.prodId,
      nome: this.userHelper.nome,
      email: this.userHelper.email,
      telefone: this.userHelper.telefone,
      ativo: this.userHelper.ativo,
      admin: this.userHelper.admin,
      cpf: this.userHelper.cpf,
      senha: this.userHelper.senha
    }
    if(user.id != 0){
        this.usersService.alterUser(user).subscribe(() => {    
          this.snackbarService.showMessage("Usuario Alterado com sucesso!");
          this.matDialog.closeAll();
        })
    }
    else{
      this.usersService.alterUser(user).subscribe(() =>{
        this.snackbarService.showMessage("Usuario cadastrado com sucesso!");
        this.matDialog.closeAll();
      })
    }

  }
  alterarCss(){
    if(this.telas == 2){
       let d = document.getElementById("produto");
      d.style.display = "list-item";
      if(this.prodId > 0)
        this.loadProduct();
    }
    else if(this.telas == 1){
      let x = document.getElementById("usuario");
      x.style.display = "list-item";
      this.loadUser();
    }
  }

}
