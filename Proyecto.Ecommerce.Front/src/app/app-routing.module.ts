import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductoComponent } from './components/producto/add-producto/add-producto.component';
import { UpdateProductoComponent } from './components/producto/update-producto/update-producto.component';

const routes: Routes = [
  {path:"producto-add",component:AddProductoComponent},
  {path:"producto-update/:id", component:UpdateProductoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
