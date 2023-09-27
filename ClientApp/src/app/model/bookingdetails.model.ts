import { StudyRoom } from "./studyroom.model";

export class BookingDetails{
  bookingId?:number;
  firstName?:string;
  lastName?:string;
  email?:string;
  date?:Date;
  studyRoom?:StudyRoom;
}
