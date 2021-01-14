import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppMaterialModule } from './app-material.module';
import { AppRoutingModule } from './app-routing.module';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { JwtInterceptor } from './security/jwt.interceptor';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';

import { DocumentComponent } from './components/document/document.component';
import { DialogDocumentComponent } from './components/document/dialog/dialog-document.component';

import { EntityComponent } from './components/entity/entity.component';

import { TaxpayerComponent } from './components/taxpayer/taxpayer.component';
import { DialogTaxpayerComponent } from './components/taxpayer/dialog/dialog-taxpayer.component';

import { LoginComponent } from './components/login/login.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

import { DialogDeleteComponent } from './common/dialog-delete/dialog-delete.component';
import { DialogEntityComponent } from './components/entity/dialog/dialog-entity.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';

@NgModule({
  declarations: [
    AppComponent,
    DocumentComponent,
    EntityComponent,
    TaxpayerComponent,
    LoginComponent,
    PageNotFoundComponent,
    DialogDocumentComponent,
    DialogDeleteComponent,
    DialogTaxpayerComponent,
    DialogEntityComponent,
    SignUpComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppMaterialModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
