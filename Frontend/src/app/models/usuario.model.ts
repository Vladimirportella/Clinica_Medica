export interface UsuarioModel {
  idUsuario: number;
  nome : string;
  matricula: string;
  email: string;
  senha: string;
  senhaConfirmacao: string;
  idTipo: number;
  ativo: boolean;
}
