import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RootURL } from '../constant';
import { County } from '../models/county';
import { DataResponseModel } from '../models/dataResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CountyService {

  apiUrl=RootURL + "/Counties"
  constructor(private httpClient:HttpClient) { }

  getCounties():Observable<DataResponseModel<County[]>>{
    return this.httpClient.get<DataResponseModel<County[]>>(this.apiUrl + "/getallcounties")
  }

  getCountiesByCity(cityId:number):Observable<DataResponseModel<County[]>>{
    return this.httpClient.get<DataResponseModel<County[]>>(this.apiUrl + "/getcountiesbycity?cityId="+cityId)
  }
}
