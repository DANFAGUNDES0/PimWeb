import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ProfileResponse {
  id: number,
  profileName: string,
  active: boolean,
  createdBy: string,
  createdAt: string,
  updatedAt: string,
  updatedBy: string
}

@Injectable({
  providedIn: 'root'
})

export class ProfileService {
  private apiUrl = environment.baseUrl + '/Profile';
  
  constructor(private http: HttpClient) {}

  getProfiles(): Observable<ProfileResponse[]> {
    return this.http.get<ProfileResponse[]>(this.apiUrl);
  }

  updateProfile(profileData: any): Observable<any> {
    return this.http.put<any>(this.apiUrl, profileData);
  }

  inactivateProfile(profileId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${profileId}`);
  }
}
