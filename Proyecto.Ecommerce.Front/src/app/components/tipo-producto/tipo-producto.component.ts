import { Component, OnInit } from '@angular/core';
import { TipoProductoDto } from 'src/app/models/TipoProductoDto';
import { TipoProductoService } from 'src/app/services/tipo-producto.service';

@Component({
  selector: 'app-tipo-producto',
  templateUrl: './tipo-producto.component.html',
  styleUrls: ['./tipo-producto.component.css']
})
export class TipoProductoComponent implements OnInit {

  tipoProducto:TipoProductoDto[]=[];
  constructor(private tipoProductoService:TipoProductoService) { }

  ngOnInit(): void {

    this.tipoProductoService.GetTipoProductos().subscribe(item=>{
      this.tipoProducto=item;
      console.log(item)
    })
    console.log(this.tipoProducto)
    
  }

  ObtenerxId(Id:string){
   this.tipoProductoService.GetById(Id).subscribe(item=>{
    console.log(item);
   })
  }

  Delete(Id:string){
    this.tipoProductoService.DeleteTipoProductoById(Id).subscribe(item=>{
      console.log(item);
      if(item){
        window.location.reload();
      }
    });
  }

}
