import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

function EnviarEmail() {    
  let nomeEmail = document.getElementById("nomeEmail");
  let telefoneEmail = document.getElementById("telefoneEmail");
  let emailEmail = document.getElementById("emailEmail");

  //Validação caso algum campo esteja vazio
  if(nomeEmail && telefoneEmail && emailEmail){
      let corpoEmail = "Olá, meu nome é " + nomeEmail + ", telefone " + telefoneEmail + ", e-mail de contato " + emailEmail + ". Entro em contato pelo seguinte motivo: ";
      corpoEmail += document.getElementById("corpoEmail");
  
      //Abre o client de email do usuário, já com campos preenchidos
      window.open('mailto:contato@webhardware.com?subject='+ nomeEmail +' - Contato via Site&body=' + corpoEmail);
      alert('Obrigado sr(a) ' + nomeEmail + ', seu feedback é muito importante para a gente!');
     }
}


function limpa(){
  (<HTMLInputElement>document.getElementById('nomeEmail')).value="";
  (<HTMLInputElement>document.getElementById('telefoneEmail')).value="";
  (<HTMLInputElement>document.getElementById('corpoEmail')).value="";
  (<HTMLInputElement>document.getElementById('emailEmail')).value="";
}