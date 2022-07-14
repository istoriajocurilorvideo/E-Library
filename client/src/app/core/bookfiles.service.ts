import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable()
export class BookFilesService {
  constructor(private httpClient: HttpClient) { }
  private formatErrors(error: any) {
    console.log(error);
    return throwError(error.error);
  }

  updateCover(id: number, cover: FormData) {
    var path = "/Books/UpdateCover";
    return this.httpClient.post(
      `${environment.api_url}${path}?bookId=${id}`, cover
    );
  }

  updateFile(id: number, file: FormData) {
    var path = "/Books/UpdateFile";
    return this.httpClient.post(
      `${environment.api_url}${path}?bookId=${id}`, file
    );
  }

  getFile(id: number) {
    var path = "/Books/GetFile";
    return this.httpClient.get(`${environment.api_url}${path}?bookId=${id}`, { responseType: 'blob' })
      .pipe(catchError(this.formatErrors));
  }

  getCoverUrl(id: number) {
    return  `${environment.api_url}/books/getCover?bookId=${id}`
  }
}
