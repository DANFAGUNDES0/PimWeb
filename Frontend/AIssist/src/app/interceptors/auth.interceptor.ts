import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  // só tenta acessar localStorage se estiver no navegador
  if (typeof localStorage !== 'undefined') {
    const token = localStorage.getItem('token');

    if (token) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }
  }

  return next(req);
};
