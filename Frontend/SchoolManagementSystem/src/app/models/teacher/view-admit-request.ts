export interface IViewAdmitRequestInterface {
  id: number;
  name: string;
  email: string;
  phoneNumber: string;
  address: string;
  dateOfBirth: string;
  genderTitle: string;
  avatar: string;
  bloodGroupTitle: string;
  requestedRoleTitle: string;
  className: string;
  mediumTitle: string;
  approvalStatus: number;
  comment: string;
  approvedByName: string;
  declinedByName: string;
  blockedByName: string;
}
