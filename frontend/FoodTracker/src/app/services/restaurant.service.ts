import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RootURL } from '../constant';
import { DataResponseModel } from '../models/dataResponseModel';
import { ResponseModel } from '../models/responseModel';
import { Restaurant } from '../models/restaurant';
import {RestaurantDetail} from '../models/restaurantDetail'

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  apiUrl=RootURL + "/Restaurants"
  constructor(private httpClient:HttpClient) { }

  getRestaurants():Observable<DataResponseModel<Restaurant[]>>{
    return this.httpClient.get<DataResponseModel<Restaurant[]>>(this.apiUrl + "/getallrestaurants")
  }

  getDetailRestaurants():Observable<DataResponseModel<RestaurantDetail[]>>{
    return this.httpClient.get<DataResponseModel<RestaurantDetail[]>>(this.apiUrl + "/getalldetailrestaurants")
  }

  getRestaurantById(restaurantId:number):Observable<DataResponseModel<Restaurant>>{
    return this.httpClient.get<DataResponseModel<Restaurant>>(this.apiUrl + "/getbyid?id="+restaurantId)
  }

  getAllByCategoryId(categoryId:number):Observable<DataResponseModel<Restaurant>>{
    return this.httpClient.get<DataResponseModel<Restaurant>>(this.apiUrl + "/getallbycategoryid?categoryId="+categoryId)
  }

  addRestaurant(restaurant:Restaurant):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"/add",restaurant);
  }

  updateRestaurant(restaurant:Restaurant):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"/update",restaurant);
  }

  deleteRestaurant(restaurant:RestaurantDetail):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"/delete",restaurant);
  }
}
