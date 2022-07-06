// ------------------------------------------------------------------------------
// <auto-generated>
//     This file is generated by tool.
//     Runtime Version : 0.0.1
//  
//     Updates this file cause incorrect behavior 
//     and will be lost when the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Kae.StateMachine;
using Kae.Utility.Logging;

namespace LaundromatInHotel
{
    public partial class DomainClassReservableWashingMachineBase : DomainClassReservableWashingMachine
    {
        private static readonly string className = "ReservableWashingMachine";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassReservableWashingMachineBase CreateInstance(InstanceRepository instanceRepository, Logger logger)
        {
            var newInstance = new DomainClassReservableWashingMachineBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:ReservableWashingMachine(MachineID={newInstance.Attr_MachineID}):create");

            instanceRepository.Add(newInstance);

            return newInstance;
        }

        public DomainClassReservableWashingMachineBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            stateMachine = new DomainClassReservableWashingMachineStateMachine(this, logger);
        }

        string attr_MachineID;
        bool stateof_MachineID = false;

        DomainClassReservableWashingMachineStateMachine stateMachine;
        bool stateof_current_state = false;

        string attr_Next_ReservationID;
        bool stateof_Next_ReservationID = false;


        public string Attr_MachineID { get { return attr_MachineID; } }
        public int Attr_current_state { get { return stateMachine.CurrentState; } }
        public string Attr_Next_ReservationID { get { return attr_Next_ReservationID; } }

        private DomainClassWashingMachine relR15WashingMachine;
        private DomainClassWashingMachineReservation relR19WashingMachineReservationNextReservation;

        public DomainClassWashingMachine GetSuperClassR15()
        {
            if (relR15WashingMachine == null)
            {
                var candidates = instanceRepository.GetDomainInstances("WashingMachine").Where(inst => (this.Attr_MachineID==((DomainClassWashingMachine)inst).Attr_MachineID));
                relR15WashingMachine = (DomainClassWashingMachine)candidates.First();
            }
            return relR15WashingMachine;
        }
        public bool LinkR15(DomainClassWashingMachine instance)
        {
            bool result = false;
            if (relR15WashingMachine == null)
            {
                this.attr_MachineID = instance.Attr_MachineID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:ReservableWashingMachine(MachineID={this.Attr_MachineID}):link[WashingMachine(MachineID={instance.Attr_MachineID})]");

                result = true;
            }
            return result;
        }
        public bool UnlinkR15(DomainClassWashingMachine instance)
        {
            bool result = false;
            if (relR15WashingMachine != null && ( this.Attr_MachineID==instance.Attr_MachineID ))
            {
                this.attr_MachineID = null;
                relR15WashingMachine = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:ReservableWashingMachine(MachineID={this.Attr_MachineID}):unlink[WashingMachine(MachineID={instance.Attr_MachineID})]");

                result = true;
            }
            return result;
        }

        public DomainClassWashingMachineReservation LinkedR19NextReservation()
        {
            if (relR19WashingMachineReservationNextReservation == null)
            {
                var candidates = instanceRepository.GetDomainInstances("WashingMachineReservation").Where(inst=>(this.Attr_Next_ReservationID==((DomainClassWashingMachineReservation)inst).Attr_ReservationID));
                relR19WashingMachineReservationNextReservation = (DomainClassWashingMachineReservation)candidates.First();
            }
            return relR19WashingMachineReservationNextReservation;
        }

        public bool LinkR19NextReservation(DomainClassWashingMachineReservation instance)
        {
            bool result = false;
            if (relR19WashingMachineReservationNextReservation == null)
            {
                this.attr_Next_ReservationID = instance.Attr_ReservationID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:ReservableWashingMachine(MachineID={this.Attr_MachineID}):link[WashingMachineReservation(ReservationID={instance.Attr_ReservationID})]");

                result = true;
            }
            return result;
        }
        public bool UnlinkR19NextReservation(DomainClassWashingMachineReservation instance)
        {
            bool result = false;
            if (relR19WashingMachineReservationNextReservation != null && ( this.Attr_Next_ReservationID==instance.Attr_ReservationID ))
            {
                this.attr_Next_ReservationID = null;
                relR19WashingMachineReservationNextReservation = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:ReservableWashingMachine(MachineID={this.Attr_MachineID}):unlink[WashingMachineReservation(ReservationID={instance.Attr_ReservationID})]");


                result = true;
            }
            return result;
        }
        public void TakeEvent(EventData domainEvent)
        {
            stateMachine.ReceivedEvent(domainEvent).Wait();
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:ReservableWashingMachine(MachineID={this.Attr_MachineID}):takeEvent({domainEvent.EventNumber})");
        }

        
        public bool Validate()
        {
            bool isValid = true;
            if (relR15WashingMachine == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void Dispose()
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:ReservableWashingMachine(MachineID={this.Attr_MachineID}):delete");

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(Dictionary<string, object> propertyValues)
        {
            attr_MachineID = (string)propertyValues["MachineID"];
            stateof_MachineID = false;
            stateMachine.ForceUpdateState((int)propertyValues["current_state"]);
            attr_Next_ReservationID = (string)propertyValues["Next_ReservationID"];
            stateof_Next_ReservationID = false;
        }
        
        public Dictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_MachineID)
            {
                results.Add("MachineID", attr_MachineID);
                stateof_MachineID = false;
            }
            results.Add("current_state", stateMachine.CurrentState);
            if (stateof_Next_ReservationID)
            {
                results.Add("Next_ReservationID", attr_Next_ReservationID);
                stateof_Next_ReservationID = false;
            }

            return results;
        }
        
        public Dictionary<string, object> GetProperties()
        {
            var results = new Dictionary<string, object>();
            results.Add("MachineID", attr_MachineID);
            results.Add("current_state", stateMachine.CurrentState);
            results.Add("Next_ReservationID", attr_Next_ReservationID);

            return results;
        }

    }
}
