import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IResponse } from '../models/IResponse';
import { IDocument } from '../models/IDocument';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ApiDocumentService {
  constructor(private _http: HttpClient) {}

  get(): Observable<IResponse<IDocument[]>> {
    return this._http.get<IResponse<IDocument[]>>(
      `${environment.endpoint.document}`
    );
  }

  add(document: IDocument): Observable<IResponse<any>> {
    return this._http.post<IResponse<any>>(
      `${environment.endpoint.document}`,
      document,
      environment.httpOptions
    );
  }

  update(document: IDocument): Observable<IResponse<any>> {
    return this._http.put<IResponse<any>>(
      `${environment.endpoint.document}`,
      document,
      environment.httpOptions
    );
  }

  delete(id: number): Observable<IResponse<any>> {
    return this._http.delete<IResponse<any>>(
      `${environment.endpoint.document}/${id}`
    );
  }
}
