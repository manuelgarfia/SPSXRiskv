export interface usersmodel {
  activo: boolean;
  cabid: number;
  idioma: string;
  nombre: string;
  paswrd: string;
  usuari: string;
  usuariZoom: string;
}

export interface usersgroupmodel {
  cabid: any;
  usuari: string;
  grup: string;
}

export interface securityObjectModel {
  codigo: any;
  denegar: boolean;
  denegados: string;
  permitir: boolean;
  permitidos: string;
}

