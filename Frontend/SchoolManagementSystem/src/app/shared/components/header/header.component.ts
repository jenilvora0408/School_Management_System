import { Component, inject } from '@angular/core';
import { NgbDropdownModule, NgbOffcanvas } from '@ng-bootstrap/ng-bootstrap';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { AuthenticationService } from '../../../services/authentication.service';
import { Router } from '@angular/router';
import { CommonService } from '../../services/common.service';
import { HttpErrorResponse } from '@angular/common/http';
import { IMyProfileInterface } from '../../../models/common/my-profile';
import { IResponse } from '../../models/IResponse';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [NgbDropdownModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  username: string = '';
  userRole: number = 0;
  userId: number = 0;
  private offCanvasService = inject(NgbOffcanvas);

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private commonService: CommonService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.userRole = parseInt(this.authService.getUserType());
    this.userId = parseInt(this.authService.getUserId());

    this.getProfileDetails();
    
    this.authService.userName$.subscribe((name) => {
      this.getProfileDetails();
    });
  }

  open() {
    const offcanvasRef = this.offCanvasService.open(SidebarComponent);
    offcanvasRef.componentInstance.name = 'Sidenav';
  }

  onLogout() {
    this.authService.logOut();
  }

  navigateProfile() {
    this.router.navigate(['principal/my-profile']);
  }

  getProfileDetails() {
    this.commonService.getMyProfile(this.userId).subscribe({
      next: (response: IResponse<IMyProfileInterface>) => {
        if (response.success) {
          this.username = response.data.firstName + ' ' + response.data.lastName;
        }
      },
      error: (error: HttpErrorResponse) => {
        this.notificationService.error(error.error.errors);
      },
    });
  }
}
