import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isAuthenticated = false;

  constructor(private cookieService:CookieService,
              private router:Router) { }

  ngOnInit(): void {
    this.isAuthenticated = this.cookieService.get('ACCESS_TOKEN') != "";
  }

  logout(){
    this.cookieService.delete('ACCESS_TOKEN');
    this.isAuthenticated = false;
    this.router.navigate(['/login-usuario']);
  }

}
