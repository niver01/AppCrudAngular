import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IEntity } from '../models/IEntity';
import { IResponse } from '../models/IResponse';

@Injectable({
  providedIn: 'root',
})
export class ApiEntityService {
  constructor(private _http: HttpClient) {}

  get(): Observable<IResponse<IEntity[]>> {
    return this._http.get<IResponse<IEntity[]>>(
      `${environment.endpoint.entity}`
    );
  }

  add(entity: IEntity): Observable<IResponse<any>> {
    return this._http.post<IResponse<any>>(
      `${environment.endpoint.entity}`,
      entity,
      environment.httpOptions
    );
  }

  update(entity: IEntity): Observable<IResponse<any>> {
    return this._http.put<IResponse<any>>(
      `${environment.endpoint.entity}`,
      entity,
      environment.httpOptions
    );
  }

  delete(id: number): Observable<IResponse<any>> {
    return this._http.delete<IResponse<any>>(
      `${environment.endpoint.entity}/${id}`
    );
  }
}
