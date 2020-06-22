import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LoginUsuarioComponent } from './login-usuario/login-usuario.component';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { ConsultarChamadosComponent } from './consultar-chamados/consultar-chamados.component';
import { ChamadosAbertosComponent } from './Chamados-abertos/Chamados-abertos.component';
import { InserirChamadosComponent } from './inserir-chamados/inserir-chamados.component';
import { DetalhesChamadoComponent } from './Detalhes-chamado/Detalhes-chamado.component';
import { ConsultarUsuariosComponent } from './consultar-usuarios/consultar-usuarios.component';
import { AtualizarUsuarioComponent } from './atualizar-usuario/atualizar-usuario.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service'


@NgModule({
   declarations: [
      AppComponent,
      HomeComponent,
      NavbarComponent,
      FooterComponent,
      LoginUsuarioComponent,
      CadastroUsuarioComponent,
      ConsultarChamadosComponent,
      ChamadosAbertosComponent,
      InserirChamadosComponent,
      DetalhesChamadoComponent,
      ConsultarUsuariosComponent,
      AtualizarUsuarioComponent,

   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      NgbModule,
      FormsModule,
      ReactiveFormsModule,
      HttpClientModule,

   ],
   providers: [CookieService],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
