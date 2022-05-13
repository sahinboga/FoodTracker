import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/models/category';
import { City } from 'src/app/models/city';
import { County } from 'src/app/models/county';
import { Restaurant } from 'src/app/models/restaurant';
import { RestaurantDetail } from 'src/app/models/restaurantDetail';
import { CategoryService } from 'src/app/services/category.service';
import { CityService } from 'src/app/services/city.service';
import { CountyService } from 'src/app/services/county.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.component.html',
  styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent implements OnInit {
  updateRestaurantForm:FormGroup

  restaurants:RestaurantDetail[]=[]
  currentRestaurant:Restaurant
  restaurant:Restaurant
  categories:Category[]=[]
  cities:City[]=[]
  counties:County[]=[]

  currentCityId:number
  constructor(
      private formBuilder:FormBuilder,
      private restaurantService:RestaurantService,
      private cityService:CityService,
        private countyService:CountyService,
        private categoryService:CategoryService,
        private toastrService:ToastrService
  ) { }

  ngOnInit(): void {

    this.getDetailRestaurants()
    
    this.getAllCategories()
    this.getAllCities()
    this.getAllCounties()
  }

  getDetailRestaurants(){
    this.restaurantService.getDetailRestaurants().subscribe(response=>{
      this.restaurants=response.data
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

  getRestaurantById(id:number){
    this.restaurantService.getRestaurantById(id).subscribe(response=>{
      this.restaurant=response.data
      
      this.getCountyById(this.restaurant.countyId)
    })
  }

  getCountyById(countyId:number){
    this.countyService.getByCountyId(countyId).subscribe(reponse=>{
      this.currentCityId=reponse.data.cityId
      this.createUpdateRestaurantForm()
    })
  }

  createUpdateRestaurantForm() {
    this.updateRestaurantForm = this.formBuilder.group({
      id: [this.restaurant.id, Validators.required],
      restaurantName: [this.restaurant.restaurantName, Validators.required],
      categoryId: [this.restaurant.categoryId, Validators.required],
      cityId: [this.currentCityId, Validators.required],
      countyId:[this.restaurant.countyId,Validators.required],
      foundedDate: [this.restaurant.foundedDate, Validators.required]
    })
  }

  // Restoran Güncelleme
  updateRestaurant(){
    if(this.updateRestaurantForm.valid){
      let restaurantModel= Object.assign({},this.updateRestaurantForm.value)
      
      this.restaurantService.updateRestaurant(restaurantModel).subscribe(response=>{
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
  
  // Restoran Silme
  deleteRestaurant(restaurant:RestaurantDetail){
    Swal.fire({
      title: 'Emin misin?',
      text:"Kişi silinecek",
      icon:'warning',
      showCancelButton: true,
      cancelButtonText:"İptal",
      showConfirmButton: false,
      showDenyButton: true,
      denyButtonText:"Evet, Sil"
    }).then((result) => {
      if (result.isDenied) {
        this.restaurantService.deleteRestaurant(restaurant).subscribe(response => {
          Swal.fire('Silindi!', '', 'success')
          window.location.reload()
        }, responseError => {
          if(responseError.error.Errors.length>0){
            for (let i = 0; i <responseError.error.Errors.length; i++) {
              this.toastrService.error(responseError.error.Errors[i].ErrorMessage
                ,"Hata")
            }       
          }
        })
      }
    })
  }
  
}
