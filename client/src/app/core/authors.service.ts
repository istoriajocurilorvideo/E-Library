import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable()
export class AuthorsService {

  constructor(private httpClient: HttpClient) { }
  private formatErrors(error: any) {
    return throwError(error.error);
  }

  getAuthors() {
    var path = "/BookAuthors/GetAll";
    return this.httpClient.get(`${environment.api_url}${path}`)
      .pipe(map((data: any) => data as Array<any>))
      .pipe(catchError(this.formatErrors));
  }

  getAuthor(id: number) {
    var path = "/BookAuthors/Get";
    return this.httpClient.get(`${environment.api_url}${path}?id=${id}`)
      .pipe(map((data: any) => data as Array<any>))
      .pipe(catchError(this.formatErrors));
  }

  getBooksCount() {
    var path = "/BookAuthors/GetSummary";
    return this.httpClient.get(`${environment.api_url}${path}`)
      .pipe(map((data: any) => data as Array<any>))
      .pipe(catchError(this.formatErrors));
  }

  createAuthor(name: string) {
    var path = "/BookAuthors/Create";
    return this.httpClient.post(
      `${environment.api_url}${path}`, { name: name }
    ).pipe(catchError(this.formatErrors));
  }

  updateAuthor(id: number, name: string) {
    var path = "/BookAuthors/Update";
    return this.httpClient.post(
      `${environment.api_url}${path}`, { id: id, name: name }
    ).pipe(catchError(this.formatErrors));
  }

  deleteAuthor(id: number) {
    var path = "/BookAuthors/Delete";
    return this.httpClient.delete(
      `${environment.api_url}${path}?id=${id}`
    ).pipe(catchError(this.formatErrors));
  }
}
