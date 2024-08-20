import { NgClass } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-leave-status',
  standalone: true,
  imports: [NgClass],
  templateUrl: './leave-status.component.html',
  styleUrl: './leave-status.component.scss',
})
export class LeaveStatusComponent {
  @Input() count: number = 0;
  @Input() label: string = '';
  @Input() iconClass: string = '';
  @Input() isActive: boolean = false;
  @Output() statusClicked: EventEmitter<void> = new EventEmitter<void>();

  onClick(): void {
    this.statusClicked.emit();
  }
}
