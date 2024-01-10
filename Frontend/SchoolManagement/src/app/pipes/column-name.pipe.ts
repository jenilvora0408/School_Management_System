import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'columnName',
})
export class ColumnNamePipe implements PipeTransform {
  transform(value: string, separator: string = ' '): string {
    if (!value) {
      return '';
    }

    return value
      .split('')
      .map((char, index) => {
        if (index === 0) {
          return char.toUpperCase();
        } else if (char >= 'A' && char <= 'Z') {
          return separator + char;
        } else {
          return char;
        }
      })
      .join('')
      .trim();
  }
}
