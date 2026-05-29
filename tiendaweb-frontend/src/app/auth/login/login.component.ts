import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html' 
})

export class LoginComponent {
  email = '';
  password = '';
  private auth = inject(AuthService);
  private router = inject(Router);

  onLogin() {
    this.auth.login({ email: this.email, password: this.password }).subscribe({
      next: (res: any) => {
        localStorage.setItem('authToken', res.token);
        this.router.navigate(['/dashboard']); // Ajusta a tu ruta principal
        alert('Bienvenido zorra');
      },
      error: () => alert('Credenciales inválidas')
    });
  }
}