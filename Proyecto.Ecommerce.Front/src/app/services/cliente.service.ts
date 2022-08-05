import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AgregarClienteDto } from '../models/AgregarClienteDto';
import { ClienteDto } from '../models/ClienteDto';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  url="https://localhost:7048/api";
  productos:Array<ClienteDto>=[];

  constructor(private http : HttpClient) { }

  GetClientes():Observable<any>{
    return this.http.get(`${this.url}/Cliente`);
  }

  GetById(Id:string):Observable<any>{
    return this.http.get(`${this.url}/Cliente/${Id}`)
  }

  CreatCliente(product:AgregarClienteDto):Observable<any>{
    return this.http.post(`${this.url}/Cliente`,product);
  }

  UpdateCliente(Id:string,product:AgregarClienteDto):Observable<any>{
    return this.http.put(`${this.url}/Cliente/${Id}`,product);
  }

  DeleteClienteById(Id:string){
    let param = new HttpParams().set('Id',Id);
    return this.http.delete(`${this.url}/Cliente`,{params:param})
  }
}
