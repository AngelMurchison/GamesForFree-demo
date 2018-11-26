import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Router, Route } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})

export class RegisterComponent {
  constructor(
    router: Router,
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.http = http
    this.router = router
    this.baseUrl = baseUrl
    this.profile = new DefaultProfile()

    this.get()
  }

  get() {
    this.http.get<DefaultProfile>(this.baseUrl + 'User/DefaultProfile').subscribe(
      () => {
        this.router.navigate(['']);
      },
      errorResult => {
        console.error(errorResult)
      }
    )
  }

  public confirmEmail: boolean
  public reconfirmPassword: boolean
  public baseUrl: string
  public http: HttpClient
  public profile: DefaultProfile
  public router: Router
}

class DefaultProfile {
  constructor(
    public firstName?: string,
    public lastName?: string,
    public email?: string,
    public userName?: string,
  ) { }
}
