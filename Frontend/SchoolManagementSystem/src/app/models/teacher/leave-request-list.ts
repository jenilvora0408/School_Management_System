export interface ILeaveRequestListInterface {
  id: number;
  reasonForLeave: string;
  startDate: Date;
  endDate: Date;
  leaveDuration: number;
  leaveType: string;
  approvalStatus: number;
  phoneNumber: string;
  alternatePhoneNumber: string;
}
