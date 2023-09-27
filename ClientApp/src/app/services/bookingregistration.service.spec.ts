import { BookingDetails } from './../model/bookingdetails.model';
import { TestBed } from '@angular/core/testing';

import { BookingregistrationService } from './bookingregistration.service';
import { ApiConstants } from 'src/shared/constants/api-constants';
import { ApiServiceService } from 'src/shared/services/api-service.service';
import { of } from 'rxjs';
import { HttpClientModule } from '@angular/common/http';

describe('BookingregistrationService', () => {
  let service: BookingregistrationService;
  let apiService: ApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookingregistrationService, ApiServiceService],
      imports: [HttpClientModule],
    });
    service = TestBed.inject(BookingregistrationService);
    apiService = TestBed.inject(ApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
  it('should call apiService.Post with correct URL and data', () => {
    const bookingDetails: BookingDetails = {
      bookingId: 1,
      firstName: 'Siva',
      lastName: 'Kamireddy',
      email: 'siva12@gmail.com',
      date: new Date(),
      studyRoom: {id:1,name:'Earth',roomNumber:'A123',isAvailable:true}
    };
    const expectedUrl = ApiConstants.POST_BOOKING_REGISTRATION;
    spyOn(apiService, 'Post').and.returnValue(of({}));
    service.bookingRegister(bookingDetails);
    expect(apiService.Post).toHaveBeenCalledWith(expectedUrl, bookingDetails);
  });

  it('should return an Observable from apiService.Post', () => {
     const bookingDetails: BookingDetails = {
      bookingId: 1,
      firstName: 'Siva',
      lastName: 'Kamireddy',
      email: 'siva12@gmail.com',
      date: new Date(),
      studyRoom: {id:1,name:'Earth',roomNumber:'A123',isAvailable:true}
    };
    const dummyResponse = { bookingId:1 };
    spyOn(apiService, 'Post').and.returnValue(of(dummyResponse));
    service.bookingRegister(bookingDetails).subscribe((response) => {
      expect(response).toEqual(dummyResponse);
    });
  });
});
