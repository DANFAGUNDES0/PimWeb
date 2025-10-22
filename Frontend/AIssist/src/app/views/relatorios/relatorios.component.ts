import { Component, OnInit } from '@angular/core';
import { UserService, UserResponse } from '../../../core/services/user/user.service';
import { Chart, registerables } from 'chart.js';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from '../../components/button/button.component';

Chart.register(...registerables);

@Component({
  selector: 'app-relatorios',
  standalone: true,
  imports: [CommonModule, ButtonComponent],
  templateUrl: './relatorios.component.html',
  styleUrls: ['./relatorios.component.scss']
})
export class RelatoriosComponent implements OnInit {
  totalUsuarios = 0;
  chart: any;

  constructor(private userService: UserService) {}

  ngOnInit() {
    this.carregarUsuarios();
  }

  carregarUsuarios() {
    this.userService.getUsers().subscribe({
      next: (usuarios: UserResponse[]) => {
        this.totalUsuarios = usuarios.length;

        // Agrupa usuários por dia
        const usuariosPorDia: { [key: string]: number } = {};
        usuarios.forEach(u => {
          const createdRaw = (u as any).created_At || (u as any).createdAt;
          if (createdRaw) {
            const data = new Date(createdRaw);
            const dia = `${data.getDate().toString().padStart(2,'0')}/${
              (data.getMonth()+1).toString().padStart(2,'0')}/${data.getFullYear()}`;
            usuariosPorDia[dia] = (usuariosPorDia[dia] || 0) + 1;
          }
        });

        const labels = Object.keys(usuariosPorDia).sort((a,b) => {
          const [d1,m1,y1] = a.split('/').map(Number);
          const [d2,m2,y2] = b.split('/').map(Number);
          return new Date(y1,m1-1,d1).getTime() - new Date(y2,m2-1,d2).getTime();
        });
        const data = labels.map(l => usuariosPorDia[l]);

        this.criarGrafico(labels, data);
      },
      error: err => {
        console.error('Erro ao buscar usuários:', err);
      }
    });
  }

  criarGrafico(labels: string[], data: number[]) {
  const ctx: any = document.getElementById('usuariosChart');
  if (this.chart) this.chart.destroy();

  this.chart = new Chart(ctx, {
    type: 'bar',
    data: {
      labels,
      datasets: [{
        label: 'Usuários criados por dia',
        data,
        backgroundColor: '#055DFC',
        borderColor: '#055DFC',
        borderWidth: 1
      }]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      plugins: { legend: { position: 'top' } },
      scales: { y: { beginAtZero: true, ticks: { precision: 0 } } }
    }
  });
}
}
