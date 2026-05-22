import { Routes } from '@angular/router';
import {Productos} from './productos/productos';
import {Producto} from './productos/producto';

export const routes: Routes = [
  { path: '', redirectTo: 'productos', pathMatch: 'full' },
  { path: 'productos', component: Productos },
  { path: 'producto', component: Producto }
];
