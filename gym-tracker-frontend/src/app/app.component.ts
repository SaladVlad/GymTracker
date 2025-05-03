import {
  Component,
  HostListener,
  Inject,
  PLATFORM_ID,
  OnInit
} from '@angular/core'
import { isPlatformBrowser, CommonModule } from '@angular/common'
import { RouterModule, Router } from '@angular/router'
import { AuthService } from './core/auth/auth.service'
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatListModule } from '@angular/material/list'
import { MatIconModule } from '@angular/material/icon'
import { MatToolbarModule } from '@angular/material/toolbar'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterModule,
    CommonModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatToolbarModule
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isWideScreen = true
  mobileMenuOpen = false

  constructor (
    public auth: AuthService,
    private router: Router,
    @Inject(PLATFORM_ID) private platformId: Object
  ) {}

  ngOnInit () {
    if (isPlatformBrowser(this.platformId)) {
      this.isWideScreen = window.innerWidth > 768
    }
  }

  @HostListener('window:resize', [])
  onResize () {
    if (isPlatformBrowser(this.platformId)) {
      this.isWideScreen = window.innerWidth > 768
      if (this.isWideScreen) {
        this.mobileMenuOpen = false
      }
    }
  }

  logout () {
    this.auth.logout()
    this.router.navigate(['/login'])
  }
}
