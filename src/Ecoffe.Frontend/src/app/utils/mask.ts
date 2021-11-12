import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'hideCardNumber'})
export class HideCardNumberPipe implements PipeTransform {
  transform(cardNumber: string): string {
    return cardNumber.replace(/\d{12}/, "****.****.****.");
  }
}
