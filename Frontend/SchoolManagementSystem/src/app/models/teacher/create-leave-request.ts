export interface ICreateLeaveRequestInterface {
  leaveRequestorId: number;
  reasonForLeave: string;
  startDate: Date;
  endDate: Date;
  leaveDuration: string;
  leaveType: string;
  alternatePhoneNumber: string | null;
}
