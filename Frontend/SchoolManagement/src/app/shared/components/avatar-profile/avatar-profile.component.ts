import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { profileImage } from 'src/app/constants/profile-image/profile-image';
import { GenderType } from 'src/app/constants/shared/gender-type';
import { Base64ToImagePipe } from 'src/app/pipes/base64-to-image.pipe';

@Component({
  selector: 'app-avatar-profile',
  templateUrl: './avatar-profile.component.html',
  styleUrls: ['./avatar-profile.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AvatarProfileComponent implements OnInit {

  public base64ToImagePipe = new Base64ToImagePipe();

  @Input()
  avatar: string | null = null;

  @Input()

  avatarAlt: string = '';

  @Input()
  class: string = '';

  @Input()
  username: string = '';

  @Input()
  gender?: GenderType;

  public ngOnInit(): void {
    if (this.avatar && this.avatar !== '') {
      this.avatar = this.base64ToImagePipe.transform(this.avatar);
      return;
    };

    if (this.gender) {
      this.avatar = this.gender === GenderType.Male
        ? profileImage.gridMaleProfile
        : profileImage.gridFemaleProfile;
    } else {
      this.avatar = profileImage.gridMaleProfile;
    }
  }
}
