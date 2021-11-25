import { Cartao } from './cartao.model';
import { Endereco } from './endereco.model';

export interface Usuario {
    id: number;
    nome: string;
    cpf: string;
    senha: string;
    email: string;
    enderecoId?: number;
    endereco?: Endereco;
    telefone: string;
    ativo: boolean;
    admin: boolean;
}

export interface LoginUsuario {
    emailCpf: string;
    senha: string;
}

