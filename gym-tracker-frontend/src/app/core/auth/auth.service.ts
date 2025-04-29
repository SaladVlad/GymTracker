import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { firstValueFrom } from 'rxjs'

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5055/api/auth' // adjust if needed

  constructor (private http: HttpClient) {}

  async login (dto: {
    username: string
    password: string
  }): Promise<string | null> {
    try {
      const res = await firstValueFrom(
        this.http.post<{ token: string }>(`${this.apiUrl}/login`, dto)
      )
      localStorage.setItem('token', res.token)
      return res.token
    } catch (err) {
      return null
    }
  }

  async register (dto: {
    username: string
    password: string
  }): Promise<string | null> {
    try {
      const res = await firstValueFrom(
        this.http.post<{ token: string }>(`${this.apiUrl}/register`, dto)
      )
      localStorage.setItem('token', res.token)
      return res.token
    } catch (err) {
      return null
    }
  }

  logout () {
    localStorage.removeItem('token')
  }

  isLoggedIn (): boolean {
    return !!localStorage.getItem('token')
  }
}
