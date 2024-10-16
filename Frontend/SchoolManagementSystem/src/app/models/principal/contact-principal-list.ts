export interface IContactPrincipalListInterface {
    contactPrincipalId: number;
    userId: number;
    userName: string;
    subject: string;
    description: string;
    type: number;
    contactTypeTitle: string;
    requestDate: Date;
    relatableEvidence: string;
    isResolved: boolean;
    responseMessage: string;
  }
  