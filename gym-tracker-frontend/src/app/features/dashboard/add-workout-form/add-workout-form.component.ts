import { Component, EventEmitter, Output } from '@angular/core'
import { CommonModule } from '@angular/common'
import { FormsModule } from '@angular/forms'
import { MatCard } from '@angular/material/card'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input'
import { MatSelectModule } from '@angular/material/select'
import { MatButtonModule } from '@angular/material/button'
import { MatDatepickerModule } from '@angular/material/datepicker'
import { MatNativeDateModule } from '@angular/material/core'
import { MatDialogModule } from '@angular/material/dialog'
import { MatDialogRef } from '@angular/material/dialog'

@Component({
  selector: 'app-add-workout-form',
  standalone: true,
  imports: [
    CommonModule,
    MatCard,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule
  ],
  templateUrl: './add-workout-form.component.html',
  styleUrls: ['./add-workout-form.component.css']
})
export class AddWorkoutFormComponent {
  @Output() addWorkout = new EventEmitter<any>()

  type = 'Cardio'
  durationMinutes = 30
  caloriesBurned = 300
  intensity = 5
  fatigue = 5
  notes = ''
  performedAt: Date = new Date()

  constructor (private dialogRef: MatDialogRef<AddWorkoutFormComponent>) {}

  save () {
    const errors: string[] = []

    if (this.durationMinutes <= 0) {
      errors.push('Duration must be a positive number.')
    }

    if (this.caloriesBurned <= 0) {
      errors.push('Calories burned must be a positive number.')
    }

    if (this.intensity < 1 || this.intensity > 10) {
      errors.push('Intensity must be between 1 and 10.')
    }

    if (this.fatigue < 1 || this.fatigue > 10) {
      errors.push('Fatigue must be between 1 and 10.')
    }

    if (this.notes.length > 512) {
      errors.push('Notes cannot exceed 512 characters.')
    }

    if (this.performedAt > new Date()) {
      errors.push('The performed date cannot be in the future.')
    }

    if (errors.length > 0) {
      alert(errors.join('\n')) // Simple user feedback — improve with snackbar/toast if needed
      return
    }

    // All checks passed
    this.dialogRef.close({
      type: this.type,
      durationMinutes: this.durationMinutes,
      caloriesBurned: this.caloriesBurned,
      intensity: this.intensity,
      fatigue: this.fatigue,
      notes: this.notes,
      performedAt: this.performedAt.toISOString()
    })

    this.notes = ''
  }

  closeDialog () {
    this.dialogRef.close()
  }
}
