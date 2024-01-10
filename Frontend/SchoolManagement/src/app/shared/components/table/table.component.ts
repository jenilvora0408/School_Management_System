import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Dropdown } from '../../models/dropdown';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent {
  @Input() columns: string[] = [];
  @Input() data: any;
  @Input() dropDownList: Dropdown[][] = [];
  @Input() openPatientDetailDialog: boolean = false;
  @Output() dropDownItemClick = new EventEmitter<Dropdown>();
  @Output() dataItemOfDropdownClick = new EventEmitter<any>();
  @Output() edit = new EventEmitter<any>();
  @Output() delete = new EventEmitter<any>();
  @Output() id = new EventEmitter<number>();

  dropDownClick(dropDown: Dropdown, dataItem: any): void {
    this.dropDownItemClick.emit(dropDown);
    this.dataItemOfDropdownClick.emit({ dropDown, dataItem });
  }

  public columnDictionary: { [key: string]: string } = {
    Test: 'testTitle',
    Phone: 'phoneNumber',
    'Expected Result Date': 'expectedDate',
    'Next Step': 'nextStep',
  };

  editData(item: any) {
    this.edit.emit(item);
  }

  deleteData(item: any) {
    this.delete.emit({ id: item.id, name: item.name });
  }
  openPatientDialogBox(id: number) {
    this.id.emit(id);
  }
}
