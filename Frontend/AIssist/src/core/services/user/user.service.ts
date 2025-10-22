import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface UserResponse {
  id: number;
  name: string;
  username: string;
  email: string;
  active: number;
  profile: number;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = environment.baseUrl + '/User';

  constructor(private http: HttpClient) {}

  // POST para criar usuário
  createUser(userData: any): Observable<UserResponse> {
    return this.http.post<UserResponse>(this.apiUrl, userData);
  }

  // DELETE para desativar o usuário
  deleteUser(userId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${userId}`);
  }

  // PUT para editar o usuário
  updateUser(userData: any): Observable<any> {
    return this.http.put<any>(this.apiUrl, userData);
  }
  
  // GET para buscar usuários
  getUsers(): Observable<UserResponse[]> {
    return this.http.get<UserResponse[]>(this.apiUrl);
  }

}
