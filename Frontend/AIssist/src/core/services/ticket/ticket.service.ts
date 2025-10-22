import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

export interface TicketResponse {
  id: number;
  description: string;
  solution?: string;
  assignee_id?: number;
  reporter_id?: number;
  status_id?: number;
  root_cause_id?: number;
  created_at?: string;
  updated_at?: string;
  ticket_number: string;
}

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  private apiUrl = environment.baseUrl + '/Ticket';

  constructor(private http: HttpClient) {}

  // GET - Buscar todos os tickets
  getTickets(): Observable<TicketResponse[]> {
    return this.http.get<TicketResponse[]>(this.apiUrl);
  }

  // POST - Criar ticket
  createTicket(ticketData: any): Observable<TicketResponse> {
    return this.http.post<TicketResponse>(this.apiUrl, ticketData);
  }

  // PUT - Atualizar ticket
  updateTicket(ticketData: any): Observable<any> {
    return this.http.put<any>(this.apiUrl, ticketData);
  }

  // DELETE - Excluir ticket
  deleteTicket(ticketId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${ticketId}`);
  }
}
