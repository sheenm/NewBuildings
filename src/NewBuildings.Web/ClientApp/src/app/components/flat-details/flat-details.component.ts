import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { ServiceResponse } from '../../models/ServiceResponse'
import { FlatFullInformation } from '../../models/FlatFullInformation'
import { ActivatedRoute } from '@angular/router'

@Component({
    selector: 'app-flat-details',
    templateUrl: './flat-details.component.html',
    styleUrls: ['./flat-details.component.scss'],
})
export class FlatDetailsComponent {
    public flat: FlatFullInformation

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private activatedRoute: ActivatedRoute) {
        const id: string = this.activatedRoute.snapshot.paramMap.get('id')
        this.getFlatData(http, baseUrl, id)
    }

    private getFlatData(http: HttpClient, baseUrl: string, id: string): void {
        http.get<ServiceResponse<FlatFullInformation>>(baseUrl + `api/flat/get-flat-details/${id}`).subscribe(
            (result) => {
                this.flat = result.data
                // todo: А что если ServiceResponse.Warning/Error?
            },
            (error) => console.error(error),
        )
    }

    modalClose($event) {
        console.log($event) // { submitted: true }
    }
}
