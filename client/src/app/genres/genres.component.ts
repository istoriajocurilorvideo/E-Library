import { Component, Input, OnInit, Output } from '@angular/core';
import { GenresService } from 'src/app/core/genres.service';
import { ConfirmationService, MessageService, Message } from 'primeng/api';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})

export class GenresComponent implements OnInit {
  public genres: any[] | undefined;
  public selectedGenre: any; 
  public selectedGenreCopy: any;
  public displayEditDialog: boolean | undefined;
  public displayCreateDialog: boolean | undefined;

  constructor(private modalService: NgbModal, private genresService: GenresService, private confirmationService: ConfirmationService, private messageService: MessageService) { }

  ngOnInit(): void {
    this.getGenres();
  }

  public getGenres() {
    this.genresService.getGenres().subscribe(
      res => {
        this.genres = res;
      });
  }

  public updateGenre() {

    this.genresService.updateGenre(this.selectedGenre.id, this.selectedGenre.name).subscribe(
      res => {
        if (res) {
          this.messageService.add({ severity: 'success', summary: 'SUCCESS', detail: 'Genre was succesfully updated!' });
          this.selectedGenre = null;
        }
        return res;
      }
    )
  };

  public showCreateDialog(modal: any){
    this.modalService.open(modal, {ariaLabelledBy: 'modal-basic-title'});
  }

  public createGenre() {

    this.genresService.createGenre((document.getElementById('genreName') as HTMLInputElement).value).subscribe(
      res => {
          this.messageService.add({ severity: 'success', summary: 'SUCCESS', detail: 'Genre was succesfully created!' });
          this.modalService.dismissAll();
          this.getGenres();
      }
    )
  };

  public deleteGenre(genre: any) {
    this.confirmationService.confirm({
      message: 'Are you sure that you want to delete this genre?',
      accept: () => {
        this.genresService.deleteGenre(genre.id).subscribe(res => {
          this.getGenres();
          this.messageService.add({ severity: 'success', summary: 'SUCCESS', detail: 'Genre was succesfully deleted!' });
        });
      },
      reject: () => {
      }
    });
  }

  public showUpdateGenreDialog(genre: any) {
    this.selectedGenre = genre;
    this.displayCreateDialog  = false;
    this.displayEditDialog = true;
  }

  public hideUpdateAuthorDialog() {
    this.displayEditDialog = false;
    this.selectedGenre = this.selectedGenreCopy;
  }

  public onSelect(genre: any) {
    this.selectedGenre = genre;
  }
}
