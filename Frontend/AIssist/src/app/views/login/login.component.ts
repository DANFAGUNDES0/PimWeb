// src/app/views/login/login.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  standalone: true,
  imports: [
    FormsModule,      // <- IMPORTAR AQUI
    RouterModule      // <- para usar routerLink
  ],
})
export class LoginComponent {
  loginData = { username: '', password: '' };

  constructor(private authService: AuthService, private router: Router) {}

  onLogin() {
    this.authService.login(this.loginData).subscribe({
      next: (res) => {
        // Armazena o token e dados do usuário
        localStorage.setItem('token', res.accessToken);
        localStorage.setItem('user', JSON.stringify(res.user));

        // Redireciona para o dashboard
        this.router.navigate(['/']);
      },
      error: () => {
        alert('Usuário ou senha inválidos');
      },
    });
  }
}
