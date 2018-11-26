import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
})

export class AdminComponent {
  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
  ) {
    this.http = http
    this.baseUrl = baseUrl

    this.getVideoGames();
  }

  getVideoGames() {
    this.http.get<VideoGame[]>(this.baseUrl + 'VideoGame').subscribe(
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
