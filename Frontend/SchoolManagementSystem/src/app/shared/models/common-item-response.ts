export interface CommonItemResponse {
  id: number;
  title: string;
}

export interface CommonListResponse {
  data: {
    listOfGenders: CommonItemResponse[];
    listOfBloodGroups: CommonItemResponse[];
    listOfClasses: CommonItemResponse[];
    listOfMediums: CommonItemResponse[];
  };
}
