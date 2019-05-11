using System;
using System.Collections.Generic;
using GTANetworkAPI;
using robearded.Delegates;

namespace robearded
{
    public class Events : Script
    {
        public static EventDelegates.OnChatMessage OnChatMessage;
        public static EventDelegates.OnEntityCreated OnEntityCreated;
        public static EventDelegates.OnEntityDeleted OnEntityDeleted;
        public static EventDelegates.OnEntityModelChange OnEntityModelChange;
        public static EventDelegates.OnFirstChanceException OnFirstChanceException;
        public static EventDelegates.OnMapChange OnMapChange;
        public static EventDelegates.OnPlayerConnected OnPlayerConnected;
        public static EventDelegates.OnPlayerReady OnPlayerReady;
        public static EventDelegates.OnPlayerDamage OnPlayerDamage;
        public static EventDelegates.OnPlayerDeath OnPlayerDeath;
        public static EventDelegates.OnPlayerDetonateStickies OnPlayerDetonateStickies;
        public static EventDelegates.OnPlayerDisconnected OnPlayerDisconnected;
        public static EventDelegates.OnPlayerEnterCheckpoint OnPlayerEnterCheckpoint;
        public static EventDelegates.OnPlayerEnterColshape OnPlayerEnterColshape;
        public static EventDelegates.OnPlayerEnterVehicle OnPlayerEnterVehicle;
        public static EventDelegates.OnPlayerEnterVehicleAttempt OnPlayerEnterVehicleAttempt;
        public static EventDelegates.OnPlayerExitCheckpoint OnPlayerExitCheckpoint;
        public static EventDelegates.OnPlayerExitColshape OnPlayerExitColshape;
        public static EventDelegates.OnPlayerExitVehicle OnPlayerExitVehicle;
        public static EventDelegates.OnPlayerExitVehicleAttempt OnPlayerExitVehicleAttempt;
        public static EventDelegates.OnPlayerPickup OnPlayerPickup;
        public static EventDelegates.OnPlayerSpawn OnPlayerSpawn;
        public static EventDelegates.OnPlayerWeaponSwitch OnPlayerWeaponSwitch;
        public static EventDelegates.OnResourceStart OnResourceStart;
        public static EventDelegates.OnResourceStartEx OnResourceStartEx;
        public static EventDelegates.OnResourceStop OnResourceStop;
        public static EventDelegates.OnResourceStopEx OnResourceStopEx;
        public static EventDelegates.OnUpdate OnUpdate;
        public static EventDelegates.OnVehicleDamage OnVehicleDamage;
        public static EventDelegates.OnVehicleDeath OnVehicleDeath;
        public static EventDelegates.OnVehicleDoorBreak OnVehicleDoorBreak;
        public static EventDelegates.OnVehicleHornToggle OnVehicleHornToggle;
        public static EventDelegates.OnVehicleSirenToggle OnVehicleSirenToggle;
        public static EventDelegates.OnVehicleTrailerChange OnVehicleTrailerChange;
        public static EventDelegates.OnVehicleTyreBurst OnVehicleTyreBurst;
        public static EventDelegates.OnVehicleWindowSmash OnVehicleWindowSmash;

        private static Dictionary<string, EventDelegates.OnPlayerCommand> OnPlayerCommand = new Dictionary<string, EventDelegates.OnPlayerCommand>(); // The key of the dictionary is the command name
        private static HashSet<Client> readyClients = new HashSet<Client>();

        public Events()
        {
            Events.OnPlayerDisconnected += OnPlayerDisconnect;
            Events.OnPlayerReady += PlayerReady_Event;
        }

        #region Commands
		
		/// <summary>
		/// Use this function to register a command.
		/// Example: robearded.Events.AddCommand("mycommand", CommandHandler);
		/// </summary>
        public static void AddCommand(string command, EventDelegates.OnPlayerCommand method)
        {
            if (OnPlayerCommand.ContainsKey(command.ToLower()))
                OnPlayerCommand[command.ToLower()] += method;
            else
            {
                OnPlayerCommand[command.ToLower()] = method;
                RegisterCommandToPlayers(command);
            }
        }

        private void PlayerReady_Event(Client client)
        {
            readyClients.Add(client);
            foreach (string command in OnPlayerCommand.Keys)
            {
                RegisterCommandToPlayer(command, client);
            }
        }

