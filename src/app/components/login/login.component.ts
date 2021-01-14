import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { IAuth } from 'src/app/models/IAuth';

import { ApiUserService } from '../../service/api-user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  public hide: boolean = false;
  public loginForm: FormGroup;
  private _isEmail: RegExp = /^[^@]+@[^@]+\.[a-zA-Z]{2,}$/gm;
  private _duration: number = 500;

  constructor(
    private _formBuilder: FormBuilder,
    private _apiUserService: ApiUserService,
    private _router: Router,
    private _snackBar: MatSnackBar
  ) {
    this.initForm();
  }

  private initForm(): void {
    this.loginForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.pattern(this._isEmail)]],
      password: ['', [Validators.required]],
    });
  }

  onSave(): void {
    if (this.loginForm.valid) {
      const user: IAuth = this.loginForm.value as IAuth;

      this._apiUserService.login(user).subscribe(
        (res) => {
          console.log(res);
          if (res.result) {
            this._router.navigate(['/']);
          } else {
            this._snackBar.open(res.message, '', {
              duration: this._duration,
            });
          }
        },
        (err) => {
          this._snackBar.open('Ocurrio un error iniciar sesion.', '', {
            duration: this._duration,
          });
          console.error(err);
        }
      );
    }
  }

  // isValidField(name:string):void {
  //   const field = this.loginForm.get(name);

  // }
}
