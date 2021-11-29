import { Produto } from './../models/produto.model';
export interface ProdutoCarrinho{
    id: number,
    usuarioId: number,
    produtoId: number,
    quantidade: number,
    valorTotal: number,
    produto: Produto
  }
  