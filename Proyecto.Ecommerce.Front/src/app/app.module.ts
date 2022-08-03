import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductoComponent } from './components/producto/producto.component';
import { AddProductoComponent } from './components/producto/add-producto/add-producto.component';
import { ReactiveFormsModule } from '@angular/forms';
import { UpdateProductoComponent } from './components/producto/update-producto/update-producto.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductoComponent,
    AddProductoComponent,
    UpdateProductoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
