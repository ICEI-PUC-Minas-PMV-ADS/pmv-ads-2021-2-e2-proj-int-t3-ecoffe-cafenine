import { Usuario, LoginUsuario } from './../models/usuario.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginRegisterService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://ecoofeeback.azurewebsites.net/api/Usuario";

  getUserById(id: string): Observable<Usuario>{
    return this.http.get<Usuario>(this.baseUrl + "/" + id);
  }

  createUser(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.baseUrl, usuario);
  }

  login(loginUser: LoginUsuario) : Observable<Usuario> {
    return this.http.post<Usuario>(this.baseUrl + "/Login", loginUser);
  }

  register(newUser: Usuario) : Observable<Usuario>{
    return this.http.post<Usuario>(this.baseUrl, newUser);
  }

}
