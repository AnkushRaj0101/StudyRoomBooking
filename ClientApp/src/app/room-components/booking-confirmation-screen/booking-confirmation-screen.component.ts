import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingConfirmationService } from 'src/app/services/booking-confirmation.service';
import { BookingReponse } from 'src/app/model/bookingresponse';

@Component({
  selector: 'app-booking-confirmation-screen',
  templateUrl: './booking-confirmation-screen.component.html',
  styleUrls: ['./booking-confirmation-screen.component.css']
})
export class BookingConfirmationScreenComponent implements OnInit{

  public bookingResponse=new BookingReponse;
  public errorMessage:string=" ";
  constructor(public service: BookingConfirmationService) {
    
  }
  ngOnInit(): void {
    
    this.getBookingDetails()
  }

  getBookingDetails(){
    this.service.getBookingDetailsById().subscribe(data=>{
      Object.assign(this.bookingResponse,data)
    }),
    (error: any) => {                              
      console.error('error caught in component')
      this.errorMessage = error;
    }
  }
 
  
}

