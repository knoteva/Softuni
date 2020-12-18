import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { AuthModule } from './auth/auth.module';

import { UsersListComponent } from './users-list/users-list.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { UpdateUserComponent } from './update-user/update-user.component';

import { FirmsListComponent } from './firms-list/firms-list.component';
import { ViewFirmComponent } from './view-firm/view-firm.component';
import { AddFirmComponent } from './add-firm/add-firm.component';
import { DeleteFirmComponent } from './delete-firm/delete-firm.component';
import { UpdateFirmComponent } from './update-firm/update-firm.component';



@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    ProfileComponent,
    UsersListComponent,
    DeleteUserComponent,
    UpdateUserComponent,
    FirmsListComponent,
    ViewFirmComponent,
    AddFirmComponent,
    DeleteFirmComponent,
    UpdateFirmComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
