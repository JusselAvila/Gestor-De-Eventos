import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './registro.component.html'
})
export class RegistroComponent {
  email = '';
  password = '';
  private auth = inject(AuthService);
  private router = inject(Router);

  onRegister() {
    this.auth.registrar({ email: this.email, password: this.password }).subscribe({
      next: () => {
        alert('Registro exitoso. Ahora puedes iniciar sesión.');
        this.router.navigate(['/login']);
      },
      error: () => alert('Error al registrar')
    });
  }
}