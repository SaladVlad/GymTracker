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
  @Input() workout: any
}
