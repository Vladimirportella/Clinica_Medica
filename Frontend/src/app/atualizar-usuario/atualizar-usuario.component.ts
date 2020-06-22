import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UsuarioModel } from '../models/usuario.model';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-atualizar-usuario',
  templateUrl: './atualizar-usuario.component.html',
  styleUrls: ['./atualizar-usuario.component.css']
})
export class AtualizarUsuarioComponent implements OnInit {

  id:string;
  usuarioEdicao: UsuarioModel = {
    idUsuario:0,
    nome:'',
    matricula:'',
    email:'',
    senha:'',
    senhaConfirmacao:'',
    idTipo:0,
    ativo:true
  }

  mensagem:string;

  constructor(private activatedRoute: ActivatedRoute,
              private httpClient:HttpClient,
              private cookieService:CookieService) { }

  ngOnInit() {
    if(this.cookieService.get('ACCESS_TOKEN') == ''){
      window.location.href = 'login-usuario';
    }
    this.id = this.activatedRoute.snapshot.queryParams.idUsuario;
    this.consultarUsuarioporId();
  }

  consultarUsuarioporId(){
        this.httpClient.get<UsuarioModel>(environment.UrlsApi.endpointUsuario + "/" + this.id)
        .subscribe( data => {
          if(data){
            this.usuarioEdicao = data
          }
        },
          e=>{
            console.log(e);
          });
  }

  atualizarUsuario(formEdicao){
    this.mensagem = "Processando, por favor aguarde...";
debugger;
    this.httpClient.put(environment.UrlsApi.endpointUsuario, formEdicao.value , {responseType:'text'})
                .subscribe(
                  data => {
                      this.mensagem = data.toString();
                      window.location.href = 'consultar-usuarios';

                  },
                  e =>{
                    this.mensagem = e.toString();
                    console.log(e);
                  }
                );
  }

}
