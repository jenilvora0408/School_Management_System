import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SystemConstants } from '../../../constants/shared/system-constants';
import * as CryptoJS from 'crypto-js';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-class',
  standalone: true,
  imports: [HeaderComponent],
  templateUrl: './edit-class.component.html',
  styleUrl: './edit-class.component.scss',
})
export class EditClassComponent {
  classId: number = 0;

  editClassForm = new FormGroup({
    classId: new FormControl(0, Validators.required),
    className: new FormControl(
      '',
      Validators.compose([Validators.required, Validators.minLength(7)])
    ),
    classTeacherId: new FormControl(0, Validators.required),
  });

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      this.classId = parseInt(
        CryptoJS.AES.decrypt(
          params['classId'],
          SystemConstants.EncryptionKey
        ).toString(CryptoJS.enc.Utf8)
      );
    });

    console.log(this.classId);
  }
}
