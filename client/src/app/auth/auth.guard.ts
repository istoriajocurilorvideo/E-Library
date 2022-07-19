import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import decode from 'jwt-decode';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(public auth: AuthService, public router: Router) { }
    canActivate(route: ActivatedRouteSnapshot): boolean {

        const expectedRole = route.data['expectedRole'];
        const token = this.auth.getAuthorizationToken();

        if (token == null) {
            this.router.navigate(['login']);
            return false;
        }

        const tokenPayload: any = decode(token);
        if (tokenPayload.role !== expectedRole) {
            this.router.navigate(['login']);
            return false;
        }

        return true;
    }
}