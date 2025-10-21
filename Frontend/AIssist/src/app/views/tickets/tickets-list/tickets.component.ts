import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule, MatDialog } from '@angular/material/dialog';
import { TicketService, TicketResponse } from '../../../../core/services/ticket/ticket.service';
import { ButtonComponent } from '../../../components/button/button.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tickets',
  standalone: true,
  imports: [CommonModule, ButtonComponent, MatIconModule, MatDialogModule],
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.scss']
})
export class TicketsComponent implements OnInit {
  tickets: TicketResponse[] = [];
  totalTickets = 0;
  paginaAtual = 1;
  totalPorPagina = 15;

  constructor(
    private ticketService: TicketService, 
    private dialog: MatDialog,
    private router: Router
  ) {}

  ngOnInit() {
    this.carregarTickets();
  }

  irParaNovoTicket() {
    this.router.navigate(['/tickets/novo']);
  }

  carregarTickets() {
    this.ticketService.getTickets().subscribe({
      next: (res) => {
        this.totalTickets = res.length;
        this.tickets = res.map(ticket => ({
          ...ticket,
          created_at: ticket.created_at ? this.formatarDataLocal(ticket.created_at) : '',
          updated_at: ticket.updated_at ? this.formatarDataLocal(ticket.updated_at) : ''
        }));
      },
      error: (err) => console.error('Erro ao buscar tickets:', err)
    });
  }

  deleteTicket(ticketId: number) {
    if (confirm('Tem certeza que deseja excluir este ticket?')) {
      this.ticketService.deleteTicket(ticketId).subscribe({
        next: () => {
          this.tickets = this.tickets.filter(t => t.id !== ticketId);
        },
        error: err => {
          console.error('Erro ao excluir ticket', err);
        }
      });
    }
  }

  openEditDialog(ticket: TicketResponse) {
    // Aqui você pode abrir o dialog de edição (igual ao de usuário)
    console.log('Editar ticket:', ticket);
  }

  private formatarDataLocal(data: string): string {
    const d = new Date(data);
    const dia = String(d.getDate()).padStart(2, '0');
    const mes = String(d.getMonth() + 1).padStart(2, '0');
    const ano = d.getFullYear();
    const horas = String(d.getHours()).padStart(2, '0');
    const minutos = String(d.getMinutes()).padStart(2, '0');
    return `${dia}/${mes}/${ano} ${horas}:${minutos}`;
  }

  executarAcao(event: { type: string; row: TicketResponse }) {
    switch (event.type) {
      case 'edit':
        this.openEditDialog(event.row);
        break;
      case 'delete':
        this.deleteTicket(event.row.id);
        break;
      default:
        console.warn('Ação desconhecida:', event.type);
    }
  }

  carregarPagina(p: number) {
    this.paginaAtual = p;
    this.carregarTickets();
  }
}
