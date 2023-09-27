import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { RoomScreenComponent } from './room-screen.component';
import { RoomService } from 'src/app/services/room.service';

describe('RoomScreenComponent', () => {
  let component: RoomScreenComponent;
  let fixture: ComponentFixture<RoomScreenComponent>;
  let roomService: jasmine.SpyObj<RoomService>;

  beforeEach(() => {
    const roomServiceSpy = jasmine.createSpyObj('RoomService', ['getRooms']);

    TestBed.configureTestingModule({
      declarations: [RoomScreenComponent],
      providers: [{ provide: RoomService, useValue: roomServiceSpy }]
    });

    fixture = TestBed.createComponent(RoomScreenComponent);
    component = fixture.componentInstance;
    roomService = TestBed.inject(RoomService) as jasmine.SpyObj<RoomService>;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch and display rooms', () => {
    const mockRooms = [{ id: 1, name: 'Room 1' }, { id: 2, name: 'Room 2' }];
    roomService.getRooms.and.returnValue(of(mockRooms));
    fixture.detectChanges();
    expect(roomService.getRooms).toHaveBeenCalled();
  });

 
});
