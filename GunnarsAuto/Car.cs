using System;
using System.Collections.Generic;
using System.Text;

namespace GunnarsAuto
{
    class Car
    {
        public int carId;
        public string make;
        public string model;
        public string chassisNumber;
        public string registrationNumber;
        public string carType;

        public Car(int carId, string make, string model, string chassisNumber, string registrationNumber, string carType)
        {
            CarId = CarId;
            Make = make;
            Model = model;
            ChassisNumber = chassisNumber;
            RegistrationNumber = registrationNumber;
            CarType = carType;
        }
        public int CarId { get { return carId; } set { carId = value; } }
        public string Make{ get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public string ChassisNumber { get { return chassisNumber; } set { chassisNumber = value; } }
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } }
        public string CarType { get { return carType; } set { carType = value; } }
    }
}
