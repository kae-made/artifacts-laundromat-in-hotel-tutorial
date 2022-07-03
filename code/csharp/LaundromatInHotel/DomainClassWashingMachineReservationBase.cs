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
    public partial class DomainClassWashingMachineReservationBase : DomainClassWashingMachineReservation
    {
        private static readonly string className = "WashingMachineReservation";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassWashingMachineReservationBase CreateInstance(InstanceRepository instanceRepository, Logger logger)
        {
            var newInstance = new DomainClassWashingMachineReservationBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineReservation(ReservationID={newInstance.Attr_ReservationID}):create");
            instanceRepository.Add(newInstance);

            return newInstance;
        }

        public DomainClassWashingMachineReservationBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_ReservationID = Guid.NewGuid().ToString();
            stateMachine = new DomainClassWashingMachineReservationStateMachine(this, logger);
        }

        string attr_ReservationID;
        DateTime attr_ReservationTime;
        DateTime attr_EstimatedEndTime;
        int attr_PreAlarmTime;
        string attr_GuestStayID;
        string attr_WorkingSpecID;
        string attr_successor_ReservationID;
        DomainClassWashingMachineReservationStateMachine stateMachine;
        string attr_MachineID;
        string attr_AlarmTimer;

        public string Attr_ReservationID { get { return attr_ReservationID; } set { attr_ReservationID = value; } }
        public DateTime Attr_ReservationTime { get { return attr_ReservationTime; } set { attr_ReservationTime = value; } }
        public DateTime Attr_EstimatedEndTime { get { return attr_EstimatedEndTime; } set { attr_EstimatedEndTime = value; } }
        public int Attr_PreAlarmTime { get { return attr_PreAlarmTime; } set { attr_PreAlarmTime = value; } }
        public string Attr_GuestStayID { get { return attr_GuestStayID; } }
        public string Attr_WorkingSpecID { get { return attr_WorkingSpecID; } }
        public string Attr_successor_ReservationID { get { return attr_successor_ReservationID; } }
        public int Attr_current_state { get { return stateMachine.CurrentState; } }
        public string Attr_MachineID { get { return attr_MachineID; } }
        public string Attr_AlarmTimer { get { return attr_AlarmTimer; } set { attr_AlarmTimer = value; } }

        private DomainClassGuestStay relR12GuestStayReservationOwner;
        private DomainClassAvailableWorkingSpec relR13AvailableWorkingSpecTarget;
        private DomainClassWashingMachineReservation relR17WashingMachineReservationSuccessor;

        public DomainClassGuestStay LinkedR12ReservationOwner()
        {
            if (relR12GuestStayReservationOwner == null)
            {
                var candidates = instanceRepository.GetDomainInstances("GuestStay").Where(inst=>(this.Attr_GuestStayID==((DomainClassGuestStay)inst).Attr_GuestStayID));
                relR12GuestStayReservationOwner = (DomainClassGuestStay)candidates.First();
            }
            return relR12GuestStayReservationOwner;
        }

        public bool LinkR12ReservationOwner(DomainClassGuestStay instance)
        {
            bool result = false;
            if (relR12GuestStayReservationOwner == null)
            {
                this.attr_GuestStayID = instance.Attr_GuestStayID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineReservation(ReservationID={this.Attr_ReservationID}):linked[from(GuestStay(GuestStayID={instance.Attr_GuestStayID}))]");
                result = true;
            }
            return result;
        }
        public bool UnlinkR12ReservationOwner(DomainClassGuestStay instance)
        {
            bool result = false;
            if (relR12GuestStayReservationOwner != null && ( this.Attr_GuestStayID==instance.Attr_GuestStayID ))
            {
                this.attr_GuestStayID = null;
                relR12GuestStayReservationOwner = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineReservation(ReservationID={this.Attr_ReservationID}):unlinked[from(GuestStay(GuestStayID={instance.Attr_GuestStayID}))]");
                result = true;
            }
            return result;
        }
        public DomainClassAvailableWorkingSpec LinkedR13Target()
        {
            if (relR13AvailableWorkingSpecTarget == null)
            {
                var candidates = instanceRepository.GetDomainInstances("AvailableWorkingSpec").Where(inst=>(this.Attr_WorkingSpecID==((DomainClassAvailableWorkingSpec)inst).Attr_WorkingSpecID && this.Attr_MachineID==((DomainClassAvailableWorkingSpec)inst).Attr_MachineID));
                relR13AvailableWorkingSpecTarget = (DomainClassAvailableWorkingSpec)candidates.First();
            }
            return relR13AvailableWorkingSpecTarget;
        }

        public bool LinkR13Target(DomainClassAvailableWorkingSpec instance)
        {
            bool result = false;
            if (relR13AvailableWorkingSpecTarget == null)
            {
                this.attr_WorkingSpecID = instance.Attr_WorkingSpecID;
                this.attr_MachineID = instance.Attr_MachineID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineReservation(ReservationID={this.Attr_ReservationID}):linked[from(AvailableWorkingSpec(MachineID={instance.Attr_MachineID},WorkingSpecID={instance.Attr_WorkingSpecID}))]");
                result = true;
            }
            return result;
        }
        public bool UnlinkR13Target(DomainClassAvailableWorkingSpec instance)
        {
            bool result = false;
            if (relR13AvailableWorkingSpecTarget != null && ( this.Attr_WorkingSpecID==instance.Attr_WorkingSpecID && this.Attr_MachineID==instance.Attr_MachineID ))
            {
                this.attr_WorkingSpecID = null;
                this.attr_MachineID = null;
                relR13AvailableWorkingSpecTarget = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineReservation(ReservationID={this.Attr_ReservationID}):unlinked[from(AvailableWorkingSpec(MachineID={instance.Attr_MachineID},WorkingSpecID={instance.Attr_WorkingSpecID}))]");
                result = true;
            }
            return result;
        }
        public DomainClassWashingMachineReservation LinkedR17Successor()
        {
            if (relR17WashingMachineReservationSuccessor == null)
            {
                var candidates = instanceRepository.GetDomainInstances("WashingMachineReservation").Where(inst=>(this.Attr_successor_ReservationID==((DomainClassWashingMachineReservation)inst).Attr_ReservationID));
                relR17WashingMachineReservationSuccessor = (DomainClassWashingMachineReservation)candidates.First();
            }
            return relR17WashingMachineReservationSuccessor;
        }

        public bool LinkR17Successor(DomainClassWashingMachineReservation instance)
        {
            bool result = false;
            if (relR17WashingMachineReservationSuccessor == null)
            {
                this.attr_successor_ReservationID = instance.Attr_ReservationID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineReservation(ReservationID={this.Attr_ReservationID}):linked[from(WashingMachineReservation(ReservationID={instance.Attr_ReservationID}))]");
                result = true;
            }
            return result;
        }
        public bool UnlinkR17Successor(DomainClassWashingMachineReservation instance)
        {
            bool result = false;
            if (relR17WashingMachineReservationSuccessor != null && ( this.Attr_successor_ReservationID==instance.Attr_ReservationID ))
            {
                this.attr_successor_ReservationID = null;
                relR17WashingMachineReservationSuccessor = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineReservation(ReservationID={this.Attr_ReservationID}):unlinked[from(WashingMachineReservation(ReservationID={instance.Attr_ReservationID}))]");
                result = true;
            }
            return result;
        }

        public DomainClassWashingMachineReservation LinkedR17Predecessor()
        {
            var candidates = instanceRepository.GetDomainInstances("WashingMachineReservation").Where(inst=>(this.Attr_ReservationID==((DomainClassWashingMachineReservation)inst).Attr_successor_ReservationID));
            return (DomainClassWashingMachineReservation)candidates.First();
        }
        public DomainClassReservableWashingMachine LinkedR19()
        {
            var candidates = instanceRepository.GetDomainInstances("ReservableWashingMachine").Where(inst=>(this.Attr_ReservationID==((DomainClassReservableWashingMachine)inst).Attr_Next_ReservationID));
            return (DomainClassReservableWashingMachine)candidates.First();
        }
        public void TakeEvent(EventData domainEvent)
        {
            stateMachine.ReceivedEvent(domainEvent).Wait();
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineReservation(ReservationID={this.Attr_ReservationID}):takeEvent({domainEvent.EventNumber})");
        }

        
        public bool Validate()
        {
            bool isValid = true;
            if (relR12GuestStayReservationOwner == null)
            {
                isValid = false;
            }
            if (relR13AvailableWorkingSpecTarget == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void Dispose()
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineReservation(ReservationID={this.Attr_ReservationID}):delete");
            instanceRepository.Delete(this);
        }
    }
}
