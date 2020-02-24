using System;
using System.Collections.Generic;
using System.Text;

namespace GunnarsAuto
{
    public class Car
    {
        public string make;
        public string model;
        public string chassisNumber;
        public string registrationNumber;
        public string carType;

        public Car(string make, string model, string chassisNumber, string registrationNumber, string carType)
        {
            
            Make = make;
            Model = model;
            ChassisNumber = chassisNumber;
            RegistrationNumber = registrationNumber;
            CarType = carType;
        }
        public string Make{ get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public string ChassisNumber { get { return chassisNumber; } set { chassisNumber = value; } }
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } }
        public string CarType { get { return carType; } set { carType = value; } }
    }
}