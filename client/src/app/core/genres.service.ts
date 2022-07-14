import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable()
export class GenresService {

  constructor(private httpClient: HttpClient) { }
  private formatErrors(error: any) {
    return throwError(error.error);
  }

  getGenres() {
    var path = "/BookGenres/GetAll";
    return this.httpClient.get(`${environment.api_url}${path}`)
      .pipe(map((data: any) => data as Array<any>))
      .pipe(catchError(this.formatErrors));
  }

  getGenre(id: number) {
    var path = "/BookGenres/Get";
    return this.httpClient.get(`${environment.api_url}${path}?id=${id}`)
      .pipe(map((data: any) => data as any))
      .pipe(catchError(this.formatErrors));
  }

  getGenresCount() {
    var path = "/BookGenres/GetSummary";
    return this.httpClient.get(`${environment.api_url}${path}`)
      .pipe(map((data: any) => data as Array<any>))
      .pipe(catchError(this.formatErrors));
  }

  createGenre(name: string) {
    var path = "/BookGenres/Create";
    return this.httpClient.post(
      `${environment.api_url}${path}`, { name: name }
    ).pipe(catchError(this.formatErrors));
  }

  updateGenre(id: number, name: string) {
    var path = "/BookGenres/Update";
    return this.httpClient.post(
      `${environment.api_url}${path}`, { id: id, name: name }
    ).pipe(catchError(this.formatErrors));
  }

  deleteGenre(id: number) {
    var path = "/BookGenres/Delete";
    return this.httpClient.delete(
      `${environment.api_url}${path}?id=${id}`
    ).pipe(catchError(this.formatErrors));
  }
}
