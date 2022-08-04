import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AgregarItemDto } from '../models/AgregarItemDto';
import { AgregarOrdenDto } from '../models/AgregarOrdenDto';

@Injectable({
  providedIn: 'root'
})
export class CarroComprasService {

  url="https://localhost:7048";
  constructor(private http:HttpClient) { }

  AgregarProductosCarro(item:AgregarItemDto):Observable<any>{
    return this.http.post(`${this.url}/Producto`,item);
  }

  AgregarOrden(item:AgregarOrdenDto):Observable<any>{
    return this.http.post(`${this.url}/Orden`,item);
  }

  VerCarro():Observable<any>{
    return this.http.get(`${this.url}/Carro`);
  }

  Pagar():Observable<any>{
    return this.http.delete(`${this.url}/Compra`)
  }

  EliminarCarro():Observable<any>{
    return this.http.delete(`${this.url}/Orden`)
  }
}
