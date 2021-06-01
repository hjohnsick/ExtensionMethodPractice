using System;

namespace ExtensionMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelRoomModel hotelRoom = new HotelRoomModel();
            hotelRoom.TurnOnAir().SetTemperature(72).OpenShades();
            hotelRoom.TurnOffAir().CloseShades();
            PersonModel person = new PersonModel();
            person.SetDefaultAge().PrintInfo("Lucy", "Lu");

            "Hello World".PrintToConsole();
            Console.ReadLine();
        }
    }

    public class HotelRoomModel
    {
        public int Temperature { get; set; }
        public bool IsAirRunning { get; set; }
        public bool AreShadesOpen { get; set; }
    }

    public class PersonModel
    {
        public int Age { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    //Extension methods have to be in a static class and the methods also have to be static.  The this keyword is critical.
    //Without it, it is just a normal method
    public static class ExtensionSamples
    {
        public static PersonModel SetDefaultAge(this PersonModel person)
        {
            person.Age = 18;
            return person;
        }

        public static void PrintInfo(this PersonModel person, string firstName, string lastName)
        {
            person.SetDefaultAge();
            person.FirstName = firstName;
            person.LastName = lastName;
            Console.WriteLine($"First Name: {person.FirstName} Last Name: {person.LastName} Age: {person.Age}");
        }
        public static void PrintToConsole(this string message)
        {
            Console.WriteLine(message);
        }

        public static HotelRoomModel TurnOffAir(this HotelRoomModel room)
        {
            room.IsAirRunning = false;
            return room;
        }

        public static HotelRoomModel TurnOnAir(this HotelRoomModel room)
        {
            room.IsAirRunning = true;
            return room;
        }

        public static HotelRoomModel SetTemperature(this HotelRoomModel room, int temperature)
        {
            room.Temperature = temperature;
            return room;
        }

        public static HotelRoomModel OpenShades(this HotelRoomModel room)
        {
            room.AreShadesOpen = true;
            return room;
        }

        public static HotelRoomModel CloseShades(this HotelRoomModel room)
        {
            room.AreShadesOpen = false;
            return room;
        }
    }
}
