import { SnackbarService } from './../../services/snackbar.service';
import { Component, OnInit } from '@angular/core';
import { Email } from 'src/app/helpers/email.model';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  errors: string[] = [];

  email: Email = {} as Email;

  constructor(private snackbarService: SnackbarService) { }

  ngOnInit(): void {
  }

  enviarEmail(){    
    this.errors = [];

    if(!this.email.nome || this.email.nome == '')
      this.errors.push("Nome deve ser preenchido");
    
    if(!this.email.email || !this.validateEmail(this.email.email))
      this.errors.push("Email inválido");

    if(!this.email.corpo || this.email.corpo == '')
      this.errors.push("Mensagem inválida");

    if(this.errors.length > 0)
      return;

      let texto = "Olá, meu nome é " + this.email.nome + ", telefone " + this.email.telefone + ", e-mail de contato " + this.email.email + ". Entro em contato pelo seguinte motivo: "+ this.email.corpo;

      this.snackbarService.showMessage("Obrigado pelo contato!");

      window.open('mailto:contato@cafenine.com?subject='+ this.email.nome +' - Contato via Site&body=' + texto);
}

  validateEmail(email: string) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }
  
}





