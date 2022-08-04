import { Component, OnInit } from '@angular/core';
import { ClienteDto } from 'src/app/models/ClienteDto';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {

  clientes:ClienteDto[]=[];
  constructor(private clienteService:ClienteService) { }

  ngOnInit(): void {

    this.clienteService.GetClientes().subscribe(item=>{
      this.clientes=item;
      console.log(item)
    })
    console.log(this.clientes)
    
  }

  ObtenerxId(Id:string){
   this.clienteService.GetById(Id).subscribe(item=>{
    console.log(item);
   })
  }

  Delete(Id:string){
    this.clienteService.DeleteClienteById(Id).subscribe(item=>{
      console.log(item);
      if(item){
        window.location.reload();
      }
    });
  }

}
