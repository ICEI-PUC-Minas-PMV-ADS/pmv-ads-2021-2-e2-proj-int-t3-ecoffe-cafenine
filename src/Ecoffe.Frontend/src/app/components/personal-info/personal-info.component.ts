import { LoginRegisterService } from './../../services/login-register.service';
import { PersonalInfoService } from '../../services/personal-info.service';
import { Endereco } from './../../models/endereco.model';
import { Router } from '@angular/router';
import { Usuario } from './../../models/usuario.model';
import { SnackbarService } from './../../services/snackbar.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.css']
})
export class PersonalInfoComponent implements OnInit {
  usuario: any = {};
  endereco: any = {};

  validateErrors: string[] = [];

  disabledInputs: boolean = true;

  constructor(private loginRegisterService: LoginRegisterService, private personalInfoService: PersonalInfoService, private router: Router, private snackbarService: SnackbarService) { }

  ngOnInit(): void {
    let userId: any;
    userId = localStorage.getItem("usuarioId");

    if(!userId || userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    this.loginRegisterService.getUserById(userId).subscribe(user => {
      this.usuario = user;
      this.endereco = user.endereco;

      if(!this.usuario){
        this.router.navigate(["/login"]);  
        return;
      }
  
    });
  }

  update() {
    this.disabledInputs = true;
    this.validate();
    
    if(this.validateErrors.length > 0){
      this.disabledInputs = false;
      return;
    }
      
    this.usuario.endereco = this.endereco;

    this.personalInfoService.update(this.usuario).subscribe(() => {
      this.snackbarService.showMessage("Dados alterados com sucesso");
    }, (error) => {
      this.disabledInputs = false;
      this.validateErrors.push(JSON.stringify(error.error).replace(/"/g,''));
    })
  }

  validate(){
    this.validateErrors = [];

    if(!this.usuario.nome)
      this.validateErrors.push("Nome deve ser informado");  

    if(!this.usuario.cpf || this.usuario.cpf.length != 11)
      this.validateErrors.push("CPF inválido");  

      if(!this.usuario.email || !this.validateEmail(this.usuario.email))
        this.validateErrors.push("Email inválido");  

    if(!this.endereco.cep && 
       !this.endereco.numero &&
       !this.endereco.rua &&
       !this.endereco.cidade &&
       !this.endereco.bairro &&
       !this.endereco.complemento &&
       !this.endereco.uf)
       return;

    if(!this.endereco.cep || this.endereco.cep.length != 8)
      this.validateErrors.push("CEP inválido");

    if(!this.endereco.rua)
      this.validateErrors.push("Rua deve ser informada");   

    if(!this.endereco.numero)
      this.validateErrors.push("Número deve ser informado"); 

    if(!this.endereco.bairro)
      this.validateErrors.push("Bairro deve ser informado"); 

    if(!this.endereco.cidade)
      this.validateErrors.push("Cidade deve ser informada"); 

    if(!this.endereco.uf)
      this.validateErrors.push("UF deve ser informado"); 
  }

  validateEmail(email: string) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
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

  toggleDisabledInputs(){
    this.disabledInputs = !this.disabledInputs;
  }
}