import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiServiceService } from 'src/shared/services/api-service.service';
import { ApiConstants } from 'src/shared/constants/api-constants';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  constructor(private apiService: ApiServiceService) {}

  getRooms(): Observable<any> {
    return this.apiService.Get(ApiConstants.GET_ROOMS);
  }
 
}
