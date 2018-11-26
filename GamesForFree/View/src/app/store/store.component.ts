import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html'
})

export class StoreComponent {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http
    this.baseUrl = baseUrl

    this.getVideoGames(http, baseUrl)
  }

  getVideoGames(http: HttpClient, baseUrl: string) {
    http.get<VideoGame[]>(baseUrl + 'VideoGame').subscribe(
      successResult => {
        this.videoGames = successResult
      },
      errorResult => {
        console.error(errorResult)
      });
  }

  public baseUrl: string
  public http: HttpClient
  public videoGames: VideoGame[]
}

interface VideoGame {
  title: string
  price: number
  description: string
}
