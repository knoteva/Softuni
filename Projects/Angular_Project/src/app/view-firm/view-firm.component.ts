import { ActivatedRoute, Router } from '@angular/router';
import { FirmService } from './../services/firm.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-view-firm',
  templateUrl: './view-firm.component.html',
  styleUrls: ['./view-firm.component.css']
})
export class ViewFirmComponent implements OnInit {

  name : string;
  id : string;
  deletecomp : boolean = false;

  constructor(
              public firmService : FirmService,
              public aroute : ActivatedRoute,
              private router : Router
            ) { }

  ngOnInit(): void {
    this.aroute.params.subscribe(params => {
      this.id = params['id'];
      this.name = params['name']
      
    })
  }

  deleteButton() : void {
    this.deletecomp = true;
  }

  noDelete(): void {
    this.deletecomp = false;
  }

  yesDelete() : void {
    this.firmService.deleteFirmById(this.id).subscribe(
      data => console.log(data),
      e => console.log(e),
      () => {
        this.router.navigate(['/firms-list']);
      }
    )
  }

}
