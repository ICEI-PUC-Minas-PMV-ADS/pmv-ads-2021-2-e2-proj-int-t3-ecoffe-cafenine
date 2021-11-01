import { Router } from '@angular/router';
import { LoginRegisterService } from './../../services/login-register.service';
import { Usuario } from './../../models/usuario.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

  usuario: any;

  constructor(private loginRegisterService: LoginRegisterService, private router: Router) { }

  ngOnInit(): void {
    let userId: any;
    userId = localStorage.getItem("usuarioId");

     if(!userId || userId == ""){
      this.router.navigate(["/login"]);  
      return;
    }

    this.loginRegisterService.getUserById(userId).subscribe(user => {
      this.usuario = user;
    });

  }
}
