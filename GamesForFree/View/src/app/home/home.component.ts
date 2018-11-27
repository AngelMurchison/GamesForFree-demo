import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import * as gamesList from './games.json'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,) {
    this.http = http
    this.baseUrl = baseUrl
  }

  getTestData() {
    this.getGames()
    console.log(this.videoGames)
  }

  addTestData() {
    this.getGames()
    for (var i = 0; i < this.videoGames.length; i += 100) {

      let request = this.videoGames.slice(i, i + 101)

      this.http.post<VideoGame[]>(this.baseUrl + 'Seed/SeedFrom', request).subscribe(
        () => {
          console.log('Successfully seeded the database.')
        },
        (err) => {
          console.log(err)
        }
      );
    }

  }

  addTransactions() {
    this.http.get(this.baseUrl + 'Seed/SeedTransactions').subscribe(
      () => {
        console.log('Successfully seeded the database.')
      },
      (err) => {
        console.log(err)
      }
    );
  }

  getGames() {
    let typedVideoGames = []
    let games: any = gamesList

    games.forEach(game => {
      if (game.developers) {
        game.developers.forEach(dev => {
          if (typeof (dev) !== 'number') {
            dev.companyTypeId = 1
          }
        })
      }

      if (game.publishers) {
        game.publishers.forEach(pub => {
          if (typeof (pub) !== 'number') {
            pub.companyTypeId = 2
          }
        })
      }

      let typedDev = new VideoGame(game.name, game.summary, 0, game.developers, game.publishers)
      typedVideoGames.push(typedDev)
    })

    this.videoGames = typedVideoGames
  }

  baseUrl: string
  http: HttpClient
  videoGames: VideoGame[]
}
class VideoGame {
  description: string
  title: string
  price: number
  developers: Developer[]
  publishers: Publisher[]

  constructor(
    title: string = '',
    description: string = '',
    price: number = 0,
    developers: Developer[] = [],
    publishers: Publisher[] = []
  ) {
      this.title = title
      this.price = price
      this.description = description
      this.developers = developers
      this.publishers = publishers
  }
}

class Developer {
  name: string
  companyTypeId: number

  constructor(name) {
    this.name = name
    this.companyTypeId = 1
  }
}

class Publisher {
  name: string
  companyTypeId: number

  constructor(name) {
    this.name = name
    this.companyTypeId = 2
  }
}
