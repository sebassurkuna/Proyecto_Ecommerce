import { Component, OnInit } from '@angular/core';
import { ClienteDto } from 'src/app/models/ClienteDto';
import { ClienteService } from 'src/app/services/cliente.service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-admin-cliente',
  templateUrl: './admin-cliente.component.html',
  styleUrls: ['./admin-cliente.component.css']
})
export class AdminClienteComponent implements OnInit {

  clientes:ClienteDto[]=[];
  constructor(private clienteService:ClienteService) { }

  ngOnInit(): void {

    this.clienteService.GetClientes().subscribe(item=>{
      this.clientes=item;
      console.log(item)
    })
    console.log(this.clientes)
  }

  Delete(Id:string){
    Swal.fire({
      title: '¿Está Seguro de eliminar el usuario?',
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
        this.clienteService.DeleteClienteById(Id).subscribe(item=>{
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
