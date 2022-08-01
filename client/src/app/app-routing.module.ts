import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorListComponent } from './authors/author-list/author-list.component';
import { GenresComponent } from './genres/genres.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthLoginComponent } from './auth/auth-login/auth-login.component';

const routes: Routes = [
  { path: 'authors', component: AuthorListComponent },
  { path: 'genres', component: GenresComponent },
  { path: 'login', component: AuthLoginComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }

