import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DocumentComponent } from './components/document/document.component';
import { EntityComponent } from './components/entity/entity.component';
import { LoginComponent } from './components/login/login.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { TaxpayerComponent } from './components/taxpayer/taxpayer.component';
import { AuthGuard } from './security/auth.guard';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'signup',
    component: SignUpComponent,
  },
  {
    path: 'document',
    component: DocumentComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'entity',
    component: EntityComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'taxpayer',
    component: TaxpayerComponent,
    canActivate: [AuthGuard],
  },
  {
    path: '',
    redirectTo: '/document',
    pathMatch: 'full',
  },
  {
    path: '**',
    component: PageNotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
