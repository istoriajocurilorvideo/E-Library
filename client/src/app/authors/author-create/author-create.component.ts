import { Component, OnInit } from '@angular/core';
import { AuthorsService } from 'src/app/core/authors.service';
import { ConfirmationService, MessageService } from 'primeng/api';

@Component({
  selector: 'app-author-create',
  templateUrl: './author-create.component.html',
  styleUrls: ['./author-create.component.css']
})
export class AuthorCreateComponent implements OnInit {

  constructor(private authorsService: AuthorsService, private confirmationService: ConfirmationService, private messageService: MessageService) { }

  ngOnInit(): void {
  }

  public createAuthor() {

    this.authorsService.createAuthor((document.getElementById('authorName') as HTMLInputElement).value).subscribe(
      res => {
        this.messageService.add({ severity: 'success', summary: 'SUCCESS', detail: 'Author was succesfully created!' });
      }
    )
  };

}
