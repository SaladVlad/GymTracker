import { Component } from '@angular/core'
import { CommonModule } from '@angular/common'
import { WorkoutService } from '../workout.service'
import { WeeklyProgressDto } from '../types/weekly-progress.dto'
import { FormsModule } from '@angular/forms'

@Component({
  selector: 'app-progress',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './progress.component.html',
  styleUrls: ['./progress.component.css']
})
export class ProgressComponent {
  selectedYear = new Date().getFullYear()
  selectedMonth = new Date().getMonth() + 1
  progressData: WeeklyProgressDto[] = []
  loading = false
  error = ''

  constructor (private workoutService: WorkoutService) {}

  async fetchProgress () {
    this.loading = true
    this.error = ''
    try {
      this.progressData = await this.workoutService.getMonthlyProgress(
        this.selectedYear,
        this.selectedMonth
      )
    } catch (err) {
      this.error = 'Failed to load progress'
    } finally {
      this.loading = false
    }
  }
}
