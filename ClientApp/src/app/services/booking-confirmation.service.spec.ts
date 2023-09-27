import { TestBed } from '@angular/core/testing';
import { of, throwError } from 'rxjs';
import { BookingDetails } from '../model/bookingdetails';
import { BookingConfirmationService } from './booking-confirmation.service';
import { ApiServiceService } from 'src/shared/services/api-service.service';
import { StudyRoom } from '../model/studyroom';

describe('BookingConfirmationService', () => {
    let service: BookingConfirmationService;
    let apiService: jasmine.SpyObj<ApiServiceService>;

    beforeEach(() => {
        apiService = jasmine.createSpyObj('apiService', ['GetById']);

        TestBed.configureTestingModule({
            providers: [
                BookingConfirmationService,
                { provide: ApiServiceService, useValue: apiService }
            ]
        });

        service = TestBed.inject(BookingConfirmationService);

        apiService = TestBed.inject(ApiServiceService) as jasmine.SpyObj<ApiServiceService>;
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });

    it('should get booking details correctly', () => {

        const mockRoom:StudyRoom={ id: 1, name: 'Room 1',roomNumber:'A101',isAvailable:false }
        const mockBookingDetails: BookingDetails = { bookingId: 1,firstName:"rakesh",lastName:"pernati",email:"rakesh@gmail.com",date:new Date(),studyRoom:mockRoom};

        apiService.GetById.and.returnValue(of({bookingDetails:mockBookingDetails}))

        service.getBookingDetailsById().subscribe(data=>{
            
            expect(data.bookingDetails).toEqual(mockBookingDetails)
        })
        expect(apiService.GetById).toHaveBeenCalledTimes(1)

    });

    
});
