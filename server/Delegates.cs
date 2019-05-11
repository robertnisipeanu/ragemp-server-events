using System;
using GTANetworkAPI;

namespace robearded.Delegates
{
    public class EventDelegates
    {
        public delegate void OnChatMessage(Client client, string message);
        public delegate void OnEntityCreated(NetHandle entity);
        public delegate void OnEntityDeleted(NetHandle entity);
        public delegate void OnEntityModelChange(NetHandle entity, uint oldModel);
        public delegate void OnFirstChanceException(Exception exception);
        public delegate void OnMapChange(string mapName, XmlGroup map);
        public delegate void OnPlayerConnected(Client client);
        public delegate void OnPlayerDamage(Client client, float healthLoss, float armosLoss);
        public delegate void OnPlayerDeath(Client client, Client killer, uint reason);
        public delegate void OnPlayerDetonateStickies(Client client);
        public delegate void OnPlayerDisconnected(Client client, DisconnectionType type, string reason);
        public delegate void OnPlayerEnterCheckpoint(Checkpoint checkpoint, Client client);
        public delegate void OnPlayerEnterColshape(ColShape colShape, Client client);
        public delegate void OnPlayerEnterVehicle(Client client, Vehicle vehicle, sbyte seatID);
        public delegate void OnPlayerEnterVehicleAttempt(Client client, Vehicle vehicle, sbyte seatID);
        public delegate void OnPlayerExitCheckpoint(Checkpoint checkpoint, Client client);
        public delegate void OnPlayerExitColshape(ColShape colShape, Client client);
        public delegate void OnPlayerExitVehicle(Client client, Vehicle vehicle);
        public delegate void OnPlayerExitVehicleAttempt(Client client, Vehicle vehicle);
        public delegate void OnPlayerPickup(Client client, Pickup pickup);
        public delegate void OnPlayerSpawn(Client client);
        public delegate void OnPlayerWeaponSwitch(Client client, WeaponHash oldWeaponHash, WeaponHash newWeaponHash);
        public delegate void OnResourceStart();
        public delegate void OnResourceStartEx(string resourceName);
        public delegate void OnResourceStop();
        public delegate void OnResourceStopEx(string resourceName);
        public delegate void OnUpdate();
        public delegate void OnVehicleDamage(Vehicle vehicle, float bodyHealthLoss, float engineHealthLoss);
        public delegate void OnVehicleDeath(Vehicle vehicle);
        public delegate void OnVehicleDoorBreak(Vehicle vehicle, int index);
        public delegate void OnVehicleHornToggle(Vehicle vehicle);
        public delegate void OnVehicleSirenToggle(Vehicle vehicle);
        public delegate void OnVehicleTrailerChange(Vehicle vehicle, Vehicle trailer);
        public delegate void OnVehicleTyreBurst(Vehicle vehicle, int index);
        public delegate void OnVehicleWindowSmash(Vehicle vehicle, int index);

		// Events not available by default on C# API and custom added by this resource:
        public delegate void OnPlayerReady(Client client);
        public delegate void OnPlayerCommand(Client client, string cmd, string arg);
    }
}
