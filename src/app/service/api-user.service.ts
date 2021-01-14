import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';

import { IAuth } from './../models/IAuth';
import { IUserResponse } from '../models/IAuth';
import { IResponse } from './../models/IResponse';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ApiUserService {
  private _userSubject: BehaviorSubject<IUserResponse>;
  public user: Observable<IUserResponse>;

  constructor(private _http: HttpClient) {
    this._userSubject = new BehaviorSubject<IUserResponse>(
      JSON.parse(localStorage.getItem('user'))
    );

    this.user = this._userSubject.asObservable();
  }

  login(user: IAuth): Observable<IResponse<IUserResponse>> {
    return this._http
      .post<IResponse<IUserResponse>>(
        `${environment.endpoint.user}/authenticate`,
        user,
        environment.httpOptions
      )
      .pipe(
        map((res) => {
          if (res.result) {
            const user: IUserResponse = res.data;
            localStorage.setItem('user', JSON.stringify(user));
            this._userSubject.next(user);
          }

          return res;
        })
      );
  }

  signup(user: IAuth) {
    return this._http
      .post<IResponse<IUserResponse>>(
        `${environment.endpoint.user}/signUp`,
        user,
        environment.httpOptions
      )
      .pipe(
        map((res) => {
          if (res.result) {
            const user: IUserResponse = res.data;
            localStorage.setItem('user', JSON.stringify(user));
            this._userSubject.next(user);
          }

          return res;
        })
      );
  }

  get userData(): IUserResponse {
    return this._userSubject.value;
  }

  logout() {
    localStorage.removeItem('user');
    this._userSubject.next(null);
  }
}
