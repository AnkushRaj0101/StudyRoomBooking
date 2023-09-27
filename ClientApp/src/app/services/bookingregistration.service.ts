import { Injectable } from '@angular/core';
import { ApiServiceService } from 'src/shared/services/api-service.service';
import { Observable } from 'rxjs';
import { ApiConstants } from 'src/shared/constants/api-constants';

@Injectable({
  providedIn: 'root'
})
export class BookingregistrationService {

  constructor(private apiService: ApiServiceService) {

   }
   bookingRegister(bookingDetails:any):Observable<any>{
    return this.apiService.Post(ApiConstants.POST_BOOKING_REGISTRATION,bookingDetails);
   }
}
