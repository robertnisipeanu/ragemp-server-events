using System;
using GTANetworkAPI;
using robearded;

namespace AnyNamespace
{
    public class Main : Script
    {

        public Main()
        {
        	JustAClass secondClass = new JustAClass();
		Events.OnPlayerEnterVehicle += VehicleEnter;
        }

	private void VehicleEnter(Client client, Vehicle vehicle, sbyte seatID){
		Console.WriteLine($"Player {client.Name} entered vehicle id {vehicle.Value}");
	}
		
    }
}
