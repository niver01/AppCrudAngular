import { Component } from '@angular/core';
import { ApiUserService } from './../../service/api-user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { IAuth } from 'src/app/models/IAuth';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss'],
})
export class SignUpComponent {
  public signupForm: FormGroup;
  public hide: boolean = false;
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
    this.signupForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.pattern(this._isEmail)]],
      password: ['', [Validators.required]],
      // passwordConfirm: ['', [Validators.required]],
    });
  }

  onSave(): void {
    if (this.signupForm.valid) {
      const user: IAuth = this.signupForm.value as IAuth;

      this._apiUserService.signup(user).subscribe(
        (res) => {
          console.log(res);
          if (res.result) {
            this._router.navigate(['/']);
          }
        },
        (err) => {
          this._snackBar.open('Ocurrio un error al registarar.', '', {
            duration: this._duration,
          });
          console.error(err);
        }
      );
    }
  }
}
