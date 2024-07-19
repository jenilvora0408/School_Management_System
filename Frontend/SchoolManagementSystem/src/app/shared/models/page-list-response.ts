export interface IPageListResponse<T> {
  pageIndex: number;
  pageSize: number;
  totalRecords: number;
  records: T;
}
