import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantDetailComponent } from './components/restaurant-detail/restaurant-detail.component';
import { RestaurantComponent } from './components/restaurant/restaurant.component';

const routes: Routes = [
  {path:"restaurants",component:RestaurantComponent},
  {path:"restaurants/detail/:restaurantId",component:RestaurantDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
