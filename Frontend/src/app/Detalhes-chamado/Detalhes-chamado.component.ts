import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ChamadoModel } from '../models/chamado.model';
import { environment } from 'src/environments/environment';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-Detalhes-chamado',
  templateUrl: './Detalhes-chamado.component.html',
  styleUrls: ['./Detalhes-chamado.component.css']
})
export class DetalhesChamadoComponent implements OnInit {
  id:string;
  listagemDeMateriais=[];
  listagemDeMensagens=[];
  listagemDeUsuarios=[];
  listagemDeStatus = [];
  listagemDeCategorias = [];
  mensagem:string;

  chamadoEdicao:ChamadoModel = {
    idChamado: 0,
    dataCriacao: '',
  descricao : '',
  quantidade: '',
  categoria:  0,
  status: 0,
  idMaterial: 0,
  idMensagem: 0,
  idUsuario: 0
  }

  constructor(private activatedRoute: ActivatedRoute,
              private httpClient:HttpClient,
              private cookieService:CookieService) { }

  ngOnInit() {
    if(this.cookieService.get('ACCESS_TOKEN') == ''){
      window.location.href = 'login-usuario';
    }
    this.id = this.activatedRoute.snapshot.queryParams.idChamado;
    this.consultarMateriais();
    this.consultarUsuarios();
    this.consultarMensagens();
    this.consultarStatus();
    this.consultarCategorias();
    this.consultarChamadoporId();

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

  consultarStatus(){
    this.httpClient.get(environment.UrlsApi.endpointStatus)
        .subscribe(
          (data:any[]) => {
            this.listagemDeStatus = data;
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

  consultarChamadoporId(){
    this.httpClient.get<ChamadoModel>(environment.UrlsApi.endpointChamado + "/" + this.id)
    .subscribe( (data:any) => {
      if(data){
        this.chamadoEdicao = data
      }
    },
      e=>{
        console.log(e);
      });
}

 atualizarChamado(formEdicao){
   this.httpClient.put(environment.UrlsApi.endpointChamado, formEdicao.value, {responseType:'text'})
            .subscribe(
              data => {
                  this.mensagem = data.toString();
                  window.location.href = 'consultar-chamados';
              },
              e =>{
                this.mensagem = e.toString();
                console.log(e);
              }
            );
 }

}
