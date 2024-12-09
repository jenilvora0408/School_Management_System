import { ISubjectTeacherAssignedClassInterface } from "./subject-teacher-assigned-class";

export interface    ISubjectTeacherInfoInterface {
  teacherName: string;
  subjectId: number;
  subjectName: string;
  subjectTeacherAssignedClasses: ISubjectTeacherAssignedClassInterface[];
}
