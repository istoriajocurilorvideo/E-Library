import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    NgbModule,
    CommonModule,
    FormsModule,
    ConfirmDialogModule,
    MessageModule,
    MessagesModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
