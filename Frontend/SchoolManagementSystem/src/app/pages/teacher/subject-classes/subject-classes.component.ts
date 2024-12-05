import { Component } from '@angular/core';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ISubjectTeacherInfoInterface } from '../../../models/teacher/subject-teacher-info';
import { AuthenticationService } from '../../../services/authentication.service';
import { Router } from '@angular/router';
import { RoutingPathConstant } from '../../../constants/routing/routing-path';

@Component({
  selector: 'app-subject-classes',
  standalone: true,
  imports: [HeaderComponent, ButtonComponent],
  templateUrl: './subject-classes.component.html',
  styleUrl: './subject-classes.component.scss',
})
export class SubjectClassesComponent {
  responseData: ISubjectTeacherInfoInterface={
    subjectName: '',
    subjectId: 0,
    subjectTeacherAssignedClasses: [],
    teacherName: '',
  };
  userId: number = 0;

  constructor(private authService: AuthenticationService, private router: Router) {}

  ngOnInit(): void {
    this.userId = this.authService.getUserId();
  }

  // getAllClassesInfo() {
  //   this.commonService.getAllClassesInfo().subscribe({
  //     next: (response: IResponse<IClassListResponseInterface[]>) => {
  //       console.log('common classes: ', response);
  //       this.responseData = response.data;
  //     },
  //     error: (error: HttpErrorResponse) => {
  //       this.notificationService.error(error.error.errors);
  //       console.log(error);
  //     },
  //   });
  // }

  viewChapters(): void {}

  navigateBack(): void {
    this.router.navigate([RoutingPathConstant.teacherDashboardUrl])
  }
}
