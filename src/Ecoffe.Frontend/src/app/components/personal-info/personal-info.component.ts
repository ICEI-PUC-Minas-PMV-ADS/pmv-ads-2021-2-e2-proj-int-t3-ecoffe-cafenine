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

  update() : void {
    this.usuario.endereco = this.endereco;

    this.personalInfoService.update(this.usuario).subscribe(() => {
      this.snackbarService.showMessage("Dados alterados com sucesso");
    })
  }
}
