import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login-usuario',
  templateUrl: './login-usuario.component.html',
  styleUrls: ['./login-usuario.component.css']
})
export class LoginUsuarioComponent implements OnInit {

  mensagem:string;

  constructor(private httpClient:HttpClient,
              private cookieService:CookieService) { }

  ngOnInit() {
  }

  autenticarUsuario(formAcesso){
    this.mensagem="Processando, por favor aguarde..."

    this.httpClient.post(environment.UrlsApi.endpointLogin, formAcesso.value, {responseType:'text'})
            .subscribe(
              data => {
                this.mensagem = "Usuário autenticado com sucesso.";
                this.cookieService.set('ACCESS_TOKEN', data.toString());
                formAcesso.reset();
                window.location.href='home'
              },
              e => {
                if(e.status==401){
                  this.mensagem="Acesso negado.";
                }
                else {
                  this.mensagem = e.toString();
                }

              }
            );
  }

}
