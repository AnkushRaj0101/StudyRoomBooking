import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { RoomBookingDetailsService } from './room-booking-details.service';
import { ApiServiceService } from 'src/shared/services/api-service.service';
import { ApiConstants } from 'src/shared/constants/api-constants';

describe('RoomBookingDetailsService', () => {
  let service: RoomBookingDetailsService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ApiServiceService, RoomBookingDetailsService],
    });

    // Inject the service and the Test Controller for HTTP
    service = TestBed.inject(RoomBookingDetailsService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    // After each test, make sure there are no outstanding requests
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should retrieve bookings from the API', () => {
    const mockBookings = [
      { id: 1, roomName: 'Room A' },
      { id: 2, roomName: 'Room B' },
    ];

    service.getAllBookings().subscribe((bookings) => {
      expect(bookings).toEqual(mockBookings);
    });
    
    const req = httpTestingController.expectOne('https://localhost:7297/'+ApiConstants.GET_BOOKINGS);
    expect(req.request.method).toEqual('GET');
    req.flush(mockBookings);
  });
});
