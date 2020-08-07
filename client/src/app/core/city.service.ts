import { Injectable } from '@angular/core';
import { environment } from './../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import {  map, delay } from 'rxjs/operators';
import { CityParams } from '../models/city-params';
import { City } from '../models/city';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }


  setCityParams(cityParams: CityParams) {
    let params = new HttpParams();

    if (cityParams.id !== 0)
    {
      params  = params.append('id', cityParams.id.toString());
    }

    if (cityParams.nome)
    {
      params  = params.append('nome', cityParams.nome.toString());
    }

    return params;

  }
  getCityDetails(shopParams: CityParams) {
    const params = this.setCityParams(shopParams);

    return this.http.get<City>(`${this.baseUrl}/CityDetails/get-forecast`, {observe: 'response', params})
          .pipe(
            map(res => {
              return res.body;
            })
          );

  }


  getCities() {
    return this.http.get('http://servicos.cptec.inpe.br/XML/listaCidades')
           .pipe(
             map(res => {
               return res;
             })
           );
   }

   getCityByName(shopParams: CityParams) {
    const params = this.setCityParams(shopParams);

    return this.http.get<any>('http://servicos.cptec.inpe.br/XML/listaCidades')
          .pipe(
            map(res => {
              return res;
            })
          );

}
}


