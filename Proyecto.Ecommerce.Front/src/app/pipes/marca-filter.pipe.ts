import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'marcaFilter'
})
export class MarcaFilterPipe implements PipeTransform {

  transform(value: any[], ...arg:any): any {
    let resultProduct: any[]=[];
    if (!value) {
      return resultProduct=[];
    }

    if(arg==""){
      return resultProduct=value;
    }
    console.log(arg[0])
    value.forEach(item=>{
      if( item.nombreMarca.toUpperCase()==arg[0].toUpperCase()){
        resultProduct.push(item);
      }
    });

    return resultProduct;
  }

}
