import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from './../../app/auth//auth.service'

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
// export class ProfileComponent implements OnInit {

//   constructor(private auth: AuthService, private router: Router, private route: ActivatedRoute) { }

//   ngOnInit(): void {

//     this.router.navigate(['/auth/profile'], { queryParams: { profil: 'success' } });
//     // this.router.navigate(['/auth/login'], { queryParams: { registered: 'success' } });

//   }

// }

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private auth: AuthService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

}
