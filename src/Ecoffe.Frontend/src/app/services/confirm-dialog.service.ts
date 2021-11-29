import { ConfirmDialogComponent } from './../components/confirm-dialog/confirm-dialog.component';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

@Injectable({
  providedIn: 'root'
})
export class ConfirmDialogService {

  constructor(private confirmDialog: MatDialog) { }

  openConfirmDialog(message: string){
    return this.confirmDialog.open(ConfirmDialogComponent, {
      width: '390px',
      disableClose: false,
      data : {
        message : message
      }
    });
  }
}
