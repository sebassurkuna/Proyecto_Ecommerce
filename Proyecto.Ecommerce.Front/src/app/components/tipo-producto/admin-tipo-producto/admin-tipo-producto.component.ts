import { Component, OnInit } from '@angular/core';
import { TipoProductoDto } from 'src/app/models/TipoProductoDto';
import { TipoProductoService } from 'src/app/services/tipo-producto.service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-admin-tipo-producto',
  templateUrl: './admin-tipo-producto.component.html',
  styleUrls: ['./admin-tipo-producto.component.css']
})
export class AdminTipoProductoComponent implements OnInit {

  tipoProducto:TipoProductoDto[]=[];
  constructor(private tipoProductoService:TipoProductoService) { }

  ngOnInit(): void {

    this.tipoProductoService.GetTipoProductos().subscribe(item=>{
      this.tipoProducto=item;
      console.log(item)
    })
    console.log(this.tipoProducto)
    
  }

  Delete(Id:string){
    Swal.fire({
      title: '¿Está Seguro de eliminar el Tipo de producto?',
      icon: 'info',
      showCloseButton: true,
      showCancelButton: true,
      focusConfirm: false,
      confirmButtonText:
        'Si',
      confirmButtonAriaLabel: 'Thumbs up, great!',
      cancelButtonText:
        'No',
      cancelButtonAriaLabel: 'Thumbs down'
    }).then(resp=>{
      if(resp.isConfirmed){
        console.log(resp.isConfirmed)
        this.tipoProductoService.DeleteTipoProductoById(Id).subscribe(item=>{
          console.log(item);
          if(item){
            window.location.reload();
          }
        });
      }else{
        return;
      }
    })
    
  }
}
