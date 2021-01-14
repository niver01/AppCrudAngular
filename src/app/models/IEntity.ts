export interface IEntity {
  idEntidad?: number;
  idTipoDoc: number;
  codigoDoc?: string;
  numDocumento: string;
  razonSocial: string;
  nombreComercial: string;
  idContribuyente: number;
  nombreContribuyente?: string;
  direccion?: string;
  telefono?: string;
}
