import { HttpInterceptorFn } from '@angular/common/http'
import { inject } from '@angular/core'
import { Router } from '@angular/router'
import { AuthService } from './auth.service'

export const AuthInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('token')
  const auth = inject(AuthService)
  const router = inject(Router)

  if (token) {
    if (auth.isTokenExpired(token)) {
      auth.logout()
      router.navigate(['/login'])
      return next(req)
    }

    const cloned = req.clone({
      setHeaders: { Authorization: `Bearer ${token}` }
    })
    return next(cloned)
  }

  return next(req)
}
