import { BrowserModule } from '@angular/platform-browser'
import { NgModule } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component'
import { NavMenuComponent } from './layout/nav-menu/nav-menu.component'
import { HomePageComponent } from './pages/home/home-page.component'
import { FlatDetailsComponent } from './components/flat-details/flat-details.component'
import { FlatEditPageComponent } from './pages/flat-edit/flat-edit-page.component'
import { FlatsSummaryComponent } from './components/flats-summary/flats-summary.component'

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomePageComponent,
        FlatDetailsComponent,
        FlatEditPageComponent,
        FlatsSummaryComponent,
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomePageComponent, pathMatch: 'full' },
            { path: 'flat/edit', component: FlatEditPageComponent, pathMatch: 'full' },
        ]),
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
