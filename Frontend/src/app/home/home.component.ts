import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {



  constructor(private cookieService:CookieService,
              private httpClient:HttpClient) { }

  ngOnInit() {
    if(this.cookieService.get('ACCESS_TOKEN') == ''){
      window.location.href = 'login-usuario';
    }
  }



}
