import { Component, EventEmitter, Input, Output, OnChanges, Inject, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { UserService, UserResponse } from '../../../core/services/user/user.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-user-edit-dialog',
  templateUrl: './user-edit-dialog.component.html',
  styleUrls: ['./user-edit-dialog.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ]
})
export class UserEditDialogComponent {
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    @Inject(MAT_DIALOG_DATA) public data: UserResponse // ✅ aqui recebemos os dados
  ) {
    this.form = this.fb.group({
      username: [this.data?.username || '', [Validators.required]],
      name: [this.data?.name || '', [Validators.required]],
      email: [this.data?.email || '', [Validators.required, Validators.email]],
      password: [''],
      confirmPassword: ['']
    });
  }

  confirmar() {
    if (this.form.invalid) return;

    const updatedUser = { ...this.data, ...this.form.value };
    if (!updatedUser.password) delete updatedUser.password;

    this.userService.updateUser(updatedUser).subscribe({
      next: () => console.log('Usuário atualizado'),
      error: err => console.error('Erro ao atualizar usuário:', err)
    });
  }

  cancelar() {
    console.log('Fechar modal');
  }
}