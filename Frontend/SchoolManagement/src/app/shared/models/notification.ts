export interface NotificationResult {
  id: number;
  sentBy: number;
  sendTo: number;
  notificationMessage: string;
  hasRead: boolean;
  time: string;
  isTempDeleted: boolean;
  createdOn: string;
}
