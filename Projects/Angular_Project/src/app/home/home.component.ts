import { Component, OnInit } from '@angular/core';
import { AuthService } from './../auth/auth.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

  notify: string;

  constructor(public auth: AuthService,private router: Router, private route: ActivatedRoute) { }
  
//If the user is succesfully login display message
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      const key1 = 'loggedin';
      if (params[key1] === 'success') {
        // setTimeout(() => {
          this.notify = 'You have been successfully loggedin. Welcome home';
        // }, 20);       
      }
    });
  }

}