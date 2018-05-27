import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { PagerService, PagerInfo } from './pager'

@Component({
    selector: 'app-flats-summary',
    templateUrl: './flats-summary.component.html',
    styleUrls: ['./flats-summary.component.scss'],
})
export class FlatsSummaryComponent {
    public flats: FlatSummaryView[]

    private pagerService: PagerService
    public pagedFlats: FlatSummaryView[]
    public pager: PagerInfo
    public flatsPerPage: number

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.flatsPerPage = 10 // todo : брать из local storage
        this.pagerService = new PagerService()

        http.get<ServiceResponse<FlatSummaryView[]>>(baseUrl + 'api/flat/all-flats-summary').subscribe(
            (result) => {
                this.flats = result.data
                this.setPage(1)
                // todo: А что если ServiceResponse.Warning/Error?
            },
            (error) => console.error(error),
        )
    }

    public setPage(page: number) {
        this.pager = this.pagerService.getPager(this.flats.length, page, this.flatsPerPage)
        this.pagedFlats = this.flats.slice(this.pager.startIndex, this.pager.endIndex + 1)
    }
}

interface FlatSummaryView {
    id: number
    residentialComplexName: string
    roomCount: number
    fullArea: number
    kitchenArea: number
    floor: number
    cost: number
}

interface ServiceResponse<T> {
    status: number
    data: T
    message: string
}
