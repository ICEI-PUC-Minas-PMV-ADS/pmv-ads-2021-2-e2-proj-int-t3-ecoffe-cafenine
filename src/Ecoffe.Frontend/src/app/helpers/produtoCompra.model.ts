import { Produto } from './../models/produto.model';
export interface ProdutoCompra{
    id: number,
    usuarioId: number,
    produtoId: number,
    quantidade: number,
    valorTotal: number,
    produto: Produto
}
  