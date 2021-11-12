export interface Cartao {
    id: number;
    numero: string;
    vencimento: Date;
    dataAdicao: Date;
    nomeTitular: string;
    cpfTitular: string;
    bandeira: string;
    csv: string;
    tipoCartao: TipoCartao;
    principal: boolean;
}

export enum TipoCartao {
    debito = 0,
    credito = 1
  }