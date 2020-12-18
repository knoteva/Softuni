import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ViewFirmServiceService {

  constructor(public http : HttpClient) { }
}
