import { Component, Output, EventEmitter } from '@angular/core'
import { Router } from '@angular/router'

@Component({
    selector: 'app-modal',
    templateUrl: './modal.component.html',
    styleUrls: ['./modal.component.scss'],
    exportAs: 'modal',
})
export class ModalComponent {
    @Output() modalClose: EventEmitter<any> = new EventEmitter<any>()

    constructor(private router: Router) {}

    public closeModal($event) {
        this.router.navigate([{ outlets: { modal: null } }])
        this.modalClose.next($event)
    }
}
