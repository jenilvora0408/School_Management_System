export interface ILeaveRequestListInterface {
  id: number;
  reasonForLeave: string;
  startDate: Date;
  endDate: Date;
  leaveDuration: number;
  leaveType: string;
  approvalStatus: number;
  alternatePhoneNumber: string;
}
