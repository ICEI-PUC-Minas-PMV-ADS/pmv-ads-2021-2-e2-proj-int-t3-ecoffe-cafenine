import { Usuario } from './../models/usuario.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { AlterNewsComponent } from '../alter-news/alter-news.component';

@Injectable({
    providedIn: 'root'
  })
  export class usersService {
  
    constructor(private matDialog: MatDialog, private http: HttpClient) { }

    baseUrl = "https://ecoofeeback.azurewebsites.net/api/Usuario";
    getAll(): Observable<Usuario[]> {
        return this.http.get<Usuario[]>(this.baseUrl);
      }
    getById(id: number): Observable<Usuario> {
        return this.http.get<Usuario>(this.baseUrl+"/"+id);
      }
      
    deleteById(id: number): Observable<Usuario> {
        return this.http.delete<Usuario>(this.baseUrl+"/"+id);
      }

    alterUser(usuario: Usuario): Observable<Usuario>{
        return this.http.put<Usuario>(this.baseUrl, usuario);
      }
      
    openUserNewModal(id: number, tela: number){
       let result=  this.matDialog.open((AlterNewsComponent), {
          width: '600px',
          disableClose: false
        });
        result.componentInstance.prodId = id;
        result.componentInstance.telas = tela;
        return result;
      }   
}