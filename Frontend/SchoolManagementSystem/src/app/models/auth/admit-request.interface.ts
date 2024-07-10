export interface IAdmitRequestInterface {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  address: string;
  dateOfBirth?: Date;
  genderId: string;
  bloodGroupId: string;
  admitRequestRoleId: string;
  classId: string;
  mediumId: string;
  avatar?: string;
}
