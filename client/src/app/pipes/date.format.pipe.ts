import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({
  name: 'dateFormatPipe',
})
export class dateFormatPipe implements PipeTransform {
  transform(value: string) {
    return new DatePipe("en-US").transform(value, 'MMM-dd-yyyy');
  }
}
