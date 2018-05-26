import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-flats-summary',
  templateUrl: './flats-summary.component.html',
  styleUrls: ['./flats-summary.component.scss'],
})
export class FlatsSummaryComponent {
  public flats: FlatSummaryView[]

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ServiceResponse<FlatSummaryView[]>>(baseUrl + 'api/flat/all-flats-summary').subscribe(
      (result) => {
        this.flats = result.data
      },
      (error) => console.error(error),
    )
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
