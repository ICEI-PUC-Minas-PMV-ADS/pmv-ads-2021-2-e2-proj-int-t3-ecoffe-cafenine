import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(private snackBar: MatSnackBar) { }

  showMessage(message: string, duration?: number): void {
    this.snackBar.open(message, '', {
      duration: duration ? duration : 3000,
      horizontalPosition: "right",
      verticalPosition: "top"
    })
  }
}