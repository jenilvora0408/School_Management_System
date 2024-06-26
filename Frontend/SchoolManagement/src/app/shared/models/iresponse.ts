export interface IResponse<T> {
  message: string;
  success: boolean;
  errors: string[];
  data: T;
  statusCode: number;
}
