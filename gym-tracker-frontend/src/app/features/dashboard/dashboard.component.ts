import { Component, OnInit } from '@angular/core'
import { WorkoutService } from '../../services/workout.service'
import { FormsModule } from '@angular/forms'
import { CommonModule } from '@angular/common'
import { WorkoutCardComponent } from './workout-card/workout-card.component'
import { AddWorkoutFormComponent } from './add-workout-form/add-workout-form.component'
import { MatDialog, MatDialogModule } from '@angular/material/dialog'
import { MatDatepickerModule } from '@angular/material/datepicker'
import { MatNativeDateModule } from '@angular/material/core'
import { MatIconModule } from '@angular/material/icon'

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    WorkoutCardComponent,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule
  ],
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

  constructor (
    private dialog: MatDialog,
    private workoutService: WorkoutService
  ) {}

  openAddWorkout () {
    const dialogRef = this.dialog.open(AddWorkoutFormComponent, {
      width: '100%',
      maxWidth: '400px',
      panelClass: 'workout-dialog-panel'
    })

    dialogRef.afterClosed().subscribe(async result => {
      if (result) {
        await this.workoutService.createWorkout(result)
        this.loadWorkouts() // reload list
      }
    })
  }

  async ngOnInit () {
    this.workouts = await this.workoutService.getUserWorkouts()
  }

  async loadWorkouts () {
    this.workouts = await this.workoutService.getUserWorkouts()
  }
}
