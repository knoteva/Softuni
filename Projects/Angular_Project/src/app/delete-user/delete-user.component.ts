import { UsersService } from './../services/users.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.css']
})
export class DeleteUserComponent implements OnInit {

  userid : string;

  constructor(
    private aroute : ActivatedRoute,
    private usersService : UsersService,
    private router : Router
  ) { }

  ngOnInit(): void {
    this.aroute.params.subscribe(params => {
      this.userid = params['id'];
      this.usersService.deleteUser(this.userid).subscribe(
        data => console.log(data),
        e => console.log(e),
        () => {
          this.router.navigate(['/app-users-list']);
        }
      )
    })
  }

}
