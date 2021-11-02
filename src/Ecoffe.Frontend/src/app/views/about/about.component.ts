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

var posicaoSliderIntegrante = 0;

function MudarIntegrante() {
  //Lista de objetos com várias propriedades
  let integrantes = [
      {foto: '../img/integrantes/felipe.png', nome: 'Felipe Bohm', linkedin: 'https://www.linkedin.com/in/felipe-bohm-mitre-268b171a2/', github: 'https://github.com/lipebohmmitre'},
      {foto: '../img/integrantes/gabriel.png', nome: 'Gabriel Ilídio', linkedin: 'https://www.linkedin.com/in/gabriel-il%C3%ADdio-8aa54b86/', github: 'https://github.com/gilidio8'},
      {foto: '../img/integrantes/iann.png', nome: 'Iago Iann', linkedin: '', github: 'https://github.com/IagoIann'},
      {foto: '../img/integrantes/joao.png', nome: 'João Sena', linkedin: 'https://www.linkedin.com/in/jo%C3%A3o-sena-57489b11b/', github: 'https://github.com/joaosena19'},
      {foto: '../img/integrantes/victor.png', nome: 'Victor Lopes', linkedin: 'https://www.linkedin.com/in/victor-santos-a6b3491a2/', github: 'https://github.com/VictorLopes1010'},
      {foto: '../img/integrantes/yuri.png', nome: 'Yuri Witter', linkedin: 'https://www.linkedin.com/in/yuri-witer-12aba9181/', github: 'https://github.com/YuriWiter-dev'},
  ];
    
    
    //document.getElementById('integranteNome').innerHTML = integrantes[posicaoSliderIntegrante].nome;
    //document.getElementById('integranteLinkLinkedin').setAttribute("href", integrantes[posicaoSliderIntegrante].linkedin);
    //document.getElementById('integranteLinkGithub').setAttribute("href", integrantes[posicaoSliderIntegrante].github);
    
  posicaoSliderIntegrante++;

  //Quando chega no último integrante ele reincia a posição
  if(posicaoSliderIntegrante == integrantes.length)
      posicaoSliderIntegrante = 0;

  setTimeout('MudarIntegrante()',3500);

  
}