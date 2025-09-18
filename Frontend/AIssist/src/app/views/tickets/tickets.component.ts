import { Component } from '@angular/core';
import { ButtonComponent } from '../../components/button/button.component';
import { DataTableComponent} from '../../components/data-table/data-table.component';

@Component({
  selector: 'app-tickets',
  standalone: true,
  imports: [ButtonComponent, DataTableComponent],
  templateUrl: './tickets.component.html',
  styleUrl: './tickets.component.scss'
})
export class TicketsComponent {
  usuarios = [
    { "Aberto Por": 'Murilo Câmara', Assunto: 'Administrador', 'Responsável': '25/03/2025 20:00', Status: 'Aberto', 'Prioridade': 'Critico', 'Criado em': '25/03/2025 20:00' },
    { "Aberto Por": 'Murilo Câmara', Assunto: 'Coordenador', 'Responsável': '25/03/2025 20:00', Status: 'Fechado', 'Prioridade': 'Alto', 'Criado em': '25/03/2025 20:00' },
    // ...dados da API
  ];

paginaAtual = 1;

carregarPagina(p: number) {
  this.paginaAtual = p;
  // chamada API passando p
}

executarAcao(event: any) {
  console.log('Ação:', event.type, 'Na linha:', event.row);
}

}
