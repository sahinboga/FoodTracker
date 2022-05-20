import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RestaurantDetail } from 'src/app/models/restaurantDetail';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-restaurant-detail',
  templateUrl: './restaurant-detail.component.html',
  styleUrls: ['./restaurant-detail.component.css']
})
export class RestaurantDetailComponent implements OnInit {

  restaurantDetail:RestaurantDetail
  constructor(
    private restaurantService:RestaurantService,
    private activatedRoute:ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["restaurantId"]){
        this.getRestaurantDetailById(params["restaurantId"])
      }else{
        window.location.pathname="/restaurants"
      }

    })
  }

  getRestaurantDetailById(restaurantId:number){
    this.restaurantService.getRestaurantDetailById(restaurantId).subscribe(response=>{
      this.restaurantDetail=response.data
      if(response.success == false || response.data == null) {
        window.location.pathname = "/restaurants"
      }
    })
  }
}
