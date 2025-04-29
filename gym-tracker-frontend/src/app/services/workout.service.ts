import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { firstValueFrom } from 'rxjs'
import { WeeklyProgressDto } from '../types/weekly-progress.dto'

@Injectable({
  providedIn: 'root'
})
export class WorkoutService {
  private apiUrl = 'http://localhost:5055/api/workouts'

  constructor (private http: HttpClient) {}

  async createWorkout (dto: any): Promise<any> {
    return await firstValueFrom(this.http.post(this.apiUrl, dto))
  }

  async getUserWorkouts (): Promise<any[]> {
    const response = await firstValueFrom(
      this.http.get<{ workouts: any[] }>(this.apiUrl)
    )
    return response.workouts
  }

  async getMonthlyProgress (
    year: number,
    month: number
  ): Promise<WeeklyProgressDto[]> {
    return await firstValueFrom(
      this.http.get<WeeklyProgressDto[]>(
        `${this.apiUrl}/progress/month?year=${year}&month=${month}`
      )
    )
  }
}
