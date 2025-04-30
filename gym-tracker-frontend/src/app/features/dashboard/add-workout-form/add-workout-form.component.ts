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
    this.addWorkout.emit({
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
