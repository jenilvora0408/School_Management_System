export interface IUserPageListRequest {
  pageIndex: number;
  pageSize: number;
  sortOrder: string;
  sortColumn: string;
  searchQuery: string;
  filter: Number;
  userId: Number;
}
