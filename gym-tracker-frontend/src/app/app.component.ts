import { Component } from '@angular/core'
import { RouterModule, Router } from '@angular/router'
import { CommonModule } from '@angular/common'
import { AuthService } from './core/auth/auth.service'
import { MatToolbar } from '@angular/material/toolbar'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, CommonModule, MatToolbar],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor (public auth: AuthService, private router: Router) {}

  logout () {
    this.auth.logout()
    this.router.navigate(['/login'])
  }
}
