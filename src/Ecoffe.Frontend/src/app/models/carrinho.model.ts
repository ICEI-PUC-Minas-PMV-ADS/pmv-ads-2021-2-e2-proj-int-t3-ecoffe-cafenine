import { ProdutoCarrinho } from './../helpers/produtoCarrinho.model';

export interface Carrinho {
    id: number,
    produtos: ProdutoCarrinho[]
}

