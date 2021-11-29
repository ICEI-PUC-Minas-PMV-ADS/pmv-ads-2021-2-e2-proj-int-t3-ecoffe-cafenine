import { Cartao } from './cartao.model';
import { Endereco } from './endereco.model';
import { ProdutoCompra } from './../helpers/produtoCompra.model';

export interface Compra {
    id: number;
    usuarioId: number;
    dataCompra: Date;
    statusCompra: StatusCompra; 
    produtosCompraIdList: number[];
    produtos?: ProdutoCompra[];
    enderecoId: number;
    endereco?: Endereco;
    formaPagamento: FormaPagamento;
    cartaoId?: number,
    cartao?: Cartao,
    valorBruto: number;
    parcelas: number;
    valorParcela: number;
}

export enum FormaPagamento {
    Debito = 0,
    Credito = 1,
    Boleto = 2,
    PIX = 3
}

export const FormaPagamentoLabel = new Map<number, string>([
    [FormaPagamento.Debito, 'Débito'],
    [FormaPagamento.Credito, 'Crédito'],
    [FormaPagamento.Boleto, 'Boleto'],
    [FormaPagamento.PIX, 'PIX']
]);

export enum StatusCompra {
    WaitPayment = 0,
    ConfirmedPayment = 1,
    InPackage = 2,
    Send = 3,
    Delivering = 4,
    Finished = 5
}

export const StatusCompraLabel = new Map<number, string>([
   [StatusCompra.WaitPayment, 'Aguardando pagamento'], 
   [StatusCompra.ConfirmedPayment, 'Pagamento confirmado'], 
   [StatusCompra.InPackage, 'Empacotamento'], 
   [StatusCompra.Send, 'Enviado'], 
   [StatusCompra.Delivering, 'Em rota de entrega'], 
   [StatusCompra.Finished, 'Finalizado']
]);