import { BrowserModule } from '@angular/platform-browser'
import { NgModule } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component'
import { NavMenuComponent } from './layout/nav-menu/nav-menu.component'
import { HomeComponent } from './pages/home/home.component'
import { FlatsSummaryComponent } from './components/flats-summary/flats-summary.component'

@NgModule({
  declarations: [AppComponent, NavMenuComponent, HomeComponent, FlatsSummaryComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([{ path: '', component: HomeComponent, pathMatch: 'full' }]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
