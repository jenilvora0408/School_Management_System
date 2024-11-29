import { ICourseListForClassSubjectInterface } from "./course-list-for-class-subject";

export interface ISubmitCourseInfo {
    classSubjectId: number;
    addChaptersDTO : ICourseListForClassSubjectInterface[];
  }
  