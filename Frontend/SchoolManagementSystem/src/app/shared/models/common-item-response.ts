export interface CommonItemResponse {
  id: number;
  title: string;
}

export interface CommonListResponse {
  listOfGenders: CommonItemResponse[];
  listOfBloodGroups: CommonItemResponse[];
  listOfClasses: CommonItemResponse[];
  listOfMediums: CommonItemResponse[];
}
