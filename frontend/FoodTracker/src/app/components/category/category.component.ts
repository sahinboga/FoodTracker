import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';
import {RestaurantService} from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories:Category[]=[]

  selectedCategory: number[]=[]

  constructor(
    private categoryService:CategoryService,
    private restaurantService:RestaurantService
  ) { }

  ngOnInit(): void {

    this.getAllCategories()
  }

  getAllCategories(){
    this.categoryService.getCategories().subscribe(response=>{
      this.categories=response.data
    })
  }

  checkFillArray(e:any, id:number, array:number[]) {
    if(e.target.checked) {
      array.push(id)
    } else {
      const index = array.indexOf(id)
      if(index > -1) {
        array.splice(index, 1)
      }
    }
  }

  changeCheckedCategory(e:any,id:number){
    this.checkFillArray(e,id,this.selectedCategory)
  }

  applyFilter(){

    console.log(this.selectedCategory)
    this.arrayToString(this.selectedCategory)
  }

  arrayToString(array:number[]) {
    array.toString()
    console.log(array.toString())
  }

}
