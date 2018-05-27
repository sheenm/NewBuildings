import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { ActivatedRoute } from '@angular/router'
import { ServiceResponse } from '../../models/ServiceResponse'

@Component({
    selector: 'app-flat-delete',
    templateUrl: './flat-delete.component.html',
    styleUrls: ['./flat-delete.component.scss'],
})
export class FlatDeleteComponent {
    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private activatedRoute: ActivatedRoute,
    ) {}

    public deleteFlat() {
        const id: string = this.activatedRoute.snapshot.paramMap.get('id')
        const url: string = this.baseUrl + `api/flat/delete-flat/`

        this.http.post<ServiceResponse<boolean>>(url, { id }).subscribe(
            (result) => {
                if (result.status) {
                    console.log(result.message)
                }

                if (result.data === true) {
                    console.log('deleted')
                } else {
                    console.log('not deleted')
                }

                // todo: А что если ServiceResponse.Warning/Error?
            },
            (error) => console.error(error),
        )
    }
}
