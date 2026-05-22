import {Component, inject} from '@angular/core';
import { ApiClient } from '../core/http/api-client';

@Component({
  selector: 'app-productos',
  imports: [],
  templateUrl: './productos.html',
})
export class Productos {
  private api = inject(ApiClient);
  private url = 'http://localhost:5056/GestionProductos';

  productos: Producto[] = [];

  ngOnInit() {
    console.log('iniciando');
    this.api.get<Producto[]>(this.url+'/lista-productos').subscribe({
      next: data => this.productos = data,
      error: error => console.error('Error al obtener productos', error)
    });

    // this.api.get<Producto[]>(this.url+'/lista-productos').subscribe({
    //   next: data => {
    //     this.productos = data;
    //     console.log('data');
    //     console.log(data);
    //     console.log('productos');
    //     console.log(this.productos);
    //   },
    //   error: error => console.error('Error al obtener productos', error)
    // });

  }
}

export interface Producto {
  id: number;
  nombre: string;
  descripcion: string;
  precio: number;
}
