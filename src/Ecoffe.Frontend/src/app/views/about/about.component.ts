import { Component, OnInit } from '@angular/core';
import { Email } from 'src/app/helpers/email.Model';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  email: Email = {} as Email;

  constructor() { }

  ngOnInit(): void {
  }
  EnviarEmail(){    
    
    //Validação caso algum campo esteja vazio
    if(this.email.nome && this.email.telefone && this.email.email){
        let texto = "Olá, meu nome é " + this.email.nome + ", telefone " + this.email.telefone + ", e-mail de contato " + this.email.email + ". Entro em contato pelo seguinte motivo: "+ this.email.corpo;
    
    


        //Abre o client de email do usuário, já com campos preenchidos
        window.open('mailto:contato@webhardware.com?subject='+ this.email.nome +' - Contato via Site&body=' + texto);
        alert('Obrigado sr(a) ' + this.email.nome + ', seu feedback é muito importante para a gente!');
      }
  }
}





