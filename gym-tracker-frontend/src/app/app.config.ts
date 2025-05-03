import {
  ApplicationConfig,
  importProvidersFrom,
  provideZoneChangeDetection,
  inject
} from '@angular/core'
import { provideRouter } from '@angular/router'
import { FormsModule } from '@angular/forms'
import { routes } from './app.routes'
import {
  provideClientHydration,
  withEventReplay
} from '@angular/platform-browser'
import { provideHttpClient, withInterceptors } from '@angular/common/http'
import { AuthInterceptor } from './core/auth/auth.interceptor'
import { provideAnimations } from '@angular/platform-browser/animations'

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideAnimations(),
    provideClientHydration(withEventReplay()),
    provideHttpClient(withInterceptors([AuthInterceptor])),
    importProvidersFrom(FormsModule)
  ]
}
