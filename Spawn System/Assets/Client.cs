using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Client : MonoBehaviour
{
    public int NumberOfWheels;
    public bool Engine;
    public int Passengers;
    public bool Cargo;

    private int WheelNum;
    private int PeopleNum;

    public TextMeshProUGUI Output;

    public Toggle EngineToggle;
    public Toggle CargoToggle;

    public TMP_InputField WheelAmount;
    public TMP_InputField PeopleAmount;

    void Start()
    {
        NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);
        Engine = Cargo;

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = NumberOfWheels;
        requirements.Engine = Engine;
        requirements.Passengers = Passengers;

        IVehicle v = GetVehicle(requirements);
        Output.text = v.ToString();

        Debug.Log(v);
    }

    public void Create()
    {
        NumberOfWheels = int.Parse(WheelAmount.text);
        Passengers = int.Parse(PeopleAmount.text);

        NumberOfWheels = Mathf.Max(NumberOfWheels, 1);
        Passengers = Mathf.Max(Passengers, 1);
        Engine = Cargo;

        EngineToggle.isOn = Cargo;

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.NumberOfWheels = NumberOfWheels;
        requirements.Engine = Engine;
        requirements.Passengers = Passengers;

        IVehicle v = GetVehicle(requirements);
        Output.text = v.ToString();
        Debug.Log(v);
    }

    public void ToggleChangeEngine(bool tickOn)
    {
        if (tickOn)
            Engine = true; 
        else 
            Engine = false;
    }

    public void ToggleChangeCargo(bool tickOn)
    {
        if (tickOn)
            Cargo = true;
        else
            Cargo = false;
    }

    private static IVehicle GetVehicle(VehicleRequirements requirements)
    {
        VehicleFactory factory = new VehicleFactory(requirements);
        return factory.Create();
    }
}
