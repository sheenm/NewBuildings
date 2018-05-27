import { enableProdMode } from '@angular/core'
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic'

import { AppModule } from './app/app.module'
import { environment } from './environments/environment'

import fontawesome from '@fortawesome/fontawesome'
import * as faEdit from '@fortawesome/fontawesome-free-regular/faEdit'
import * as faView from '@fortawesome/fontawesome-free-regular/faEye'
import * as faTrashAlt from '@fortawesome/fontawesome-free-regular/faTrashAlt'

fontawesome.library.add(faEdit)
fontawesome.library.add(faView)
fontawesome.library.add(faTrashAlt)

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href
}

const providers = [{ provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }]

if (environment.production) {
    enableProdMode()
}

platformBrowserDynamic(providers)
    .bootstrapModule(AppModule)
    .catch((err) => console.log(err))
