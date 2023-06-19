import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { NgxMaskDirective, NgxMaskPipe, provideEnvironmentNgxMask, provideNgxMask } from 'ngx-mask'

import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { HomePageComponent } from './pages/home/home.page/home.page.component';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { UserService } from 'src/services/user.service';
import { UserTableComponent } from './components/user-table/user-table.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { UserFormPageComponent } from './pages/user-form/user-form.page/user-form.page.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input'
import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { UserFormComponent } from './components/user-form/user-form/user-form.component';
import { AddressService } from 'src/services/address.service';

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    UserTableComponent,
    UserFormPageComponent,
    UserFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatOptionModule,
    MatDatepickerModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    NgxMaskDirective,
    NgxMaskPipe
  ],
  providers: [
    UserService,
    AddressService,
    provideNgxMask()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
