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
    if (typeof window !== 'undefined') {
      localStorage.removeItem('token')
    }
  }

  isLoggedIn (): boolean {
    if (typeof window === 'undefined') return false

    const token = localStorage.getItem('token')
    if (!token) return false

    const payload = this.decodePayload(token)
    if (!payload || !payload.exp) return false

    const now = Math.floor(Date.now() / 1000) // current time in seconds
    return payload.exp > now
  }

  isTokenExpired (token: string): boolean {
    const payload = this.decodePayload(token)
    if (!payload || !payload.exp) return true
    return Math.floor(Date.now() / 1000) >= payload.exp
  }

  private decodePayload (token: string): any {
    try {
      const base64Payload = token.split('.')[1]
      const payload = atob(base64Payload)
      return JSON.parse(payload)
    } catch {
      return null
    }
  }
}
