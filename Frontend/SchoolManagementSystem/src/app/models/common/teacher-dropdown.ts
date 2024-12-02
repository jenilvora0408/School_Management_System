import { ITeachersListInterface } from "../teacher/teachers-list";

export interface ITeacherDropdownInterface extends ITeachersListInterface {
    isAssigned: boolean;
    assignedClassId: number | null;
}
