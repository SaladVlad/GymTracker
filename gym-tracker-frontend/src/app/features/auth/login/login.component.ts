import { Component } from '@angular/core'
import { MatInputModule } from '@angular/material/input'
import { MatButtonModule } from '@angular/material/button'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatCardModule } from '@angular/material/card'
import { FormsModule } from '@angular/forms'
import { CommonModule } from '@angular/common'
import { Router } from '@angular/router'
import { AuthService } from '../../../core/auth/auth.service'
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = ''
  password = ''
  errorMessage = ''

  constructor (private auth: AuthService, private router: Router) {}

  async login () {
    const token = await this.auth.login({
      username: this.username,
      password: this.password
    })
    if (token) {
      this.router.navigate(['/dashboard'])
    } else {
      this.errorMessage = 'Invalid username or password'
    }
  }
}
