import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AgregarClienteDto } from 'src/app/models/AgregarClienteDto';
import { ClienteService } from 'src/app/services/cliente.service';
import Swal from "sweetalert2";

@Component({
  selector: 'app-add-cliente',
  templateUrl: './add-cliente.component.html',
  styleUrls: ['./add-cliente.component.css']
})
export class AddClienteComponent implements OnInit {

  addClienteForm: FormGroup=new FormGroup({});

  constructor(private form:FormBuilder, private clienteService:ClienteService, private newRute: Router ) { }

  ngOnInit(): void {
    this.CreateForm();
  }

  CreateForm(){
    this.addClienteForm=this.form.group({
      nombre:["",Validators.required],
      apellido:["",Validators.required],
      contraseña:["",Validators.required],
      nombreUsuario:["",Validators.required],
      edad:["",[Validators.required,Validators.maxLength(2),Validators.max(70),Validators.min(18)]],
      numeroCedula:["",[Validators.required,Validators.maxLength(10),Validators.minLength(10)]],
      email:["",[Validators.required,Validators.email]]
    });
  }

  Enviar(){
    if (this.addClienteForm.valid){
      console.log(this.addClienteForm)
      this.clienteService.CreatCliente(this.addClienteForm.value as AgregarClienteDto)
      .subscribe(item=>console.log(item));
      Swal.fire({
        icon: 'success',
        title: 'Cliente creado con exito!',
      }).then(()=>{
        this.newRute.navigate(['admin/cliente']);
      });
    }
    console.log(this.addClienteForm)
  }


}
