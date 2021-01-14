import { TestBed } from '@angular/core/testing';

import { ApiDocumentService } from './api-document.service';

describe('ApiDocumentService', () => {
  let service: ApiDocumentService;

  // beforeEach(() => {
  //   TestBed.configureTestingModule({});
  //   service = TestBed.inject(ApiDocumentService);
  // });

  // it('should be created', () => {
  //   expect(service).toBeTruthy();
  // });

  it('cuando se llama al metodo: get', () => {
    const valueServiceSpy = jasmine.createSpyObj('ApiDocumentService', ['get']);

    const stubValue = { result: 1 | 0 };
    valueServiceSpy.get.and.returnValue(stubValue);

    service = new ApiDocumentService(valueServiceSpy);

    expect(service.get()).toBeTruthy(stubValue);
  });

  it('cuando se llama al metodo: delete', () => {
    const valueServiceSpy = jasmine.createSpyObj('ApiDocumentService', [
      'delete',
    ]);

    const stubValue = { result: 1 | 0 };
    valueServiceSpy.delete.and.returnValue(stubValue);

    service = new ApiDocumentService(valueServiceSpy);

    expect(service.delete(1)).toBeTruthy(stubValue);
  });
});
