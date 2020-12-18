
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProfileComponent } from './profile/profile.component';
import { HomeComponent } from './home/home.component';

import { AuthGuard } from './auth/auth.guard';

import { UsersListComponent } from './users-list/users-list.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { UpdateUserComponent } from './update-user/update-user.component';

import { FirmsListComponent } from './firms-list/firms-list.component';
import { ViewFirmComponent } from './view-firm/view-firm.component';
import { AddFirmComponent } from './add-firm/add-firm.component';
import { DeleteFirmComponent } from './delete-firm/delete-firm.component';
import { UpdateFirmComponent } from './update-firm/update-firm.component';



const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path : 'app-users-list', component : UsersListComponent, canActivate : [AuthGuard] },
  { path : 'delete-users', component : DeleteUserComponent, canActivate : [AuthGuard] },
  { path : 'update-users', component : UpdateUserComponent, canActivate : [AuthGuard] },

  { path : 'firms-list', component : FirmsListComponent, canActivate : [AuthGuard] },
  { path : 'view-firm', component : ViewFirmComponent, canActivate : [AuthGuard] },
  { path : 'add-firm', component : AddFirmComponent, canActivate : [AuthGuard] },
  { path : 'update-firm', component : UpdateFirmComponent, canActivate : [AuthGuard] },
  { path : 'delete-firm', component : DeleteFirmComponent, canActivate : [AuthGuard] },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
