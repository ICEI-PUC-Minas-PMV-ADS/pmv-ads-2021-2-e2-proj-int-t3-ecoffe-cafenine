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
  
  constructor(private loginRegisterService: LoginRegisterService, private http: HttpClient) { }

  ngOnInit(): void {
  }

  login() : void {
    this.loginRegisterService.login(this.loginUser).subscribe(usuario => {
        localStorage.setItem("usuarioId",usuario.id.toString());
        localStorage.setItem("usuarioCpf",usuario.cpf);
        localStorage.setItem("usuarioNome",usuario.nome);
        localStorage.setItem("usuarioAdmin",usuario.admin ? "true" : "false");
        localStorage.setItem("usuarioEmail",usuario.email);
    })
  }

  register() : void {
    this.loginRegisterService.register(this.newUser).subscribe(() => {

    })
  }

}
