import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RoomBookingDetailsComponent } from './room-components/room-booking-details/room-booking-details.component';
import { RoomScreenComponent } from './room-components/room-screen/room-screen.component';
import { BookingConfirmationScreenComponent } from './room-components/booking-confirmation-screen/booking-confirmation-screen.component';
import { BookingRegistrationComponent } from './room-components/booking-registration/booking-registration.component';
import { HttpClientModule } from '@angular/common/http';
import { FooterComponent } from 'src/shared/components/footer/footer.component';
import { NavbarComponent } from 'src/shared/components/navbar/navbar.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { SharedModule } from 'src/shared/Toaster/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HomeComponent,
    NavbarComponent,
    RoomBookingDetailsComponent,
    RoomScreenComponent,
    BookingConfirmationScreenComponent,
    BookingRegistrationComponent,
    ContactUsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule,

    BrowserAnimationsModule, // Required for animations
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
