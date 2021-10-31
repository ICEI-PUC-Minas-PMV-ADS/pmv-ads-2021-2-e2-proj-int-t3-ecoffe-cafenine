import { Cartao } from './cartao.model';
import { Endereco } from './endereco.model';

export interface Usuario {
    id?: number;
    nome: string;
    cpf: string;
    senha: string;
    email: string;
    endereco: Endereco;
    cartao: Cartao;
    telefone: string;
    ativo: boolean;
    admin: boolean;
}

