export interface IAuth {
  email: string;
  password: string;
}

export interface IUserResponse {
  idUser: number;
  email: string;
  token: string;
}
