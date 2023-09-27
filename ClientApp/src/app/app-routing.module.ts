import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RoomBookingDetailsComponent } from './room-components/room-booking-details/room-booking-details.component';
import { BookingConfirmationScreenComponent } from './room-components/booking-confirmation-screen/booking-confirmation-screen.component';
import { BookingRegistrationComponent } from './room-components/booking-registration/booking-registration.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { RoomScreenComponent } from './room-components/room-screen/room-screen.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'room', component: RoomScreenComponent },
  { path: 'bookingdetails', component: RoomBookingDetailsComponent },
  { path: 'bookingconfirmation', component: BookingConfirmationScreenComponent },
  { path: 'bookingregistration', component: BookingRegistrationComponent },
  { path: 'contact', component: ContactUsComponent },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
