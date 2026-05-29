// auth.service.ts
import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:5056/api/Usuarios';

  login(credentials: any) {
    return this.http.post(`${this.apiUrl}/login`, credentials);
  }

  registrar(data: any) {
    return this.http.post(`${this.apiUrl}/registrar`, data);
  }
}