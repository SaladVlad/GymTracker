import { Component } from '@angular/core'
import { CommonModule } from '@angular/common'
import { WorkoutService } from '../../services/workout.service'
import { WeeklyProgressDto } from '../../types/weekly-progress.dto'
import { FormsModule } from '@angular/forms'
import { MatCardModule } from '@angular/material/card'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatSelectModule } from '@angular/material/select'
import { MatButtonModule } from '@angular/material/button'
import { MatTableModule } from '@angular/material/table'
import { MatProgressBarModule } from '@angular/material/progress-bar'

@Component({
  selector: 'app-progress',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatTableModule,
    MatProgressBarModule
  ],
  templateUrl: './progress.component.html',
  styleUrls: ['./progress.component.css']
})
export class ProgressComponent {
  months = [
    { value: 1, label: 'January' },
    { value: 2, label: 'February' },
    { value: 3, label: 'March' },
    { value: 4, label: 'April' },
    { value: 5, label: 'May' },
    { value: 6, label: 'June' },
    { value: 7, label: 'July' },
    { value: 8, label: 'August' },
    { value: 9, label: 'September' },
    { value: 10, label: 'October' },
    { value: 11, label: 'November' },
    { value: 12, label: 'December' }
  ]

  displayedColumns = [
    'week',
    'range',
    'duration',
    'count',
    'intensity',
    'fatigue'
  ]

  selectedYear = new Date().getFullYear()
  selectedMonth = new Date().getMonth() + 1
  progressData: WeeklyProgressDto[] = []
  loading = false
  error = ''

  constructor (private workoutService: WorkoutService) {}

  ngOnInit () {
    this.fetchProgress()
  }

  onSelectionChange () {
    this.fetchProgress()
  }

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

  getIntensityGradient (intensity: number): string {
    if (intensity >= 8) return 'linear-gradient(to right, #d00000, #ff595e)'
    if (intensity >= 6) return 'linear-gradient(to right, #ff8800, #ffc300)'
    if (intensity >= 4) return 'linear-gradient(to right, #ffdd00, #e8ff00)'
    return 'linear-gradient(to right, #7cffcb, #55efc4)'
  }
}
