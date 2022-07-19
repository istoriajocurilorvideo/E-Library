import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MultiSelectModule } from 'primeng/multiselect';

import { AuthorsService } from './authors.service';
import { GenresService } from './genres.service';
import { BooksService } from './books.service';
import { BookFilesService } from './bookfiles.service';

import { AuthLoginComponent } from '../auth/auth-login/auth-login.component';
import { AuthService } from '../auth/auth.service';

@NgModule({
  providers: [
    AuthorsService,
    BookFilesService,
    GenresService,
    BooksService,
  ],
  declarations: [
    AuthLoginComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MultiSelectModule
  ]
})
export class CoreModule { }
