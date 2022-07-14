import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable()
export class BooksService {

  constructor(private httpClient: HttpClient) { }
  private formatErrors(error: any) {
    return throwError(() => new Error(error.error));
  }

  getBooks() {
    var path = "/Books/GetAll";
    return this.httpClient.get(`${environment.api_url}${path}`)
      .pipe(map((data: any) => data as Array<any>))
      .pipe(catchError(this.formatErrors));
  }

  getBook(id: number) {
    var path = "/Books/Get";
    return this.httpClient.get(`${environment.api_url}${path}?id=${id}`)
      .pipe(map((data: any) => data as Array<any>))
      .pipe(catchError(this.formatErrors));
  }

  createBook(book: any) {
    var path = "/Books/Create";
    return this.httpClient.post(
        `${environment.api_url}${path}`, {
        isbn: book.isbn,
        title: book.title,
        intro: book.intro,
        description: book.description,
        genres: book.genres,
        authors: book.authors
      })
      .pipe(map((data: any) => data as any))
      .pipe(catchError(this.formatErrors));
  }

  updateBook(book: any) {
    var path = "/Books/Update";
    return this.httpClient.post(
      `${environment.api_url}${path}`, {
      id: book.id,
      isbn: book.isbn,
      title: book.title,
      intro: book.intro,
      description: book.description,
      genres: book.genres,
      authors: book.authors
    }
    ).pipe(catchError(this.formatErrors));
  }

  deleteBook(id: number) {
    var path = "/Books/Delete";
    return this.httpClient.delete(
      `${environment.api_url}${path}?id=${id}`
    ).pipe(catchError(this.formatErrors));
  }
}
