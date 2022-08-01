import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MultiSelectModule } from 'primeng/multiselect';

import { AuthorsService } from './authors.service';
import { GenresService } from './genres.service';
import { BooksService } from './books.service';
import { BookFilesService } from './bookfiles.service';

import { AuthorListComponent } from '../authors/author-list/author-list.component';
import { AuthorCreateComponent } from '../authors/author-create/author-create.component';
import { GenresComponent } from '../genres/genres.component';

import { JoinPipe } from '../pipes/array.join.pipe';
import { SelectDirective } from '../select.directive';
import { AuthInterceptor, httpInterceptorProviders } from '../auth/auth.interceptor';
import { AuthLoginComponent } from '../auth/auth-login/auth-login.component';
import { AuthService } from '../auth/auth.service';

import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { AuthGuard } from '../auth/auth.guard';
@NgModule({
  providers: [
    AuthorsService,
    BookFilesService,
    GenresService,
    BooksService,
    AuthService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService,
    AuthGuard,
    httpInterceptorProviders
  ],
  declarations: [
    AuthorListComponent,
    AuthorCreateComponent,
    GenresComponent,
    AuthLoginComponent,
    JoinPipe,
    SelectDirective
  ],
  imports: [
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MultiSelectModule
  ],
  exports: [
    JoinPipe
  ]
})
export class CoreModule { }