        private static void OnPlayerDisconnect(Client client, DisconnectionType type, string reason)
        {
            if (readyClients.Contains(client)) readyClients.Remove(client);
        }

        private static void RegisterCommandToPlayers(string command)
        {
            foreach(Client client in NAPI.Pools.GetAllPlayers()){
                if (readyClients.Contains(client)) RegisterCommandToPlayer(command, client); 
            }
        }

        private static void RegisterCommandToPlayer(string command, Client client)
        {
            client.TriggerEvent("registerCustomCommand", new object[] { command, true });
        }

        [RemoteEvent("sendCustomCommand")]
        private void CustomCommand_Event(Client client, string cmd, string args)
        {
            if (OnPlayerCommand.ContainsKey(cmd.ToLower()))
                OnPlayerCommand[cmd.ToLower()]?.Invoke(client, cmd.ToLower(), args);
        }
        #endregion

		#region Events
        [ServerEvent(Event.ChatMessage)]
        private void ChatMessage_Event(Client client, string message)
        {
            OnChatMessage?.Invoke(client, message);
        }

        [ServerEvent(Event.EntityCreated)]
        private void EntityCreated_Event(NetHandle entity)
        {
            OnEntityCreated?.Invoke(entity);
        }

        [ServerEvent(Event.EntityDeleted)]
        private void EntityDeleted_Event(NetHandle entity)
        {
            OnEntityDeleted?.Invoke(entity);
        }

        [ServerEvent(Event.EntityModelChange)]
        private void EntityModelChange_Event(NetHandle entity, uint oldModel)
        {
            OnEntityModelChange?.Invoke(entity, oldModel);
        }

        [ServerEvent(Event.FirstChanceException)]
        private void FirstChanceException_Event(Exception exception)
        {
            OnFirstChanceException?.Invoke(exception);
        }

        [ServerEvent(Event.MapChange)]
        private void MapChange_Event(string mapName, XmlGroup map)
        {
            OnMapChange?.Invoke(mapName, map);
        }

        [ServerEvent(Event.PlayerConnected)]
        private void PlayerConnected_Event(Client client)
        {
            OnPlayerConnected?.Invoke(client);
        }

        [RemoteEvent("playerReady")]
        private void playerReady_Test(Client client, object[] args)
        {
            OnPlayerReady?.Invoke(client);
        }

        [ServerEvent(Event.PlayerDamage)]
        private void PlayerDamage_Event(Client client, float healthLoss, float armorLoss)
        {
            OnPlayerDamage?.Invoke(client, healthLoss, armorLoss);
        }

        [ServerEvent(Event.PlayerDeath)]
        private void PlayerDeath_Event(Client client, Client killer, uint reason)
        {
            OnPlayerDeath?.Invoke(client, killer, reason);
        }

        [ServerEvent(Event.PlayerDetonateStickies)]
        private void PlayerDetonateStickies_Event(Client client)
        {
            OnPlayerDetonateStickies?.Invoke(client);
        }

        [ServerEvent(Event.PlayerDisconnected)]
        private void PlayerDisconnected_Event(Client client, DisconnectionType type, string reason)
        {
            OnPlayerDisconnected?.Invoke(client, type, reason);
        }

        [ServerEvent(Event.PlayerEnterCheckpoint)]
        private void PlayerEnterCheckpoint_Event(Checkpoint checkpoint, Client client)
        {
            OnPlayerEnterCheckpoint?.Invoke(checkpoint, client);
        }

        [ServerEvent(Event.PlayerEnterColshape)]
        private void PlayerEnterColshape_Event(ColShape colShape, Client client)
        {
            OnPlayerEnterColshape?.Invoke(colShape, client);
        }

        [ServerEvent(Event.PlayerEnterVehicle)]
        private void PlayerEnterVehicle_Event(Client client, Vehicle vehicle, sbyte seatID)
        {
            OnPlayerEnterVehicle?.Invoke(client, vehicle, seatID);
        }

        [ServerEvent(Event.PlayerEnterVehicleAttempt)]
        private void PlayerEnterVehicleAttempt_Event(Client client, Vehicle vehicle, sbyte seatID)
        {
            OnPlayerEnterVehicleAttempt?.Invoke(client, vehicle, seatID);
        }

