import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService, UserResponse } from '../../../core/services/user/user.service';
import { ButtonComponent } from '../../components/button/button.component';
import { UserEditDialogComponent } from '../../components/user-edit-dialog/user-edit-dialog.component';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule, MatDialog } from '@angular/material/dialog';
import {MatTooltipModule} from '@angular/material/tooltip';

interface Usuario extends UserResponse {
  created_At?: string;
  updated_At?: string;
}

@Component({
  selector: 'app-usuarios',
  standalone: true,
  imports: [CommonModule, ButtonComponent, MatIconModule, MatDialogModule, UserEditDialogComponent, MatTooltipModule],
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.scss']
})
export class UsuariosComponent implements OnInit {
  usuarios: Usuario[] = [];
  totalUsuarios = 0;
  paginaAtual = 1;
  totalPorPagina = 15;
  modalAberto = false;
  usuarioAtual: UserResponse | undefined;

  constructor(
    private userService: UserService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.carregarUsuarios();
  }

  carregarUsuarios() {
    this.userService.getUsers().subscribe({
      next: (res: UserResponse[]) => {
        this.totalUsuarios = res.length;
        this.usuarios = res;
      },
      error: (err) => console.error('Erro ao buscar usuários:', err)
    });
  }

  deleteUser(userId: number) {
    if (confirm('Tem certeza que deseja excluir este usuário?')) {
      this.userService.deleteUser(userId).subscribe({
        next: () => {
          this.usuarios = this.usuarios.filter(u => u.id !== userId);
        },
        error: err => {
          console.error('Erro ao excluir usuário', err);
        }
      });
    }
  }

  openEditDialog(user: UserResponse) {
    this.usuarioAtual = user;
    this.modalAberto = true;
  }

  formatarDataLocal(data: string): string {
    const d = new Date(data);
    const dia = String(d.getDate()).padStart(2,'0');
    const mes = String(d.getMonth()+1).padStart(2,'0');
    const ano = d.getFullYear();
    const horas = String(d.getHours()).padStart(2,'0');
    const minutos = String(d.getMinutes()).padStart(2,'0');
    return `${dia}/${mes}/${ano} ${horas}:${minutos}`;
  }

  getProfileName(id: number): string {
    const profiles: { [key: number]: string } = {
      1: 'Administrador',
      2: 'Gerente',
      3: 'Usuário',
      4: 'Visitante'
    };
    return profiles[id] || 'Desconhecido';
  }

  executarAcao(event: { type: string; row: Usuario }) {
    switch(event.type) {
      case 'edit': this.openEditDialog(event.row); break;
      case 'delete': this.deleteUser(event.row.id); break;
      case 'toggle': console.log('Alternar status de:', event.row); break;
      default: console.warn('Ação desconhecida:', event.type);
    }
  }

  carregarPagina(p: number) {
    this.paginaAtual = p;
    this.carregarUsuarios();
  }

  fecharModal(): void {
    this.modalAberto = false;
  }
}
