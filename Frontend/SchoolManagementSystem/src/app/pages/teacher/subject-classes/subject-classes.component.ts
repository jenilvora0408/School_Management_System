import { Component } from '@angular/core';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ISubjectTeacherInfoInterface } from '../../../models/teacher/subject-teacher-info';
import { AuthenticationService } from '../../../services/authentication.service';
import { Router } from '@angular/router';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';
import { TeacherService } from '../../../services/teacher.service';
import { IResponse } from '../../../shared/models/IResponse';
import { HttpErrorResponse } from '@angular/common/http';
import { NotificationService } from '../../../shared/services/notification.service';

@Component({
  selector: 'app-subject-classes',
  standalone: true,
  imports: [HeaderComponent, ButtonComponent],
  templateUrl: './subject-classes.component.html',
  styleUrl: './subject-classes.component.scss',
})
export class SubjectClassesComponent {
  responseData: ISubjectTeacherInfoInterface = {
    subjectName: '',
    subjectId: 0,
    subjectTeacherAssignedClasses: [],
    teacherName: '',
  };
  userId: number = 0;

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private teacherService: TeacherService,
    private notificationService: NotificationService,
  ) {}

  ngOnInit(): void {
    this.userId = this.authService.getUserId();
    this.getAllClassesInfo();
  }

  getAllClassesInfo() {
    this.teacherService.getClassesForSubjectTeacher(this.userId).subscribe({
      next: (response: IResponse<ISubjectTeacherInfoInterface>) => {
        console.log('response: ', response);
        this.responseData = response.data;
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
        console.log(error);
      },
    });
  }

  viewChapters(): void {}

  navigateBack(): void {
    this.router.navigate([RoutingPathConstant.teacherDashboardUrl]);
  }
}
