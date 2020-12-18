import { User } from './../models/user';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from './../services/users.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { empty } from 'rxjs';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css']
})
export class UpdateUserComponent implements OnInit {

  userRef = new FormGroup({
    id : new FormControl(),
    email : new FormControl()
  })
  userid : string;
  current_username : string;
  current_email : string;
  users : User[];
  invalidemail : boolean;
  emptyemail : boolean;

  constructor(
    private userService : UsersService,
    private aroute : ActivatedRoute,
    private router : Router
  ) { }

  ngOnInit(): void {
    this.aroute.params.subscribe(params => {
      this.userid = params['id'];
      this.userService.getUsers().subscribe(
        data => this.users = data,
        e => console.log(e),
        () => {
          console.log(this.users);
          // Exclude Logged in user
          let currentuser =  JSON.parse(localStorage.getItem("auth_meta")).userId ;
          for(var i = 0; i < this.users.length; i++) {
            if(this.users[i]._id === currentuser) {
              this.users.splice(i,1);
              break;
            }
          }

          for(let u of this.users) {
            if(this.userid === u._id) {
              this.current_username = u.username;
              this.current_email = u.email;
            }
          }
        }
      )
    })
  }

  updateUser() : void {
    if(this.userRef.value.email === null) {
      //this.userRef.value.email = this.current_email;
      this.emptyemail = true;
      this.invalidemail = false;
    } else {
        var regex = /^\S+@\S+\.\S+$/;
        if (regex.test(this.userRef.value.email) === false) {
          console.log("Please enter a valid email address");
          this.emptyemail = false;
          this.invalidemail = true;
        } else {
          this.emptyemail = false;
          this.invalidemail = false;
          console.log("Everything is fine");
          this.userRef.value.id = this.userid;
          console.log(this.userRef.value);
          this.userService.updateEmailAddress(this.userRef.value, this.userid).subscribe(
            data => console.log(data),
            e => console.log(e),
            () => {
              this.router.navigate(['/app-users-list']);
            }
          )
      }
    }
  }


}
