import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AgregarTipoProductoDto } from '../models/AgregarTipoProductoDto';
import { TipoProductoDto } from '../models/TipoProductoDto';

@Injectable({
  providedIn: 'root'
})
export class TipoProductoService {

  url="https://localhost:7048/api";
  productos:Array<TipoProductoDto>=[];

  constructor(private http : HttpClient) { }

  GetTipoProductos():Observable<any>{
    return this.http.get(`${this.url}/TipoProducto`);
  }

  GetById(Id:string):Observable<any>{
    return this.http.get(`${this.url}/TipoProducto/${Id}`)
  }

  CreatTipoProducto(product:AgregarTipoProductoDto):Observable<any>{
    return this.http.post(`${this.url}/TipoProducto`,product);
  }

  UpdateTipoProducto(Id:string,product:AgregarTipoProductoDto):Observable<any>{
    return this.http.put(`${this.url}/TipoProducto/${Id}`,product);
  }

  DeleteTipoProductoById(Id:string){
    let param = new HttpParams().set('Id',Id);
    return this.http.delete(`${this.url}/TipoProducto`,{params:param})
  }
}
