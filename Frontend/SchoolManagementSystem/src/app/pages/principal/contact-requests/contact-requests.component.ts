import { Component } from '@angular/core';
import { HeaderComponent } from '../../../shared/components/header/header.component';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-contact-requests',
  standalone: true,
  imports: [HeaderComponent, NgClass],
  templateUrl: './contact-requests.component.html',
  styleUrl: './contact-requests.component.scss'
})
export class ContactRequestsComponent {
  filters = ['All', 'Harassment', 'Awareness', 'Notice', 'External Help', 'Other'];
  selectedFilter: string | null = null;
  selectedTagline: string = 'Attend each request carefully & answer them at earliest!';
  taglines: { [key: string]: string } = {
    'All': 'Attend each request carefully & answer them at earliest!',
    'Harassment': 'Take reasonable actions & neutralize the situation immediately!',
    'Awareness': 'The requests below want to bring your attention towards unknown or unattended matters!',
    'Notice': 'The requests wants you to take note of something significant!',
    'External Help': 'Contact legal authorities in case of any actions required; Ensure proper well-being of all individuals at any cost!',
    'Other': 'General requests or inquiries'
  };

  onFilterSelect(filter: string) {
    if (this.selectedFilter === filter) return;
    this.selectedFilter = filter;
    this.selectedTagline = this.taglines[filter];
  }

  clearFilter(event: Event) {
    event.stopPropagation();
    this.selectedFilter = null;
    this.selectedTagline = this.taglines['All'];
  }
}
