import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RootURL } from '../constant';
import { City } from '../models/city';
import { DataResponseModel } from '../models/dataResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  apiUrl=RootURL + "/Cities"
  constructor(private httpClient:HttpClient) { }

  getCities():Observable<DataResponseModel<City[]>>{
    return this.httpClient.get<DataResponseModel<City[]>>(this.apiUrl + "/getallcities")
  }
}
