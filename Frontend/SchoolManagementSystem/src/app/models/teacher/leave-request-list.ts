export interface ILeaveRequestListInterface {
  id: number;
  reasonForLeave: string;
  startDate: Date;
  endDate: Date;
  leaveStartType: string;
  leaveEndType: string;
  leaveDuration: number;
  leaveType: string;
  approvalStatus: number;
}
