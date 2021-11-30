import { Router } from '@angular/router';
import { SnackbarService } from './../../services/snackbar.service';
import { HttpClient } from '@angular/common/http';
import { LoginRegisterService } from './../../services/login-register.service';
import { Usuario, LoginUsuario } from './../../models/usuario.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-register',
  templateUrl: './login-register.component.html',
  styleUrls: ['./login-register.component.css']
})
export class LoginRegisterComponent implements OnInit {

  errorLogin: string = '';
  errorRegister: string = '';

  newUser: Usuario = {
    id: 0,
    admin: false,
    ativo: true,
    cpf: "",
    email: "",
    nome: "",
    senha: "",
    telefone: "",
  } 

  loginUser: LoginUsuario = {
    emailCpf: "",
    senha: ""
  }
  
  confirmPassword: string = "";

  constructor(private loginRegisterService: LoginRegisterService, private http: HttpClient, private snackbarService: SnackbarService, private router: Router) { }

  ngOnInit(): void {
  }

  login() : void {
    this.validateLogin();

    this.loginRegisterService.login(this.loginUser).subscribe(usuario => {
        localStorage.setItem("usuarioId",usuario.id.toString());
        localStorage.setItem("usuarioCpf",usuario.cpf);
        localStorage.setItem("usuarioNome",usuario.nome);
        localStorage.setItem("usuarioAdmin",usuario.admin ? "true" : "false");
        localStorage.setItem("usuarioEmail",usuario.email);

        this.snackbarService.showMessage("Login realizado com sucesso");

        this.router.navigate(["/"]);  
    }, (error) => {
      this.errorLogin = (JSON.stringify(error.error).replace(/"/g,''));
    })
  }

  register() : void {
    this.validateRegister();

    this.loginRegisterService.register(this.newUser).subscribe((data) => {
      this.snackbarService.showMessage("Cadastro realizado com sucesso");

      this.loginUser = {
        emailCpf: data.cpf,
        senha: data.senha
      }

      this.login();
    })
  }

  validateLogin(){
    if(!this.loginUser.emailCpf)
      this.errorLogin = "CPF ou Email deve ser informado"

    if(!this.loginUser.senha)
      this.errorRegister = "Senha deve ser informada";
  }

  validateRegister(){
    if(!this.newUser.nome){
      this.errorRegister = "Nome deve ser informado";  
      return;
    }

    if(!this.newUser.cpf || this.newUser.cpf.length != 11){
      this.errorRegister = "CPF inválido";  
      return;
    }

    if(!this.newUser.email || !this.validateEmail(this.newUser.email)){
      this.errorRegister = "Email inválido"; 
      return;
    }

    if(this.newUser.senha != this.confirmPassword){
      this.errorRegister = "Senhas não coincidem";
      return;
    }
  }

  validateEmail(email: string) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }

}
