import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RootURL } from '../constant';
import { DataResponseModel } from '../models/dataResponseModel';
import { RestaurantImage } from '../models/restaurantImage';

@Injectable({
  providedIn: 'root'
})
export class RestaurantImageService {

  apiUrl=RootURL + "/RestaurantImages"
  constructor(private httpClient:HttpClient) { }

  getRestaurantImages(restaurantId:number):Observable<DataResponseModel<RestaurantImage[]>>{
    return this.httpClient.get<DataResponseModel<RestaurantImage[]>>(this.apiUrl + "/getrestaurantimagesbyrestaurantid?restaurantId="+restaurantId)
  }

  getFirstImageByRestaurantId(restaurantId:number):Observable<DataResponseModel<RestaurantImage>>  {
    return this.httpClient.get<DataResponseModel<RestaurantImage>>(this.apiUrl + "/getfirstimagebyrestaurantid?restaurantId="+restaurantId)
  }
}
