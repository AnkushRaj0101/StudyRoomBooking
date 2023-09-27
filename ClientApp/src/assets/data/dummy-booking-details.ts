import { BookingDetails } from "src/app/model/bookingdetails";

export const bookingDetailsArray: BookingDetails[] = [
    {
        bookingId: 1,
        firstName: "Rakesh",
        lastName: "pernati",
        email: "rakesh@gmail.com",
        date: new Date(2023, 8, 21),  
        studyRoom: {
            id: 101,
            name: "Study Room A",
            roomNumber: "A-101",
            isAvailable: false      
      }
    },
    {
        firstName: "Siva",
        lastName: "kamireddy",
        email: "siva@gmail.com",
        bookingId: 2,
        date: new Date(2023, 8, 21),  
        studyRoom: {
            id: 102,
            name: "Study Room B",
            roomNumber: "A-102",
            isAvailable: false
        }
    },
    {
        bookingId: 3,
        firstName: "Ankush",
        lastName: "raj",
        email: "ankush@gmail.com",
        date: new Date(2023, 8, 21),  
        studyRoom: {
            id: 103,
            name: "Study Room c",
            roomNumber: "A-103",
            isAvailable: false
        }
    },
    {
        firstName: "Chandra",
        lastName: "sekhar",
        email: "chandra@gmail.com",
        bookingId: 4,
        date: new Date(2023, 8, 21),  
        studyRoom: {
            id: 104,
            name: "Study Room B",
            roomNumber: "A-104",
            isAvailable: false
        }
    },
   
];
