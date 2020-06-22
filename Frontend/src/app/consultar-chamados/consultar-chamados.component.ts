import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Router, NavigationExtras } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-consultar-chamados',
  templateUrl: './consultar-chamados.component.html',
  styleUrls: ['./consultar-chamados.component.css']
})
export class ConsultarChamadosComponent implements OnInit {

  mensagem:string;
  listagemDeChamados = [];

  constructor(
    private httpClient:HttpClient,
    private router: Router,
    private cookieService:CookieService) { }

  ngOnInit() {
    if(this.cookieService.get('ACCESS_TOKEN') == ''){
      window.location.href = 'login-usuario';
    }
    this.consultarChamados();
  }

  redirect(id: string){
    if(!id){return;}

    this.router.navigate(['detalhes-chamado'], {
      queryParams: {
        'idChamado': id
       }
    });

  }

  consultarChamados(){
    this.httpClient.get(environment.UrlsApi.endpointChamado)
        .subscribe(
          (data:any[]) => {
            this.listagemDeChamados = data;
          },
          e => {
            this.mensagem = e.toString();
          }
        );
  }

}
