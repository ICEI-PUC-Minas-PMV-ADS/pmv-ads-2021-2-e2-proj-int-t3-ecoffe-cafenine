import { Usuario, LoginUsuario } from './../models/usuario.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginRegisterService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://localhost:44362/api/Usuario";

 

  createUser(usuario: Usuario): Observable<Usuario> {



    return this.http.post<Usuario>(this.baseUrl, usuario);
  }

  login(loginUser: LoginUsuario) : Observable<Usuario> {
    let request = this.http.post<Usuario>(this.baseUrl + "/Login", loginUser);

    return request;
  }


}
