import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxpayerComponent } from './taxpayer.component';
import { throwError } from 'rxjs';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('TaxpayerComponent', () => {
  let component: TaxpayerComponent;
  let fixture: ComponentFixture<TaxpayerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [TaxpayerComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaxpayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
