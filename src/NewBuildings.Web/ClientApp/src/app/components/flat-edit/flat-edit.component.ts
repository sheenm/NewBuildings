import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { ActivatedRoute } from '@angular/router'
import { ServiceResponse } from '../../models/ServiceResponse'
import { FlatFullInformation } from '../../models/FlatFullInformation'
import { Location } from '@angular/common'

@Component({
    selector: 'app-flat-edit',
    templateUrl: './flat-edit.component.html',
    styleUrls: ['./flat-edit.component.scss'],
})
export class FlatEditComponent {
    public flat: FlatFullInformation

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private activatedRoute: ActivatedRoute,
        private location: Location,
    ) {
        const id: string = this.activatedRoute.snapshot.paramMap.get('id')
        this.getFlatData(id)
    }

    private getFlatData(id: string): void {
        this.http.get<ServiceResponse<FlatFullInformation>>(this.baseUrl + `api/flat/get-flat-details/${id}`).subscribe(
            (result) => {
                this.flat = result.data
                // todo: А что если ServiceResponse.Warning/Error?
            },
            (error) => console.error(error),
        )
    }

    public saveFlat() {
        const url = this.baseUrl + 'api/flat/edit-flat'
        console.log(this.flat)
        this.http.post<ServiceResponse<boolean>>(url, this.flat).subscribe(
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
            (error) => console.log(error),
        )

        this.location.back()
    }

    public cancelSave() {
        this.location.back()
    }
}
