import { User } from './../models/user';
import { UsersService } from './../services/users.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {

  users : User [];
  id : string;

  constructor(private userService : UsersService) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      result => this.users = result,
      e => console.log(e),
      () => {
        let currentuser =  JSON.parse(localStorage.getItem("auth_meta")).userId ;
        for(var i = 0; i < this.users.length; i++) {
          if(this.users[i]._id === currentuser) {
            this.users.splice(i,1);
            break;
          }
        }
      }
    )
  }


}
