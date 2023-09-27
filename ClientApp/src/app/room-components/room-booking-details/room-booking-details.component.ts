import { Component, OnInit } from '@angular/core';
import { BookingDetails } from 'src/app/model/bookingdetails';
import { RoomBookingDetailsService } from 'src/app/services/room-booking-details.service';

@Component({
  selector: 'app-room-booking-details',
  templateUrl: './room-booking-details.component.html',
  styleUrls: ['./room-booking-details.component.css']
})
export class RoomBookingDetailsComponent implements OnInit {

  data: BookingDetails[]=[]

  constructor(private bookingDetails: RoomBookingDetailsService) {
    this.getAllDetails()
  }
  ngOnInit(): void {

  }
   getAllDetails() {
     this.bookingDetails.getAllBookings().subscribe(res => {
       return this.data = res.bookingDetails
     })
   }
}
