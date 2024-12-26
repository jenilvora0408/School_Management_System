import { IDocumentUploadInterface } from "./document-upload";

export interface IAddChapterDocumentInterface{
    courseId: number;
    documentDTOs: IDocumentUploadInterface[];
}