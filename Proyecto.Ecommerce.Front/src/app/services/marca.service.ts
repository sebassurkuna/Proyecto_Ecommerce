import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AgregarMarcaDto } from '../models/AgregarMarcaDto';
import { MarcasDto } from '../models/MarcasDto';

@Injectable({
  providedIn: 'root'
})
export class MarcaService {

  url="https://localhost:7048/api";
  productos:Array<MarcasDto>=[];

  constructor(private http : HttpClient) { }

  GetMarcas():Observable<any>{
    return this.http.get(`${this.url}/Marca`);
  }

  GetById(Id:string):Observable<any>{
    return this.http.get(`${this.url}/Marca/${Id}`)
  }

  CreatMarca(product:AgregarMarcaDto):Observable<any>{
    return this.http.post(`${this.url}/Marca`,product);
  }

  UpdateMarca(Id:string,product:AgregarMarcaDto):Observable<any>{
    return this.http.put(`${this.url}/Marca/${Id}`,product);
  }

  DeleteMarcaById(Id:string){
    let param = new HttpParams().set('Id',Id);
    return this.http.delete(`${this.url}/Marca`,{params:param})
  }
}
