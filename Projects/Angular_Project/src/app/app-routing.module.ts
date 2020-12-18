
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProfileComponent } from './profile/profile.component';
import { HomeComponent } from './home/home.component';

import { AuthGuard } from './auth/auth.guard';

import { UsersListComponent } from './users-list/users-list.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { UpdateUserComponent } from './update-user/update-user.component';



const routes: Routes = [
  { path: '', component: HomeComponent },
  //{ path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] }
  { path : 'app-users-list', component : UsersListComponent, canActivate : [AuthGuard] },
  { path : 'delete-users', component : DeleteUserComponent, canActivate : [AuthGuard] },
  { path : 'update-users', component : UpdateUserComponent, canActivate : [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
