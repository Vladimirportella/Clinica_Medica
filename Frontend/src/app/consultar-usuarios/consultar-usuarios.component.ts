import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-consultar-usuarios',
  templateUrl: './consultar-usuarios.component.html',
  styleUrls: ['./consultar-usuarios.component.css']
})
export class ConsultarUsuariosComponent implements OnInit {

  mensagem:string;
  listagemDeUsuarios = [];

  constructor(private httpClient:HttpClient,
              private router: Router,
              private cookieService:CookieService) { }

  ngOnInit() {
    if(this.cookieService.get('ACCESS_TOKEN') == ''){
      window.location.href = 'login-usuario';
    }
    this.consultarUsuarios();
  }

  redirect(id: string){
    if(!id){return;}

    this.router.navigate(['atualizar-usuario'], {
      queryParams: {
        'idUsuario': id
       }
    });

  }

  consultarUsuarios(){
    this.httpClient.get(environment.UrlsApi.endpointUsuario)
        .subscribe(
          (data:any[]) => {
            this.listagemDeUsuarios = data;
          },
          e => {
            this.mensagem = e.toString();
          }
        );
  }
}
