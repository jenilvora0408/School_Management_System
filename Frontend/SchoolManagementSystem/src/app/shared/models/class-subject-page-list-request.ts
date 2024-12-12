import { IPageListRequest } from "./page-list-request";

export interface IClassSubjectPageListRequestInterface extends IPageListRequest{
    classId: number;
    subjectId: number;
}