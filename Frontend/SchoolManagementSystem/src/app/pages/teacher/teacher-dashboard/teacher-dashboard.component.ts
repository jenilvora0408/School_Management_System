import { Component } from '@angular/core';
import {
  NgbDropdownModule,
  NgbHighlight,
  NgbPaginationModule,
  NgbTypeaheadModule,
} from '@ng-bootstrap/ng-bootstrap';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { IAdmitRequestListInterface } from '../../../models/teacher/admit-request-list';
import { InputComponent } from '../../../shared/components/input/input.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@Component({
  selector: 'app-teacher-dashboard',
  standalone: true,
  imports: [
    NgbDropdownModule,
    HeaderComponent,
    InputComponent,
    NgbPaginationModule,
    NgbTypeaheadModule,
    NgbHighlight,
    ReactiveFormsModule,
    FormsModule,
  ],
  templateUrl: './teacher-dashboard.component.html',
  styleUrl: './teacher-dashboard.component.scss',
})
export class TeacherDashboardComponent {
  admitRequestsData: IAdmitRequestListInterface[] = [
    {
      name: 'Jenil Vora',
      email: 'jenilvora@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
    {
      name: 'Nikhil Vaya',
      email: 'nikhilvaya@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
    {
      name: 'Rishit Kundariya',
      email: 'rishit@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
    {
      name: 'Rahul Kumbharvadiya',
      email: 'rahul@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
    {
      name: 'Neha Manani',
      email: 'neha@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
    {
      name: 'Suraj Parmar',
      email: 'suraj@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
    {
      name: 'Om Bhalala',
      email: 'om@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
    {
      name: 'Dhruvik Patel',
      email: 'dhruvik@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
    {
      name: 'Urmi Boda',
      email: 'urmi@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
    {
      name: 'Harsh Kadivar',
      email: 'harsh@gmail.com',
      className: 'class-11',
      requestedRole: 'Teacher',
    },
  ];
  page = 1;
  pageSize = 10;
  collectionSize = this.admitRequestsData.length;
  requestData: IAdmitRequestListInterface[] = [];
  constructor() {}

  ngOnInit(): void {
    this.refreshDataSource();
  }

  search() {}

  refreshDataSource() {
    this.requestData = this.admitRequestsData
      .map((item, i) => ({
        id: i + 1,
        ...item,
      }))
      .slice(
        (this.page - 1) * this.pageSize,
        (this.page - 1) * this.pageSize + this.pageSize
      );
  }
}
