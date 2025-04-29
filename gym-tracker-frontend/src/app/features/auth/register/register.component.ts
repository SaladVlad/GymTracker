import { Component } from '@angular/core'
import { AuthService } from '../../../core/auth/auth.service'
import { Router } from '@angular/router'
import { FormsModule } from '@angular/forms'

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  username = ''
  password = ''
  error = ''

  constructor (private auth: AuthService, private router: Router) {}

  async register () {
    const token = await this.auth.register({
      username: this.username,
      password: this.password
    })
    if (token) {
      this.router.navigate(['/dashboard'])
    } else {
      this.error = 'User already exists or input invalid'
    }
  }
}
