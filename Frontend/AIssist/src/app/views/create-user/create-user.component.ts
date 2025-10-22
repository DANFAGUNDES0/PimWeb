import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { UserService, UserResponse } from '../../../core/services/user/user.service';

@Component({
  selector: 'app-create-user',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.scss']
})
export class CreateUserComponent {
  userData = {
    name: '',
    email: '',
    username: '',
    password: '',
    profileId: 1 // Defina o perfil padrão
  };

  constructor(
    private userService: UserService,
    private router: Router // ✅ injeta o Router
  ) {}

  onCreateUser() {
    this.userService.createUser(this.userData).subscribe({
      next: (res: UserResponse) => {
        alert('Usuário criado com sucesso!');
        this.router.navigate(['/auth/login']);
      },
      error: (err) => {
        console.error('Erro ao criar usuário:', err);
        alert('Falha ao criar conta. Tente novamente.');
      }
    });
  }
}
