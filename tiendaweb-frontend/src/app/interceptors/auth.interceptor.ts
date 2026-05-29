import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  // Obtenemos el token desde donde lo hayas guardado (ej. localStorage)
  const token = localStorage.getItem('authToken');

  if (token) {
    // Clonamos la petición y agregamos el encabezado Authorization
    const clonedReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${token}`)
    });
    return next(clonedReq);
  }

  return next(req);
};
