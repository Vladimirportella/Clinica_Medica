import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-inserir-chamados',
  templateUrl: './inserir-chamados.component.html',
  styleUrls: ['./inserir-chamados.component.css']
})
export class InserirChamadosComponent implements OnInit {

  mensagem:string;
  listagemDeMateriais = [];
  listagemDeMensagens = [];
  listagemDeUsuarios = [];
  listagemDeCategorias = [];

  access_token='';

  constructor(private httpClient:HttpClient,
              private cookieService:CookieService,
              ) { }

  ngOnInit() {
    if(this.cookieService.get('ACCESS_TOKEN') == ''){
      window.location.href = 'login-usuario';
    }

    this.access_token = this.cookieService.get('ACCESS_TOKEN');

    this.consultarMateriais();
    this.consultarMensagens();
    this.consultarUsuarios();
    this.consultarCategorias();

  }

  consultarCategorias(){
    this.httpClient.get(environment.UrlsApi.endpointCategoria)
        .subscribe(
          (data:any[]) => {
            this.listagemDeCategorias = data;
          },
          e => {
            this.mensagem = e.toString();
          }
        );
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

  consultarMateriais(){
    this.httpClient.get(environment.UrlsApi.endpointMaterial)
        .subscribe(
          (data:any[]) => {
            this.listagemDeMateriais = data;
          },
          e => {
            this.mensagem = e.toString();
          }
        );
  }

  consultarMensagens(){
    this.httpClient.get(environment.UrlsApi.endpointMensagem)
        .subscribe(
          (data:any[]) => {
            this.listagemDeMensagens = data;
          },
          e => {
            this.mensagem = e.toString();
          }
        );
  }

  inserirChamado(formCadastro){
    this.mensagem = "Processando, por favor aguarde...";

    const headers = new HttpHeaders().set('Authorization', 'Bearer' + this.access_token);

    this.httpClient.post(environment.UrlsApi.endpointChamado, formCadastro.value, {responseType:'text', headers})
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
