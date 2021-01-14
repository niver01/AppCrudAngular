export interface IResponse<T> {
  result: number;
  message: string | any;
  data?: T;
}
