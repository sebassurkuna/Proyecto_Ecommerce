import { Component, OnInit } from '@angular/core';
import { MarcasDto } from 'src/app/models/MarcasDto';
import { MarcaService } from 'src/app/services/marca.service';

@Component({
  selector: 'app-marca',
  templateUrl: './marca.component.html',
  styleUrls: ['./marca.component.css']
})
export class MarcaComponent implements OnInit {

  marcas:MarcasDto[]=[];
  constructor(private marcaService:MarcaService) { }

  ngOnInit(): void {

    this.marcaService.GetMarcas().subscribe(item=>{
      this.marcas=item;
      console.log(item)
    })
    console.log(this.marcas)
    
  }

  ObtenerxId(Id:string){
   this.marcaService.GetById(Id).subscribe(item=>{
    console.log(item);
   })
  }

  Delete(Id:string){
    this.marcaService.DeleteMarcaById(Id).subscribe(item=>{
      console.log(item);
      if(item){
        window.location.reload();
      }
    });
  }

}
