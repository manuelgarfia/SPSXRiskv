import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, arg: any): any {
   const resultPosts = [];
    
    if (!arg) {
      return value;
    }

    for (const post of value) {
        if (post.description.toLowerCase().indexOf(arg.toLowerCase()) > -1 || post.code.toLowerCase().indexOf(arg.toLowerCase()) > -1) {
          resultPosts.push(post);
      }
    }
    return resultPosts;
  }
  
}
