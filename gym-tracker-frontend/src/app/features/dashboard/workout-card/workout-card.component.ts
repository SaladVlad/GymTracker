import { Component, Input } from '@angular/core'
import { CommonModule } from '@angular/common'
import { MatCard } from '@angular/material/card'

@Component({
  selector: 'app-workout-card',
  standalone: true,
  imports: [CommonModule, MatCard],
  templateUrl: './workout-card.component.html',
  styleUrl: './workout-card.component.css'
})
export class WorkoutCardComponent {
  @Input() workout: any = null

  getCardClass (): string {
    const i = this.workout.intensity
    const f = this.workout.fatigue

    if (i >= 7 || f >= 7) {
      return 'high-intensity'
    } else if (i >= 4 || f >= 4) {
      return 'medium-intensity'
    } else {
      return 'low-intensity'
    }
  }
}
