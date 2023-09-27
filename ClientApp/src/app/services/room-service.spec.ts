import { TestBed } from '@angular/core/testing';
import { RoomService } from './room.service';
import { of } from 'rxjs';
import { ApiServiceService } from 'src/shared/services/api-service.service';

describe('RoomService', () => {
  let roomService: RoomService;
  let apiService: jasmine.SpyObj<ApiServiceService>;

  beforeEach(() => {
    const spy = jasmine.createSpyObj('apiService', ['Get']); // Update method name
    TestBed.configureTestingModule({
      providers: [
        RoomService,
        { provide: ApiServiceService, useValue: spy }
      ],
    });
    roomService = TestBed.inject(RoomService);
    apiService = TestBed.inject(ApiServiceService) as jasmine.SpyObj<ApiServiceService>;
  });

  it('should be created', () => {
    expect(roomService).toBeTruthy();
  });


  it('should return rooms from the common service', () => {
    const mockRooms = [{ id: 1, name: 'Room 1', roomNumber: 'A101', isAvailable: true },
                      { id: 2, name: 'Room 2', roomNumber: 'B746', isAvailable: true }];
  
    apiService.Get.and.returnValue(of(mockRooms)); // Update method name
  
    roomService.getRooms().subscribe(rooms => { // Pass 'rooms' as the endpoint
      expect(rooms).toEqual(mockRooms);
    });
  
    expect(apiService.Get).toHaveBeenCalled();
  });

});
