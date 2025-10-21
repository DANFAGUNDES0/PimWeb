import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ButtonComponent } from '../../../components/button/button.component';
import { TicketService } from '../../../../core/services/ticket/ticket.service';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-novo-ticket',
  standalone: true,
  imports: [CommonModule, FormsModule, ButtonComponent],
  templateUrl: './novo-ticket.component.html',
  styleUrls: ['./novo-ticket.component.scss'],
})
export class NovoTicketComponent {
  assunto: string = '';
  descricao: string = '';
  dicasIA: string = '';

  assuntosDisponiveis: string[] = ['Travamento', 'Erro', 'Melhoria', 'Outro'];

  private debounceTimer: any;

  constructor(private ticketService: TicketService) {}

  criarTicket() {
    if (!this.assunto || !this.descricao) {
      alert('Preencha todos os campos obrigatórios!');
      return;
    }

    const ticketData = {
      description: this.descricao,
      solution: '',
      reporterId: 1,
      rootCauseId: 0
    };

    this.ticketService.createTicket(ticketData).subscribe({
      next: (res) => {
        console.log('Ticket criado:', res);
        alert('Ticket criado com sucesso!');
        this.assunto = '';
        this.descricao = '';
        this.dicasIA = '';
      },
      error: (err) => {
        console.error('Erro ao criar ticket:', err);
        alert('Erro ao criar ticket');
      }
    });
  }

  onDescricaoChange() {
    clearTimeout(this.debounceTimer);
    this.debounceTimer = setTimeout(() => this.ajudaIA(), 800);
  }

  async ajudaIA() {
    if (!this.descricao) {
      this.dicasIA = 'Descreva o problema para receber dicas da IA.';
      return;
    }

    this.dicasIA = 'Gerando sugestão...';

    try {
      const response = await fetch(`${environment.baseUrl}/OpenAi/suggestion`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ description: this.descricao })
      });

      if (!response.ok) {
        const errorText = await response.text();
        console.error('Erro backend OpenAI:', errorText);
        this.dicasIA = 'Erro ao gerar a sugestão da IA.';
        return;
      }

      const data = await response.json();

      // Corrigido: usar output_text em vez de output[0].content[0].text
      this.dicasIA = data?.output_text ?? 'Não foi possível gerar a sugestão da IA.';

    } catch (error) {
      console.error(error);
      this.dicasIA = 'Erro ao gerar a sugestão da IA.';
    }
  }

  feedbackIA(resposta: boolean) {
    alert(resposta ? 'Obrigado pelo feedback positivo!' : 'Obrigado pelo feedback, vamos melhorar.');
  }
}

