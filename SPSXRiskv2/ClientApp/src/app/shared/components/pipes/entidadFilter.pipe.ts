import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'entidadPipe'
})


export class EntidadFilter implements PipeTransform {

  transform(value: any, arg: any): any {

    if (!value) {
      return null;
    }

    const resultEntidades = [];

    for (const post of value) {

      if ((post.entCod.indexOf(arg) > -1) || (post.entDescripcion.indexOf(arg) > -1)) {
        resultEntidades.push(post);
      }
    }
    return resultEntidades;
  }

}
