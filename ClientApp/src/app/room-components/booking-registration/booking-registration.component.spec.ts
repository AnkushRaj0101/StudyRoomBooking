import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingRegistrationComponent } from './booking-registration.component';

describe('BookingRegistrationComponent', () => {
  let component: BookingRegistrationComponent;
  let fixture: ComponentFixture<BookingRegistrationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BookingRegistrationComponent]
    });
    fixture = TestBed.createComponent(BookingRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  xit('should create', () => {
    expect(component).toBeTruthy();
  });
});
