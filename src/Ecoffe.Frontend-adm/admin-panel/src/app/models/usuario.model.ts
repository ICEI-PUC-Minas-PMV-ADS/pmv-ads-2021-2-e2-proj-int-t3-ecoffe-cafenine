import { Endereco } from "./endereco.model";

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