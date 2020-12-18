import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { FirmService } from './../services/firm.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-firm',
  templateUrl: './add-firm.component.html',
  styleUrls: ['./add-firm.component.css']
})
export class AddFirmComponent implements OnInit {

  firmRef = new FormGroup({
    id : new FormControl(),
    name : new FormControl()
  })
  formSubmit : boolean = false;

  constructor(public firmService : FirmService, private router : Router) { }

  ngOnInit(): void {
  }

  storeFirm() : void {
    
    this.firmService.addFirm(this.firmRef.value).subscribe(
      data => console.log(data),
      e => console.log(e),
      () => {
        this.firmRef.reset();
        this.formSubmit = true;
        this.router.navigate(['/firms-list']);
      }
    )
  }


}
