import { ILeaveRequestListInterface } from "../teacher/leave-request-list";

export interface ILeaveRequestsInterface {
    userId: number;
    name: string;
    subjectDetails: ILeaveRequestListInterface;
  }
  