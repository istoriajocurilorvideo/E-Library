import { Component, Input, OnInit, Output } from '@angular/core';
import { AuthorsService } from 'src/app/core/authors.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css']
})

export class AuthorListComponent implements OnInit {
  public authors: any[] | undefined;
  public selectedAuthor: any; 
  public selectedAuthorCopy: any;
  public displayEditDialog: boolean | undefined;
  public displayCreateDialog: boolean | undefined;

  constructor(private modalService: NgbModal, private authorsService: AuthorsService, private confirmationService: ConfirmationService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.getAuthors();
  }

  public getAuthors() {
    this.authorsService.getAuthors().subscribe(
      res => {
        this.authors = res;
      });
  }

  public updateAuthor() {

    this.authorsService.updateAuthor(this.selectedAuthor.id, this.selectedAuthor.name).subscribe(
      res => {
        if (res) {
          this.messageService.add({ severity: 'success', summary: 'SUCCESS', detail: 'Author was succesfully updated!' });
        }
        return res;
      }
    )
  };

  public showCreateDialog(modal: any){
    this.modalService.open(modal, {ariaLabelledBy: 'modal-basic-title'});
  }

  public createAuthor() {

    this.authorsService.createAuthor((document.getElementById('authorName') as HTMLInputElement).value).subscribe(
      res => {
          this.messageService.add({ severity: 'success', summary: 'SUCCESS', detail: 'Author was succesfully created!' });
          this.modalService.dismissAll();
          this.getAuthors();
      }
    )
  };

  public deleteAuthor(author: any) {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to delete this author?',
      accept: () => {
        this.authorsService.deleteAuthor(author.id).subscribe(res => {
          this.getAuthors();
          this.messageService.add({ severity: 'success', summary: 'SUCCESS', detail: 'Author was succesfully deleted!' });
        });
      },
      reject: () => {
      }
    });
  }

  public showUpdateAuthorDialog(author: any) {
    this.selectedAuthor = author;
    this.displayCreateDialog  = false;
    this.displayEditDialog = true;
  }

  public hideUpdateAuthorDialog() {
    this.displayEditDialog = false;
    this.selectedAuthor = this.selectedAuthorCopy;
  }

  public onSelect(author: any) {
    this.selectedAuthor = author;
  }
}
