import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RootURL } from '../constant';
import { Category } from '../models/category';
import { DataResponseModel } from '../models/dataResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  apiUrl=RootURL + "/Categories"
  constructor(private httpClient:HttpClient) { }

  getCategories():Observable<DataResponseModel<Category[]>>{
    return this.httpClient.get<DataResponseModel<Category[]>>(this.apiUrl + "/getallcategories")
  }

  getCategoryById(categoryId:number):Observable<DataResponseModel<Category>>{
    return this.httpClient.get<DataResponseModel<Category>>(this.apiUrl + "getbyid?categoryId="+categoryId)
  }
}
