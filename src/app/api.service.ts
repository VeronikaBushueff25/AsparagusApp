import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'https://localhost:7056/api/users';

  constructor(private http: HttpClient) { }

  createUser(user: any): Observable<any> {
    return this.http.post(this.apiUrl, user);
  }

  getUsers(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}