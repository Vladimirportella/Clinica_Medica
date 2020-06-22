import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styleUrls: ['./cadastro-usuario.component.css']
})
export class CadastroUsuarioComponent implements OnInit {

  mensagem:string;
  listagemDeTipos=[];

  tipo : number;

  constructor(private httpClient:HttpClient,
              private cookieService:CookieService) { }

  ngOnInit() {
    if(this.cookieService.get('ACCESS_TOKEN') == ''){
      window.location.href = 'login-usuario';
    }
    this.consultarTipos();
  }

  consultarTipos(){
    this.httpClient.get(environment.UrlsApi.endpointTipo)
        .subscribe(
          (data:any[]) => {
            this.listagemDeTipos = data;
          },
          e => {
            this.mensagem = e.toString();
          }
        );
  }

  cadastrarUsuario(formCadastro){
    this.mensagem = "Processando, por favor aguarde...";

    this.httpClient.post(environment.UrlsApi.endpointUsuario, formCadastro.value, {responseType:'text'})
              .subscribe(
                data => {
                  this.mensagem = data.toString();
                  formCadastro.reset();
                },
                e => {
                  this.mensagem = e.toString();
                  console.log(e);
                }
              )
  }

}
