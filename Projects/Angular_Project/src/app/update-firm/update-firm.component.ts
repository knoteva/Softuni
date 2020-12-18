import { ActivatedRoute, Router } from '@angular/router';
import { FirmService } from './../services/firm.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-update-firm',
  templateUrl: './update-firm.component.html',
  styleUrls: ['./update-firm.component.css']
})
export class UpdateFirmComponent implements OnInit {
  
  firmRef = new FormGroup({
    id : new FormControl(),
    name : new FormControl()
  })
  currentName : string;
  currentId : string;
  formSubmit : boolean = false;
  

  constructor(public firmService : FirmService, public aroute : ActivatedRoute,  private router : Router) { }

  ngOnInit(): void {
    this.aroute.params.subscribe( params => {
      this.currentName = params['name'];
      this.currentId = params['id'];
    })
  }

  updateFirm() : void {
    this.firmService.updateFirmById(this.firmRef.value, this.currentId).subscribe(
      data => console.log(data),
      e => console.log(e),
      () => {
        this.currentName = this.firmRef.value.name;
        this.firmRef.reset();
        this.formSubmit = true;
        this.router.navigate(['/firms-list']);
      }
    )
  }

}
