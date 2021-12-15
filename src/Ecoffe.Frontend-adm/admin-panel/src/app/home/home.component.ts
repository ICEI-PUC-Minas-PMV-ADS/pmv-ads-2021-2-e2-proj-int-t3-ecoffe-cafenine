import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario.model';
import { usersService } from '../services/users.service';
import { ActivatedRoute } from '@angular/router';
import { SnackbarService } from './../services/snackbar.service';
import { ConfirmDialogService } from './../services/confirm-dialog.service';
import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

 users: Usuario []
 

  constructor(private usersService: usersService,
    private route: ActivatedRoute,
    private confirmDialogService: ConfirmDialogService, 
    private snackbarService: SnackbarService,
    private matDialog: MatDialog
    ) { }

  loadUsers(){
    this.usersService.getAll().subscribe((result) => { 
      this.users = result;
    });
 
  }
  ngOnInit(): void {
    this.loadUsers();
  }

  deleteConfirm(id: number){
    this.confirmDialogService.openConfirmDialog("Tem certeza que deseja deletar este Usuario?").afterClosed().subscribe(confirm => {
      if(confirm)
        this.delete(id);  
    })
  }

  delete(id: number){
    this.usersService.deleteById(id).subscribe(() =>{
      this.snackbarService.showMessage("Usuario deletado com sucesso!");
      this.loadUsers();
    });
  }
  openUserNewModal(id: number,tela: number){
    this.usersService.openUserNewModal(id,tela).afterClosed().subscribe(() =>{
      this.loadUsers();
    });
  }
}
