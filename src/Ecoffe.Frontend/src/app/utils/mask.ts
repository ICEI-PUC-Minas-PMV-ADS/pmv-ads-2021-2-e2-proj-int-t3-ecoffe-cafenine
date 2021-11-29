import { StatusCompraLabel } from './../models/compra.model';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({name: 'hideCardNumber'})
export class HideCardNumberPipe implements PipeTransform {
  transform(cardNumber: string): string {
    return cardNumber.replace(/\d{12}/, "****.****.****.");
  }
}

@Pipe({name: 'cardType'})
export class CardTypePipe implements PipeTransform {
  transform(type: number): string{
    if(type == 0)
      return 'Débito';
    else
      return 'Crédito'
  }
}