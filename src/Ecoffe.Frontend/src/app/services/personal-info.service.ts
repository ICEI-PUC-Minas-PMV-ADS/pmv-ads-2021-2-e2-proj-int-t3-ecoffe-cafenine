import { Endereco } from './../models/endereco.model';
import { ViaCepAdress } from '../helpers/viaCepAdress.model';
import { Usuario } from '../models/usuario.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonalInfoService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://ecoofeeback.azurewebsites.net/api/Usuario";

  update(usuario: Usuario): Observable<Usuario> {
    return this.http.put<Usuario>(this.baseUrl, usuario);
  }

  getEnderecoByUserId(userId: number){
    return this.http.get<Endereco>(this.baseUrl + "/endereco/" + userId);
  }

  getAdress(cep: string){
    if(cep.length != 8)
      return ;

    return this.http.get<ViaCepAdress>("https://viacep.com.br/ws/" + cep + "/json");
  }

}
