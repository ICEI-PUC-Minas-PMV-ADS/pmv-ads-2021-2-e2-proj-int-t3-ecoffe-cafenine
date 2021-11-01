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

  newUser: Usuario = {
    admin: false,
    ativo: true,
    cpf: "",
    email: "",
    endereco: {

    },
    nome: "",
    senha: "",
    telefone: "",
  } 

  loginUser: LoginUsuario = {
    emailCpf: "",
    senha: ""
  }
  
  constructor(private loginRegisterService: LoginRegisterService, private http: HttpClient) { }

  ngOnInit(): void {
  }

  login() : void {

    console.log("logando");

    this.loginRegisterService.login(this.loginUser).subscribe(() => {
      
    })
  }

  
  teste(){
    console.log("Inicio do Método");
    this.http.get<any>('https://localhost:44382/produto/').subscribe(data => {
      console.log(data);
    })
    
  }

}
