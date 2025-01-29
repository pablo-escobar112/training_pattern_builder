﻿using System;


public class Car
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public bool TripComputer { get; set; }
    public bool GPS { get; set; }

    public override string ToString()
    {
        return $"Колличество кресел: {Seats} \n{Engine} \nБортовой компьютер: {TripComputer} \nGPS: {GPS}";
    }
}

public class CarManual
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public string TripComputerInstructions { get; set; }
    public string GPSInstructions { get; set; }

    public override string ToString()
    {
        return $"\nРуководство по использованию данного монстра:\n{Engine}\nинструкция бортового компьютера:{TripComputerInstructions}\nинструкциями GPS: {GPSInstructions}";
    }
}

public interface IBuilder
{
    void Reset();
    void SetSeats(int number);
    void SetEngine(string engine);
    void SetTripComputer();
    void SetGPS();
}

public class CarBuilder : IBuilder
{
    private Car _car;

    public CarBuilder()
    {
        _car = new Car();
    }

    public void Reset()
    {
        _car = new Car();
    }

    public void SetSeats(int number)
    {
        _car.Seats = number;
    }

    public void SetEngine(string engine)
    {
        _car.Engine = engine;
    }

    public void SetTripComputer()
    {
        _car.TripComputer = true;
    }

    public void SetGPS()
    {
        _car.GPS = true;
    }

    public Car GetResult()
    {
        return _car;
    }
}

public class CarManualBuilder : IBuilder
{
    private CarManual _manual;

    public CarManualBuilder()
    {
        _manual = new CarManual();
    }

    public void Reset()
    {
        _manual = new CarManual();
    }

    public void SetSeats(int number)
    {
        _manual.Seats = number;
    }

    public void SetEngine(string engine)
    {
        _manual.Engine = engine;
    }

    public void SetTripComputer()
    {
        _manual.TripComputerInstructions = " Стоит чип v3";
    }

    public void SetGPS()
    {
        _manual.GPSInstructions = "Имеет GPS на данном чертолёте";
    }

    public CarManual GetResult()
    {
        return _manual;
    }
}

public class Director
{
    public void MakeSUV(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(4);
        builder.SetEngine("Двигатель на 97 лошадиных сил");
        builder.SetTripComputer();
        builder.SetGPS();
    }

    public void MakeSportsCar(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(4);
        builder.SetEngine("Двигатель на 97 лошадиных сил");
        builder.SetTripComputer();
        builder.SetGPS();
    }
}

public class Programm
{
    public static void Main(string[] args)
    {
        Director director = new Director();

        CarBuilder carBuilder = new CarBuilder();
        director.MakeSportsCar(carBuilder);
        Car car = carBuilder.GetResult();
        Console.WriteLine(car);

        CarManualBuilder manualBuilder = new CarManualBuilder();
        director.MakeSUV(manualBuilder);
        CarManual manual = manualBuilder.GetResult();
        Console.WriteLine(manual);
    }
}
