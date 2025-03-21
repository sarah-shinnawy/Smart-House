using System;

namespace SmartHomeSystem
{
    // Enum to define device commands
    public enum DeviceCommand
    {
        TurnOn,
        TurnOff,
        SetTemperature,
        ActivateAlarm
    }

    // TODO 1: Define  a delegate named "CommandHandler" that takes a DeviceCommand as a parameter named "command".
    public delegate void CommandHandler(DeviceCommand command);

    public class SmartHomeController
    {
        // TODO2:  Declare an event named "OnCommandReceived" using the delegate
        public event CommandHandler OnCommandReceived;

        public void ExecuteCommand(DeviceCommand command)
        {
            Console.WriteLine($"\n[Controller] Executing command: {command}");

            if (OnCommandReceived != null)
            {
                OnCommandReceived(command);
            }
        }
    }

    // TODO3: Create a  class "Light" with a method "HandleCommand" that reacts to TurnOn and TurnOff commands.
    public class Light
    {
        public void HandleCommand(DeviceCommand command)
        {
            switch (command)
            {
                case DeviceCommand.TurnOn:
                    Console.WriteLine("[Light] Turning on the light.");
                    break;
                case DeviceCommand.TurnOff:
                    Console.WriteLine("[Light] Turning off the light.");
                    break;
                default:
                    Console.WriteLine("[Light] Command not supported.");
                    break;
            }
        }
    }

    // TODO4:Create a class "AC" with a method "HandleCommand" that reacts to SetTemperature and TurnOff commands.
    public class AC
    {
        public void HandleCommand(DeviceCommand command)
        {
            switch (command)
            {
                case DeviceCommand.SetTemperature:
                    Console.WriteLine("[AC] Setting temperature to 22°C.");
                    break;
                case DeviceCommand.TurnOff:
                    Console.WriteLine("[AC] Turning off the AC.");
                    break;
                default:
                    Console.WriteLine("[AC] Command not supported.");
                    break;
            }
        }
    }

    // TODO5: Create a class "Alarm" with a method "HandleCommand" that reacts to ActivateAlarm and TurnOff commands.
    public class Alarm
    {
        public void HandleCommand(DeviceCommand command)
        {
            switch (command)
            {
                case DeviceCommand.ActivateAlarm:
                    Console.WriteLine("[Alarm] Activating the alarm!");
                    break;
                case DeviceCommand.TurnOff:
                    Console.WriteLine("[Alarm] Turning off the alarm.");
                    break;
                default:
                    Console.WriteLine("[Alarm] Command not supported.");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create controller and devices
            SmartHomeController controller = new SmartHomeController();
            Light light = new Light();
            AC ac = new AC();
            Alarm alarm = new Alarm();

            // TODO6: Subscribe the device methods to the controller event.
            controller.OnCommandReceived += light.HandleCommand;
            controller.OnCommandReceived += ac.HandleCommand;
            controller.OnCommandReceived += alarm.HandleCommand;

            // TODO7: Simulate different commands being executed.
            controller.ExecuteCommand(DeviceCommand.TurnOn);
            controller.ExecuteCommand(DeviceCommand.SetTemperature);
            controller.ExecuteCommand(DeviceCommand.ActivateAlarm);
            controller.ExecuteCommand(DeviceCommand.TurnOff);
        }
    }
}