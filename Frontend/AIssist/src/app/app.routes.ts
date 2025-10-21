import { Routes } from '@angular/router';
import { DashboardLayoutComponent } from './layouts/dashboard-layout/dashboard-layout.component';
import { HomeComponent } from './views/home/home.component';
import { UsuariosComponent } from './views/usuarios/usuarios.component';
import { TicketsComponent } from './views/tickets/tickets-list/tickets.component';
import { NovoTicketComponent } from './views/tickets/novo-ticket/novo-ticket.component';
import { RelatoriosComponent } from './views/relatorios/relatorios.component';
import { AssuntosComponent } from './views/assuntos/assuntos.component';
import { LoginComponent } from './views/login/login.component';
import { CreateUserComponent } from './views/create-user/create-user.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'auth',
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: CreateUserComponent },
    ],
  },
  {
    path: '',
    component: DashboardLayoutComponent,
    children: [
      { path: '', component: HomeComponent },
      { path: 'usuarios', component: UsuariosComponent },
      { path: 'tickets', component: TicketsComponent },
      { path: 'tickets/novo', component: NovoTicketComponent },
      { path: 'relatorios', component: RelatoriosComponent },
      { path: 'assuntos', component: AssuntosComponent },
    ],
  },
];
