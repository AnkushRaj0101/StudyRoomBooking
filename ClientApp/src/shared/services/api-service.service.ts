import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class ApiServiceService {

  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  Get(endpoint: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${endpoint}`);
  }

  GetById(endpoint: string, id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${endpoint}/${id}`);
  }

  Post(endpoint: string, data: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/${endpoint}`, data);
  }

  PostById(endpoint: string, id: number, data: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/${endpoint}/${id}`, data);
  }
}
