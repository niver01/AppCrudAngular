import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { IResponse } from '../models/IResponse';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ITaxpayer } from '../models/ITaxpayer';

@Injectable({
  providedIn: 'root',
})
export class ApiTaxpayerService {
  constructor(private _http: HttpClient) {}

  get(): Observable<IResponse<ITaxpayer[]>> {
    return this._http.get<IResponse<ITaxpayer[]>>(
      `${environment.endpoint.taxpayer}`
    );
  }

  add(taxpayer: ITaxpayer): Observable<IResponse<any>> {
    return this._http.post<IResponse<any>>(
      `${environment.endpoint.taxpayer}`,
      taxpayer,
      environment.httpOptions
    );
  }

  update(taxpayer: ITaxpayer): Observable<IResponse<any>> {
    return this._http.put<IResponse<any>>(
      `${environment.endpoint.taxpayer}`,
      taxpayer,
      environment.httpOptions
    );
  }

  delete(id: number): Observable<IResponse<any>> {
    return this._http.delete<IResponse<any>>(
      `${environment.endpoint.taxpayer}/${id}`
    );
  }
}
