import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// Si ya creaste tu componente de menú y quieres mostrarlo siempre, descomenta esto:
// import { NavMenuComponent } from './nav-menu/nav-menu.component';

@Component({
  selector: 'app-root',
  standalone: true,
  // Aquí agregamos lo que vamos a usar en este componente
  imports: [RouterOutlet], 
  template: `
    <main>
      <router-outlet></router-outlet>
    </main>
  `
})
export class AppComponent {
  title = 'tiendaweb';
}
