import { TestBed } from '@angular/core/testing';
import { throwError } from 'rxjs';

import { ApiTaxpayerService } from './api-taxpayer.service';
import { ITaxpayer } from './../models/ITaxpayer';

const taxpayer: ITaxpayer = {
  idContribuyente: 1,
  nombre: 'prueba',
};

describe('ApiTaxpayerService', () => {
  let service: ApiTaxpayerService;

  // beforeEach(() => {
  //   TestBed.configureTestingModule({});
  //   service = TestBed.inject(ApiTaxpayerService);
  // });

  // it('crear servicio', () => {
  //   expect(service).toBeTruthy();
  // });
  it('cuando se llama al metodo: get', () => {
    const valueServiceSpy = jasmine.createSpyObj('ApiTaxpayerService', ['get']);

    const stubValue = { result: 1 | 0 };
    valueServiceSpy.get.and.returnValue(stubValue);

    service = new ApiTaxpayerService(valueServiceSpy);

    expect(service.get()).toBeTruthy(stubValue);
  });

  it('cuando se llama al metodo: delete', () => {
    const valueServiceSpy = jasmine.createSpyObj('ApiTaxpayerService', [
      'delete',
    ]);

    const stubValue = { result: 1 | 0 };
    valueServiceSpy.delete.and.returnValue(stubValue);

    service = new ApiTaxpayerService(valueServiceSpy);

    expect(service.delete(1)).toBeTruthy(stubValue);
  });
});
