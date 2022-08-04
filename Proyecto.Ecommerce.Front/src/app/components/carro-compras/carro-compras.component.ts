import { AfterContentInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { flatMap, map, mergeMap, Observable, pipe } from 'rxjs';
import { AgregarItemDto } from 'src/app/models/AgregarItemDto';
import { AgregarOrdenDto } from 'src/app/models/AgregarOrdenDto';
import { OrdenCarroDto } from 'src/app/models/OrdenCarroDto';
import { OrdenItemsDto } from 'src/app/models/OrdenItemsDto';
import { ProductoDto } from 'src/app/models/ProductoDto';
import { CarroComprasService } from 'src/app/services/carro-compras.service';
import { ProductService } from 'src/app/services/product-service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-carro-compras',
  templateUrl: './carro-compras.component.html',
  styleUrls: ['./carro-compras.component.css']
})
export class CarroComprasComponent implements OnInit, AfterContentInit {

  orden:AgregarOrdenDto={clienteId:"d3bd655e-ec1c-4af4-03e8-08da68f2304d",metodoEntregaId:"037f"};
  carro!:OrdenCarroDto;
  productos:ProductoDto[]=[];
  stock:number[][]=[];
  cantidadProducto:number[]=[];
  agregarItem:AgregarItemDto={productoId:"",cantidadProducto:0}
  constructor(private carroCompras:CarroComprasService, private servicioProducto:ProductService,
    private newRute:Router) { }
  ngAfterContentInit(): void {
    console.log(this.carro);
  }

    ngOnInit() {
    this.carroCompras.AgregarOrden(this.orden).subscribe(item=>{
      console.log(item)
    })

    this.carroCompras.VerCarro().pipe(
      map((resp:any)=>{
        this.carro=resp;
        return this.carro;
      }),mergeMap(resp=>resp.ordenItemsDtos),pipe(
        map(resp=>{
          this.servicioProducto.GetById(resp.productoId).subscribe(item=>{
            this.productos.push(item as ProductoDto);
            this.stock.push(Array.from(Array(item.stock+resp.cantidadProducto).keys()))
          });
          return this.productos;
        })
      )
    ).subscribe(item=>console.log(item));
  }

  Select(stock:any,Id:string,index:number){
    console.log(this.cantidadProducto);
    this.agregarItem.productoId=Id;
    if(this.cantidadProducto[index]==this.carro.ordenItemsDtos[index].cantidadProducto){
      this.agregarItem.cantidadProducto=0;
    }else{
      this.agregarItem.cantidadProducto=this.cantidadProducto[index]-this.carro.ordenItemsDtos[index].cantidadProducto;
    }
    this.carroCompras.AgregarProductosCarro(this.agregarItem).subscribe(item=>{
      console.log(item);
      window.location.reload();
    })
    console.log(this.agregarItem);
  }

  Pagar(){
    this.carroCompras.Pagar().subscribe(resp=>{
      console.log(resp);
      Swal.fire({
        icon: 'success',
        title: 'Compra realizada con exito!',
      }).then(()=>{
        this.newRute.navigate(['']);
      });
    })
  }

  EliminarCarro(){
    this.carroCompras.EliminarCarro().subscribe(resp=>{
      console.log(resp);
      Swal.fire({
        icon: 'info',
        title: 'Se eliminó el carro de compras',
      }).then(()=>{
        this.newRute.navigate(['']);
      });
    })
  }


}
