import { Usuario } from './../models/usuario.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  baseUrl = "https://localhost:44362/api/Usuario";

  update(usuario: Usuario): Observable<Usuario> {
    return this.http.put<Usuario>(this.baseUrl, usuario);
  }

}
