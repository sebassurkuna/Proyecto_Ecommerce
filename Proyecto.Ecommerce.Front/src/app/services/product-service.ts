import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http'
import { ProductoDto } from '../models/ProductoDto';
import { Observable } from 'rxjs';
import { AgregarProductoDto } from '../models/AgregarProductoDto';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  url="https://localhost:7048/api";
  productos:Array<ProductoDto>=[];

  constructor(private http : HttpClient) { }

  GetProducts():Observable<any>{
    return this.http.get(`${this.url}/Producto`);
  }

  GetById(Id:string):Observable<any>{
    return this.http.get(`${this.url}/Producto/${Id}`)
  }

  CreatProduct(product:AgregarProductoDto):Observable<any>{
    return this.http.post(`${this.url}/Producto`,product);
  }

  UpdateProduct(Id:string,product:AgregarProductoDto):Observable<any>{
    return this.http.put(`${this.url}/Producto/${Id}`,product);
  }

  DeleteProductById(Id:string){
    let param = new HttpParams().set('Id',Id);
    return this.http.delete(`${this.url}/Producto`,{params:param})
  }
}
