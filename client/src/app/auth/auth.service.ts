import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, map } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable()
export class AuthService {

    constructor(private httpClient: HttpClient, private router: Router, public jwtHelper: JwtHelperService) {

    }

    public authenticated(): boolean {
        const token = this.getAuthorizationToken();

        if (token == null)
            return false;

        return !this.jwtHelper.isTokenExpired(token);
    }

    public getAuthorizationToken() {
        return localStorage.getItem('token');
    }

    public login(email: string, password: string) {
        var path = "/Users/Login";
        this.httpClient.post(
            `${environment.api_url}${path}`, { email: email, password: password }
        ).pipe(map((data: any) => data as any)).subscribe(rez => {
            if (rez.token != null && rez.token != '') {
                localStorage.setItem('token', rez.token);
                this.router.navigateByUrl('/');
            }
        });
    }
}


