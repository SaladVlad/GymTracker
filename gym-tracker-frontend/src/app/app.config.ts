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

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideClientHydration(withEventReplay()),
    provideHttpClient(withInterceptors([AuthInterceptor])),
    importProvidersFrom(FormsModule)
  ]
}
