import { NotificationType } from '../../constants/notification/notification-type';

export interface IMessage {
  type: NotificationType;
  message: string;
  title?: string;
}
