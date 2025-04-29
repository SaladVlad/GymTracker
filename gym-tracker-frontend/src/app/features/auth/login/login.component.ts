import { Component } from '@angular/core'
import { AuthService } from '../../../core/auth/auth.service'
import { Router } from '@angular/router'
import { FormsModule } from '@angular/forms'

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
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
