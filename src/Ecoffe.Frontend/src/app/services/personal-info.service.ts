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

  baseUrl = "https://localhost:44362/api/Usuario";

  update(usuario: Usuario): Observable<Usuario> {
    return this.http.put<Usuario>(this.baseUrl, usuario);
  }

  getAdress(cep: string){
    if(cep.length != 8)
      return ;

    return this.http.get<ViaCepAdress>("https://viacep.com.br/ws/" + cep + "/json");
  }

}
