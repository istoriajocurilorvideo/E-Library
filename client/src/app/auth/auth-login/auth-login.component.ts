import { Component, Input, OnInit, Output } from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-auth-login',
  templateUrl: './auth-login.component.html',
  styleUrls: ['./auth-login.component.css']
})
export class AuthLoginComponent implements OnInit {

  public email!: string;
  public password!: string;

  constructor(private router: Router, private route: ActivatedRoute, private authService: AuthService, private confirmationService: ConfirmationService, private messageService: MessageService) { }

  ngOnInit() {
    this.email = '';
    this.password = '';
  }

  public login(){
    if(this.email != '' && this.password != '')
    {
      this.authService.login(this.email, this.password);
    }
  }
}
