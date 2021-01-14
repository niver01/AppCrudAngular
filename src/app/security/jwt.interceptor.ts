import { Injectable } from '@angular/core';

import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';

import { ApiUserService } from '../service/api-user.service';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private _apiUserService: ApiUserService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const user = this._apiUserService.userData;

    if (user) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${user.token}`,
        },
      });
    }

    return next.handle(req);
  }
}
