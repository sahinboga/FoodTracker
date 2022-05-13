import { Pipe, PipeTransform } from '@angular/core';
import { County } from '../models/county';

@Pipe({
  name: 'countinesFilterByCityid'
})
export class CountinesFilterByCityidPipe implements PipeTransform {

  transform(value: County[], cityId: number): County[] {
    //console.log(cityId)
    return cityId? value.filter(c=>c.cityId==cityId):value;
  }

}
