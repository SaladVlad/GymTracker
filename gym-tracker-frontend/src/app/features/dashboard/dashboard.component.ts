import { Component, OnInit } from '@angular/core'
import { WorkoutService } from '../../services/workout.service'
import { FormsModule } from '@angular/forms'
import { CommonModule } from '@angular/common'

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  // Form fields
  type = 'Cardio'
  durationMinutes = 30
  caloriesBurned = 300
  intensity = 5
  fatigue = 5
  notes = ''
  performedAt = new Date().toISOString().split('T')[0] // YYYY-MM-DD

  // Workouts list
  workouts: any[] = []

  constructor (private workoutService: WorkoutService) {}

  async ngOnInit () {
    this.workouts = await this.workoutService.getUserWorkouts()
  }

  async submitWorkout () {
    const dto = {
      type: this.type,
      durationMinutes: this.durationMinutes,
      caloriesBurned: this.caloriesBurned,
      intensity: this.intensity,
      fatigue: this.fatigue,
      notes: this.notes,
      performedAt: this.performedAt + 'T00:00:00Z' // ensure UTC
    }

    await this.workoutService.createWorkout(dto)
    this.workouts = await this.workoutService.getUserWorkouts() // refresh list
  }
}
