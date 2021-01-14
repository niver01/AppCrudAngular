import { TestBed } from '@angular/core/testing';

import { ApiUserService } from './api-user.service';
import { IAuth, IUserResponse } from './../models/IAuth';
import { Observable } from 'rxjs';
import { IResponse } from '../models/IResponse';

import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { environment } from 'src/environments/environment';

const user: IAuth = {
  email: 'niverquispe.qa@gmail.com',
  password: 'niver',
};

describe('ApiUserService', () => {
  let service: ApiUserService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ApiUserService],
      imports: [HttpClientTestingModule],
    });
    service = TestBed.get(ApiUserService);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  // it('user login ', (done: DoneFn) => {
  //   // a: ApiUserService = TestBed.inject(ApiUserService);

  //   service.login(user).subscribe((res) => {
  //     const req = httpTestingController.expectOne(
  //       `${environment.endpoint.user}/authenticate`
  //     );
  //     expect(req.request.method).toBe('POST');
  //     // req.flush({result:1});

  //     expect(res.result).toBeTruthy();
  //     done();
  //   });
  // });

  // it('debe ser creado', () => {
  //   expect(service).toBeTruthy();
  // });
});
