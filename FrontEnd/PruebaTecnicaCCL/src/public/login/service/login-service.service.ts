import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { firstValueFrom, Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {
  public http = inject(HttpClient);

  private apiUrl = 'https://localhost:7248/api/Authentication/validation';

  constructor() { }
  public login(email: string, password: string): Observable<any> {
    const body = {
      email: email,
      password: password
    };

    return this.http.post(this.apiUrl, body)
  }
}
