import { Component } from '@angular/core'
import { AuthService } from '../../../core/auth/auth.service'
import { Router } from '@angular/router'
import { FormsModule } from '@angular/forms'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatButtonModule } from '@angular/material/button'
import { MatCardModule } from '@angular/material/card'
import { CommonModule } from '@angular/common'

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  username = ''
  password = ''
  errorMessage = ''

  constructor (private auth: AuthService, private router: Router) {}

  async register () {
    const token = await this.auth.register({
      username: this.username,
      password: this.password
    })
    if (token) {
      this.router.navigate(['/dashboard'])
    } else {
      this.errorMessage = 'User already exists or input invalid'
    }
  }
}
