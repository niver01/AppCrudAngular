// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import { HttpHeaders } from '@angular/common/http';
const URL = 'https://localhost:44381/api';

export const environment = {
  production: false,
  httpOptions: {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  },
  endpoint: {
    user: `${URL}/User`,
    document: `${URL}/Document`,
    taxpayer: `${URL}/Taxpayer`,
    entity: `${URL}/Entity`,
  },
};
