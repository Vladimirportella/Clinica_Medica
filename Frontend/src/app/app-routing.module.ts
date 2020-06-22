import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginUsuarioComponent } from './login-usuario/login-usuario.component';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { ConsultarChamadosComponent } from './consultar-chamados/consultar-chamados.component';
import { ChamadosAbertosComponent } from './Chamados-abertos/Chamados-abertos.component';
import { InserirChamadosComponent } from './inserir-chamados/inserir-chamados.component';
import { DetalhesChamadoComponent } from './Detalhes-chamado/Detalhes-chamado.component';
import { ConsultarUsuariosComponent } from './consultar-usuarios/consultar-usuarios.component';
import { AtualizarUsuarioComponent } from './atualizar-usuario/atualizar-usuario.component';


const routes: Routes = [
  { path : '', redirectTo: 'home', pathMatch: 'full'},
  { path: 'home', component: HomeComponent},
  { path: 'login-usuario', component: LoginUsuarioComponent},
  { path: 'cadastro-usuario', component: CadastroUsuarioComponent},
  { path: 'consultar-chamados', component: ConsultarChamadosComponent},
  { path: 'chamados-abertos', component: ChamadosAbertosComponent},
  { path: 'inserir-chamados', component: InserirChamadosComponent},
  { path: 'detalhes-chamado', component: DetalhesChamadoComponent},
  { path: 'consultar-usuarios', component: ConsultarUsuariosComponent},
  { path: 'atualizar-usuario', component: AtualizarUsuarioComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
