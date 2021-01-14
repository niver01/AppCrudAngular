import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { IUserResponse } from './models/IAuth';
import { ApiUserService } from './service/api-user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'AppCrud';

  public user: IUserResponse;

  constructor(public _apiUserService: ApiUserService, private _router: Router) {
    this._apiUserService.user.subscribe((res) => {
      this.user = res;
    });
  }

  logout(): void {
    this._apiUserService.logout();
    this._router.navigate(['/login']);
  }
}
