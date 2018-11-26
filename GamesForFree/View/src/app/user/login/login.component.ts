import { Component, Inject } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})

export class LoginComponent {
  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    router: Router
  ) {
    this.http = http
    this.baseUrl = baseUrl
    this.loginModel = new LoginModel
    this.router = router;
  }

  login() {
    this.http.post<LoginModel>(this.baseUrl + 'User/Validate', this.loginModel).subscribe(
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
  public loginModel: LoginModel
}

class LoginModel {
  userName: string
  password: string

}
