import { Component } from '@angular/core';
import Swal from "sweetalert2";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Proyecto.Ecommerce.Front';

  ejemplo(){
    Swal.fire("hola").then(respo=>console.log(respo));
  }
}
