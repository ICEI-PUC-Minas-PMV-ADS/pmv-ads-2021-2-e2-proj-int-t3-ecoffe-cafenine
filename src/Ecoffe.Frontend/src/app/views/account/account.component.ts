import { LoginRegisterService } from './../../services/login-register.service';
import { AccountService } from './../../services/account.service';
import { Endereco } from './../../models/endereco.model';
import { Router } from '@angular/router';
import { Usuario } from './../../models/usuario.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  usuario: any = {};
  endereco: any = {};
  areaType: number = 1;

  constructor(private loginRegisterService: LoginRegisterService, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    let userId: any;
    userId = localStorage.getItem("usuarioId");

    console.log("userid: " + userId);

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

  update() : void {
    this.usuario.endereco = this.endereco;

    this.accountService.update(this.usuario).subscribe(() => {

    })
  }

  changeArea(type: number){
    console.log(type);

    this.areaType = type;
  }

}
