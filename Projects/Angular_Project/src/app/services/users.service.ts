import { User } from './../models/user';
import { Observable } from 'rxjs';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

const httpOptions = {
  headers : new HttpHeaders({ 'Content-Type': 'application/json' })
}

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  private userUrl = 'http://localhost:5000/api'

  constructor(private http : HttpClient) { }

  getUsers() : Observable<User[]> {
    return this.http.get<User[]>(`${this.userUrl}/getusers`);
  }

  updateEmailAddress(user : User, id : any) : Observable<any> {
    return this.http.put<any>(`${this.userUrl}/updateuser`, user, httpOptions);
  }

  deleteUser(id : any) : Observable<any> {
    return this.http.delete<any>(`${this.userUrl}/deleteuser/${id}`)
  }

}
