import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { ButtonComponent } from '../../../shared/components/button/button.component';
import { debounceTime, Subject } from 'rxjs';
import { NgClass } from '@angular/common';
import { SystemConstants } from '../../../constants/shared/system-constants';

@Component({
  selector: 'app-leave-dashboard',
  standalone: true,
  imports: [HeaderComponent, ButtonComponent, NgClass],
  templateUrl: './leave-dashboard.component.html',
  styleUrl: './leave-dashboard.component.scss',
})
export class LeaveDashboardComponent {
  private searchSubject = new Subject<string>();
  searchQuery: string = '';
  sortColumn: string = 'FirstName';
  sortOrder: string = 'ascending';

  constructor() {}

  ngOnInit(): void {
    this.searchSubject.pipe(debounceTime(1000)).subscribe((searchTerm) => {
      this.search(searchTerm);
    });
  }

  onKeyup(searchTerm: string) {
    this.searchSubject.next(searchTerm);
  }

  search(searchTerm: string) {
    this.searchQuery = searchTerm;
  }

  onSort(column: string) {
    console.log('SORT: ', this.sortColumn, this.sortOrder);

    if (this.sortColumn === column) {
      this.sortOrder =
        this.sortOrder === SystemConstants.Ascending
          ? SystemConstants.Descending
          : SystemConstants.Ascending;
    } else {
      this.sortColumn = column;
      this.sortOrder = SystemConstants.Ascending;
    }
    console.log('SORT: ', this.sortColumn, this.sortOrder);
  }
}
