// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  UrlsApi:{
    endpointUsuario : "http://localhost:53816/api/Usuario",
    endpointChamado : "http://localhost:53816/api/Chamado",
    endpointLogin : "http://localhost:53816/api/Login",
    endpointMaterial : "http://localhost:53816/api/Material",
    endpointMensagem : "http://localhost:53816/api/Mensagem",
    endpointTipo : "http://localhost:53816/api/Tipo",
    endpointStatus : "http://localhost:53816/api/Status",
    endpointCategoria : "http://localhost:53816/api/Categoria",
    endpointChamadoIdUsuario : "http://localhost:53816/api/Chamado/GetByIdUsuario"
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
