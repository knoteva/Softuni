import { FirmService } from './../services/firm.service';
import { Component, OnInit } from '@angular/core';
import { Firm } from '../models/firm';

@Component({
  selector: 'app-firms-list',
  templateUrl: './firms-list.component.html',
  styleUrls: ['./firms-list.component.css']
})
export class FirmsListComponent implements OnInit {

  firms : Firm [];

  constructor(public firms_list_service : FirmService) { }

  ngOnInit(): void {
    this.firms_list_service.getFirms().subscribe(
      result => this.firms = result,
      e => console.log(e),
      () => console.log(this.firms)
    )
  }

}
