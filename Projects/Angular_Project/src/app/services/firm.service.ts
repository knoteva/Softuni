import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Firm } from "../models/firm";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class FirmService {

  // URL to web api
  private firmUrl = 'http://localhost:5000/api/firms';
  constructor(private http: HttpClient) { }

  getFirms(): Observable<Firm[]> {
    return this.http.get<Firm[]>(this.firmUrl);
  }

  getFirmById(id: any): Observable<Firm> {
    return this.http.get<Firm>(`${this.firmUrl}/${id}`);
  }

  addFirm(firm: Firm): Observable<any> {
    return this.http.post<any>(this.firmUrl, firm, httpOptions);
  }

  updateFirmById(firm: Firm, id: any): Observable<Firm> {
    return this.http.put<Firm>(`${this.firmUrl}/${id}`, firm, httpOptions);
  }

  deleteFirmById(id: any): Observable<Firm> {
    return this.http.delete<Firm>(`${this.firmUrl}/${id}`);
  }

}