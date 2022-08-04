import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AgregarItemDto } from 'src/app/models/AgregarItemDto';
import { CarroComprasService } from 'src/app/services/carro-compras.service';
import { ProductService } from 'src/app/services/product-service';
import Swal from "sweetalert2"

@Component({
  selector: 'app-detalles',
  templateUrl: './detalles.component.html',
  styleUrls: ['./detalles.component.css']
})
export class DetallesComponent implements OnInit,OnChanges {

  producto:any;
  cantidadProducto:number=0;
  Id:string="";
  stock:number[]=[];
  agregarItem:AgregarItemDto={productoId:"",cantidadProducto:0}
  constructor(private productService:ProductService, private rute:ActivatedRoute,
    private carroCompras: CarroComprasService, private newRute:Router) { }
  ngOnChanges(changes: SimpleChanges): void {
    console.log(changes)
  }

  ngOnInit(): void {
    this.rute.params.subscribe(param=>{
      this.Id=param['id'];
      console.log(this.Id);
      this.productService.GetById(this.Id).subscribe(item=>{
        this.producto=item;
        this.stock=Array.from(Array(this.producto.stock).keys())
        console.log(this.producto);
      })
    })
    console.log(this.cantidadProducto)
  }

  Select(stock:any){
    console.log(this.cantidadProducto);
  }

  AgregarItem(){
    if(this.cantidadProducto==0){
      Swal.fire({
        icon: 'error',
        title: 'Seleccione la cantidad deseada',
      })
      return;
    }
    this.agregarItem.productoId=this.producto.id;
    this.agregarItem.cantidadProducto=this.cantidadProducto;
    this.carroCompras.AgregarProductosCarro(this.agregarItem).subscribe(item=>{
      console.log(item)
      Swal.fire({
        icon:'success',
        title:"Producto Agregado con éxito al carrito!"
      }).then(()=>{
        this.newRute.navigate([""]);
      })
    })

    console.log(this.agregarItem);
  }
}
