import { NotificationType } from 'src/app/constants/shared/notification-type';

export interface IMessage {
  type: NotificationType;
  message: string;
  title?: string;
}
