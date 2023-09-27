import { Component, OnInit } from '@angular/core';

import { RoomService } from 'src/app/services/room.service';
import { GlobalConstants } from 'src/shared/constants/global-constants';

@Component({
  selector: 'app-room-screen',
  templateUrl: './room-screen.component.html',
  styleUrls: ['./room-screen.component.css']
})
export class RoomScreenComponent implements OnInit {

  rooms: any[] = [];

  result: any[] = []
  constructor(private roomService: RoomService) {
  }
  ngOnInit(): void {
    this.getRooms()
  }

  getRooms() {
    this.roomService.getRooms().subscribe(
      (data) => {
        this.rooms = data.rooms;
      },
      (error) => {
        alert(GlobalConstants.GENERIC_ERROR);
        this.rooms = []
      }
    );
  }
}