        [ServerEvent(Event.PlayerExitCheckpoint)]
        private void PlayerExitCheckPoint_Event(Checkpoint checkpoint, Client client)
        {
            OnPlayerExitCheckpoint?.Invoke(checkpoint, client);
        }
        
        [ServerEvent(Event.PlayerExitColshape)]
        private void PlayerExitColshape_Event(ColShape colShape, Client client)
        {
            OnPlayerExitColshape?.Invoke(colShape, client);
        }

        [ServerEvent(Event.PlayerExitVehicle)]
        private void PlayerExitVehicle_Event(Client client, Vehicle vehicle)
        {
            OnPlayerExitVehicle?.Invoke(client, vehicle);
        }

        [ServerEvent(Event.PlayerExitVehicleAttempt)]
        private void PlayerExitVehicleAttempt_Event(Client client, Vehicle vehicle)
        {
            OnPlayerExitVehicleAttempt?.Invoke(client, vehicle);
        }

        [ServerEvent(Event.PlayerPickup)]
        private void PlayerPickup_Event(Client client, Pickup pickup)
        {
            OnPlayerPickup?.Invoke(client, pickup);
        }

        [ServerEvent(Event.PlayerSpawn)]
        private void PlayerSpawn_Event(Client client)
        {
            OnPlayerSpawn?.Invoke(client);
        }

        [ServerEvent(Event.PlayerWeaponSwitch)]
        private void PlayerWeaponSwitch_Event(Client client, WeaponHash oldWeaponHash, WeaponHash newWeaponHash)
        {
            OnPlayerWeaponSwitch?.Invoke(client, oldWeaponHash, newWeaponHash);
        }

        [ServerEvent(Event.ResourceStart)]
        private void ResourceStart_Event()
        {
            OnResourceStart?.Invoke();
        }

        [ServerEvent(Event.ResourceStartEx)]
        private void ResourceStartEx_Event(string resourceName)
        {
            OnResourceStartEx?.Invoke(resourceName);
        }

        [ServerEvent(Event.ResourceStop)]
        private void ResourceStop_Event()
        {
            OnResourceStop?.Invoke();
        }

        [ServerEvent(Event.ResourceStopEx)]
        private void ResourceStopEx_Event(string resourceName)
        {
            OnResourceStopEx?.Invoke(resourceName);
        }

        [ServerEvent(Event.Update)]
        private void Update_Event()
        {
            OnUpdate?.Invoke();
        }

        [ServerEvent(Event.VehicleDamage)]
        private void VehicleDamage_Event(Vehicle vehicle, float bodyHealthLoss, float engineHealthLoss)
        {
            OnVehicleDamage?.Invoke(vehicle, bodyHealthLoss, engineHealthLoss);
        }

        [ServerEvent(Event.VehicleDeath)]
        private void VehicleDeath_Event(Vehicle vehicle)
        {
            OnVehicleDeath?.Invoke(vehicle);
        }

        [ServerEvent(Event.VehicleDoorBreak)]
        private void VehicleDoorBreak_Event(Vehicle vehicle, int index)
        {
            OnVehicleDoorBreak?.Invoke(vehicle, index);
        }

        [ServerEvent(Event.VehicleHornToggle)]
        private void VehicleHornToggle_Event(Vehicle vehicle)
        {
            OnVehicleHornToggle?.Invoke(vehicle);
        }

        [ServerEvent(Event.VehicleSirenToggle)]
        private void VehicleSirenToggle_Event(Vehicle vehicle)
        {
            OnVehicleSirenToggle?.Invoke(vehicle);
        }

        [ServerEvent(Event.VehicleTrailerChange)]
        private void VehicleTrailerChange_Event(Vehicle vehicle, Vehicle trailer)
        {
            OnVehicleTrailerChange?.Invoke(vehicle, trailer);
        }

        [ServerEvent(Event.VehicleTyreBurst)]
        private void VehicleTyreBurst_Event(Vehicle vehicle, int index)
        {
            OnVehicleTyreBurst?.Invoke(vehicle, index);
        }

        [ServerEvent(Event.VehicleWindowSmash)]
        private void VehicleWindowSmash(Vehicle vehicle, int index)
        {
            OnVehicleWindowSmash?.Invoke(vehicle, index);
        }
		#endregion

    }
}
