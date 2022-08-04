import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AgregarClienteDto } from 'src/app/models/AgregarClienteDto';
import { ClienteDto } from 'src/app/models/ClienteDto';
import { ClienteService } from 'src/app/services/cliente.service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-update-cliente',
  templateUrl: './update-cliente.component.html',
  styleUrls: ['./update-cliente.component.css']
})
export class UpdateClienteComponent implements OnInit {

  updateClienteForm: FormGroup=new FormGroup({});
  clienteById:any;
  Id:string="";

  constructor(private form:FormBuilder, private clienteService:ClienteService,
     private ruta: ActivatedRoute, private newRute: Router) { }

  ngOnInit(): void {
    this.ruta.params.subscribe(param=>{
      this.Id = param['id'];
      this.clienteService.GetById(this.Id).subscribe(item=>{
        this.clienteById=item;
        this.CreateForm(this.clienteById as ClienteDto);
      });
    })
  }

  CreateForm(cliente:ClienteDto){
    this.updateClienteForm=this.form.group({
      nombre:[cliente.nombre,Validators.required],
      apellido:[cliente.apellido,Validators.required],
      contraseña:[cliente.contraseña,Validators.required],
      nombreUsuario:[cliente.nombreUsuario,Validators.required],
      edad:[cliente.edad,[Validators.required,Validators.maxLength(2),Validators.max(70),Validators.min(18)]],
      numeroCedula:[cliente.numeroCedula,[Validators.required,Validators.maxLength(10),Validators.minLength(10)]],
      email:[cliente.email,[Validators.required,Validators.email]]
    });
  }

  Enviar(){
    if (this.updateClienteForm.valid){
      console.log(this.updateClienteForm)
      this.clienteService.UpdateCliente(this.Id,this.updateClienteForm.value as AgregarClienteDto)
      .subscribe(item=>console.log(item));
      Swal.fire({
        icon: 'success',
        title: 'Cliente actualizado con exito!',
      }).then(()=>{
        this.newRute.navigate(['admin/cliente']);
      });
    }
    console.log(this.updateClienteForm)
  }
}
