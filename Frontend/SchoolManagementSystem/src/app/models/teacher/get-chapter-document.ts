export interface IGetChapterDocument {
  documentId: number;
  documentContent: string;
  courseId: number | null;
  useDocumentFor: string;
}
