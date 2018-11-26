import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html'
})

export class ProfileComponent {
  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    router: Router
  ) {
    this.http = http
    this.baseUrl = baseUrl
    this.profileModel = new ProfileModel
    this.router = router;
  }

  profile() {
    this.http.get<ProfileModel>(this.baseUrl + 'User/DefaultProfile').subscribe(
      () => {
        this.router.navigate([''])
      },
      errorResult => {
        console.error(errorResult)
      }
    )
  }

  public baseUrl: string
  public http: HttpClient
  public router: Router
  public profileModel: ProfileModel
}

class ProfileModel {
  userName: string
  password: string

}
