import { ComponentFixture, TestBed } from '@angular/core/testing';
import { DebugElement } from '@angular/core';
import { RoomBookingDetailsComponent } from './room-booking-details.component';
import { HttpClientTestingModule } from '@angular/common/http/testing'; // Import HttpClientTestingModule // Import your ApiServiceService
import { ApiServiceService } from 'src/shared/services/api-service.service';
import { RoomBookingDetailsService } from 'src/app/services/room-booking-details.service';
describe('RoomBookingDetailsComponent', () => {
  let component: RoomBookingDetailsComponent;
  let fixture: ComponentFixture<RoomBookingDetailsComponent>;
  let debugElement: DebugElement;
  let roomBookingService: jasmine.SpyObj<RoomBookingDetailsService>;

  beforeEach(() => {

    const roomBookingServiceSpy = jasmine.createSpyObj('RoomBookingDetailsService', ['getAllBookings']);

    
    TestBed.configureTestingModule({
      declarations: [RoomBookingDetailsComponent],
      imports: [HttpClientTestingModule], 
      providers: [ApiServiceService
      ],
      
    });

    fixture = TestBed.createComponent(RoomBookingDetailsComponent);
    component = fixture.componentInstance;
    debugElement = fixture.debugElement;
   
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
 
});
