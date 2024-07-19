export interface IPageListRequest {
  pageIndex: number;
  pageSize: number;
  sortOrder: string;
  sortColumn: string;
  searchQuery: string;
}
