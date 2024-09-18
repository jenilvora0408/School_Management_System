import { ISubjectsListInterface } from "./subjects-list";

export interface IClassInfoInterface {
    classId: number;
    classStrength: number;
    classTeacherId: number;
    subjectDetails: ISubjectsListInterface[];
  }
  