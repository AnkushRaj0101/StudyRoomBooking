import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BookingReponse } from '../model/bookingresponse';
import { ApiServiceService } from 'src/shared/services/api-service.service';
import { ApiConstants } from 'src/shared/constants/api-constants';

@Injectable({
  providedIn: 'root'
})
export class BookingConfirmationService {
   bookingId:number=0;
  constructor(private webservice: ApiServiceService) {
  }

  public getBookingDetailsById(): Observable<BookingReponse> {
    return this.webservice.GetById(ApiConstants.GET_BOOKING_CONFIRMATION_ID, this.bookingId)
  }

}
