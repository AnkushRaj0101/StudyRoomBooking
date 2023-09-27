import { StudyRoom } from "./studyroom"

export class BookingDetails{
    public bookingId?:number
    public firstName?:string
    public lastName?:string
    public email?:string
    public date?:Date
    public studyRoom?:StudyRoom
     constructor(){}
}