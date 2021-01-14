import { TestBed } from '@angular/core/testing';

import { ApiEntityService } from './api-entity.service';

describe('ApiEntityService', () => {
  let service: ApiEntityService;

  // beforeEach(() => {
  //   TestBed.configureTestingModule({});
  //   service = TestBed.inject(ApiEntityService);
  // });

  // it('should be created', () => {
  //   expect(service).toBeTruthy();
  // });

  it('cuando se llama al metodo: get', () => {
    const valueServiceSpy = jasmine.createSpyObj('ApiEntityService', ['get']);

    const stubValue = { result: 1 | 0 };
    valueServiceSpy.get.and.returnValue(stubValue);

    service = new ApiEntityService(valueServiceSpy);

    expect(service.get()).toBeTruthy(stubValue);
  });

  it('cuando se llama al metodo: delete', () => {
    const valueServiceSpy = jasmine.createSpyObj('ApiEntityService', [
      'delete',
    ]);

    const stubValue = { result: 1 | 0 };
    valueServiceSpy.delete.and.returnValue(stubValue);

    service = new ApiEntityService(valueServiceSpy);

    expect(service.delete(1)).toBeTruthy(stubValue);
  });
});
