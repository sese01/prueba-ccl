import { Injectable } from '@angular/core';
import { Observable, from } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  private apiUrl = 'https://localhost:7248/api/Products/inventario';

  constructor(private http: HttpClient) {}

  public getProducts(): Observable<any> {
    const token = localStorage.getItem('token');

    if (!token) {
      console.error('No token found');
      return new Observable((observer) => {
        observer.error('No token found');
        observer.complete();
      });
    }

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    return this.http.get(this.apiUrl, { headers: headers });
  }
}