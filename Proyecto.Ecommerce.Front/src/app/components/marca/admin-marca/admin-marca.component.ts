import { Component, OnInit } from '@angular/core';
import { MarcasDto } from 'src/app/models/MarcasDto';
import { MarcaService } from 'src/app/services/marca.service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-admin-marca',
  templateUrl: './admin-marca.component.html',
  styleUrls: ['./admin-marca.component.css']
})
export class AdminMarcaComponent implements OnInit {

  marcas:MarcasDto[]=[];
  constructor(private marcaService:MarcaService) { }

  ngOnInit(): void {

    this.marcaService.GetMarcas().subscribe(item=>{
      this.marcas=item;
      console.log(item)
    })
    console.log(this.marcas)
    
  }

  Delete(Id:string){
    Swal.fire({
      title: '¿Está Seguro de eliminar la marca?',
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
        this.marcaService.DeleteMarcaById(Id).subscribe(item=>{
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
