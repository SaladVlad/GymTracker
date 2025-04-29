import { Injectable } from '@angular/core'
import { CanActivate } from '@angular/router'
import { AuthService } from './auth.service'
import { Router } from '@angular/router'

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor (private auth: AuthService, private router: Router) {}

  canActivate (): boolean {
    // Check if the user is logged in by verifying the token
    if (this.auth.isLoggedIn()) {
      return true // Allow access
    } else {
      // Redirect to login if not logged in
      this.router.navigate(['/login'])
      return false
    }
  }
}
