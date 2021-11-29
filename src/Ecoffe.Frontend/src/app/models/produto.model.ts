export interface Produto {
    //    content: any[];
        id: number;
        nome: string;
        peso: number;
        altura: number;
        largura: number;
        comprimento: number;
        valor: number;
        categoria: Categoria;
    }
    
    export enum Categoria {
        consumo = 0,
        utilitario = 1
      }