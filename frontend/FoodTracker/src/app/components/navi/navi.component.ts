import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/models/category';
import { City } from 'src/app/models/city';
import { County } from 'src/app/models/county';
import { CategoryService } from 'src/app/services/category.service';
import { CityService } from 'src/app/services/city.service';
import { CountyService } from 'src/app/services/county.service';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-navi',
  templateUrl: './navi.component.html',
  styleUrls: ['./navi.component.css']
})
export class NaviComponent implements OnInit {

  addRestaurantForm:FormGroup

  categories:Category[]=[]
  cities:City[]=[]
  counties:County[]=[]

  @Output() getDetailRestaurants= new EventEmitter<string>()

  currentCity:City
  
  constructor(
        private formBuilder:FormBuilder,
        private restaurantService:RestaurantService,
        private cityService:CityService,
        private countyService:CountyService,
        private categoryService:CategoryService,
        private toastrService:ToastrService
  ) { }

  ngOnInit(): void {
    this.createAddRestaurantForm()
    this.getAllCategories()
    this.getAllCities()
    this.getAllCounties()
  }

  createAddRestaurantForm() {
    this.addRestaurantForm = this.formBuilder.group({
      restaurantName: ["", Validators.required],
      categoryId: ["", Validators.required],
      cityId:["", Validators.required],
      countyId:["",Validators.required],
      foundedDate: ["", Validators.required]
    })
  }

  getAllCategories(){
    this.categoryService.getCategories().subscribe(response=>{
      this.categories=response.data
    })
  }
  getAllCities(){
    this.cityService.getCities().subscribe(response=>{
      this.cities=response.data
    })
    
  }

  getAllCounties(){
    this.countyService.getCounties().subscribe(response=>{
      this.counties = response.data
    })
  }

  // Restoran Ekleme
 addRestaurant(){
   if(this.addRestaurantForm.valid){
     let restaurantModel= Object.assign({},this.addRestaurantForm.value)

     this.restaurantService.addRestaurant(restaurantModel).subscribe(response=>{
       this.toastrService.success(response.message)
       window.location.reload()
     },responseError=>{
       if(responseError.error.Errors.length>0){
        for (let i = 0; i <responseError.error.Errors.length; i++) {
          this.toastrService.error(responseError.error.Errors[i].ErrorMessage
            ,"Hata")
        } 
       }
     })
   }else{
    this.toastrService.error("Formunuz eksik","Dikkat")
   }
 }

}
