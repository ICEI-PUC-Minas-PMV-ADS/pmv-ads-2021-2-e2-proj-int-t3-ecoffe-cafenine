export interface Produto {
    id: number;
    nome: string;
    peso: number;
    altura: number;
    largura: number;
    comprimento: number;
    valor: number;
}

export enum Categoria {
    consumo = 0,
    utilitario = 1
  }