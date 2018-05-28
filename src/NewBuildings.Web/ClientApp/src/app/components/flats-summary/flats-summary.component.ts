import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { PagerService, PagerInfo } from './pager'
import { FlatSummary } from '../../models/FlatSummary'
import { ServiceResponse } from '../../models/ServiceResponse'

@Component({
    selector: 'app-flats-summary',
    templateUrl: './flats-summary.component.html',
    styleUrls: ['./flats-summary.component.scss'],
})
export class FlatsSummaryComponent {
    public flats: FlatSummary[]

    private pagerService: PagerService
    public pagedFlats: FlatSummary[]
    public pager: PagerInfo
    public flatsPerPage: number

    public currentSortField = ''

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        this.flatsPerPage = 10 // todo : брать из local storage
        this.pagerService = new PagerService()

        http.get<ServiceResponse<FlatSummary[]>>(baseUrl + 'api/flat/all-flats-summary').subscribe(
            (result) => {
                this.flats = result.data
                this.setPage(1)
                // todo: А что если ServiceResponse.Warning/Error?
            },
            (error) => console.error(error),
        )
    }

    public sortBy(propertyName: string) {
        const reverse = this.currentSortField === propertyName
        if (reverse) {
            this.flats.reverse()
        } else {
            this.flats.sort((a, b) => (a[propertyName] > b[propertyName] ? 1 : -1))
            this.currentSortField = propertyName
        }

        this.setPage(this.pager.currentPage)
    }

    public setPage(page: number) {
        this.pager = this.pagerService.getPager(this.flats.length, page, this.flatsPerPage)
        this.pagedFlats = this.flats.slice(this.pager.startIndex, this.pager.endIndex + 1)
    }

    public deleteFlat(flat: FlatSummary) {
        const url: string = this.baseUrl + `api/flat/delete-flat/`
        const { id } = flat

        if (window.confirm('Вы действительно хотите удалить ?')) {
            this.http.post<ServiceResponse<boolean>>(url, { id }).subscribe(
                (result) => {
                    if (result.status) {
                        console.log(result.message)
                    }

                    if (result.data === true) {
                        const index = this.flats.indexOf(flat)
                        this.flats.splice(index, 1)
                        this.setPage(this.pager.currentPage)
                    } else {
                        console.log('not deleted')
                    }

                    // todo: А что если ServiceResponse.Warning/Error?
                },
                (error) => console.error(error),
            )
        }
    }
}
