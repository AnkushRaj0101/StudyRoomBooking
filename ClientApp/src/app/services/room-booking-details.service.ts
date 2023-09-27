import { Injectable } from '@angular/core';
import { ApiServiceService } from 'src/shared/services/api-service.service';
import { HttpClient } from '@angular/common/http';
import { ApiConstants } from 'src/shared/constants/api-constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoomBookingDetailsService {

  constructor(private apiService: ApiServiceService, private http: HttpClient) { }

  getAllBookings():Observable<any>{
   return this.apiService.Get(ApiConstants.GET_BOOKINGS);
  }
}
