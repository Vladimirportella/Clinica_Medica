import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-Chamados-abertos',
  templateUrl: './Chamados-abertos.component.html',
  styleUrls: ['./Chamados-abertos.component.css']
})
export class ChamadosAbertosComponent implements OnInit {

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
    this.httpClient.get(environment.UrlsApi.endpointChamadoIdUsuario + '/' + 1  )
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
