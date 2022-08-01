import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appSelect]'
})
export class SelectDirective {

  constructor(private el: ElementRef) {
    this.el.nativeElement.class = "form-control";
   }
}
