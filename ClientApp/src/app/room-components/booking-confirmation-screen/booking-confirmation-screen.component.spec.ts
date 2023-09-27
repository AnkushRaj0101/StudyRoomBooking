import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { BookingConfirmationScreenComponent } from './booking-confirmation-screen.component'; // Update with your path
import { BookingDetails } from 'src/app/model/bookingdetails';
import { BookingConfirmationService } from 'src/app/services/booking-confirmation.service';
import { of } from 'rxjs';
import { StudyRoom } from 'src/app/model/studyroom';

describe('BookingConfirmationScreenComponent', () => {
  let component: BookingConfirmationScreenComponent;
  let fixture: ComponentFixture<BookingConfirmationScreenComponent>;
  let mockService: jasmine.SpyObj<BookingConfirmationService>;
  let mockActivatedRoute: { snapshot: any; };

  beforeEach(async () => {
    mockService = jasmine.createSpyObj('BookingConfirmationService', ['getBookingDetailsById']);
    mockActivatedRoute = {
      snapshot: {
        paramMap: {
          get: jasmine.createSpy('get')
        }
      }
    };

    await TestBed.configureTestingModule({
      declarations: [BookingConfirmationScreenComponent],
      providers: [
        { provide: BookingConfirmationService, useValue: mockService },
        { provide: ActivatedRoute, useValue: mockActivatedRoute }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(BookingConfirmationScreenComponent);

    component = fixture.componentInstance;
    
    mockService=TestBed.inject(BookingConfirmationService) as jasmine.SpyObj<BookingConfirmationService>

    mockActivatedRoute=TestBed.inject(ActivatedRoute) as jasmine.SpyObj<ActivatedRoute>
    
  });
  it('should create', () => {
    expect(component).toBeTruthy();
  });



  it('should fetch booking details on initialization if bookingId is provided', () => {
    const mockRoom:StudyRoom={ id: 1, name: 'Room 1',roomNumber:'A101',isAvailable:false }
    const mockBookingDetails:BookingDetails = { bookingId: 1,firstName:"rakesh",lastName:"pernati",email:"rakesh@gmail.com",date:new Date(),studyRoom:mockRoom};
    mockActivatedRoute.snapshot.paramMap.get.and.returnValue('1');
    mockService.getBookingDetailsById.and.returnValue(of({bookingDetails:mockBookingDetails}));
    component.ngOnInit();
    expect(component)

    expect(component.bookingResponse.bookingDetails?.email).toBe('rakesh@gmail.com');
  });




});