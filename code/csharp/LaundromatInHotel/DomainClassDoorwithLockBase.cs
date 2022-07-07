// ------------------------------------------------------------------------------
// <auto-generated>
//     This file is generated by tool.
//     Runtime Version : 0.1.0
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
    public partial class DomainClassDoorwithLockBase : DomainClassDoorwithLock
    {
        private static readonly string className = "DoorwithLock";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassDoorwithLockBase CreateInstance(InstanceRepository instanceRepository, Logger logger)
        {
            var newInstance = new DomainClassDoorwithLockBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:DoorwithLock(DoorID={newInstance.Attr_DoorID}):create");

            instanceRepository.Add(newInstance);

            return newInstance;
        }

        public DomainClassDoorwithLockBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_DoorID = Guid.NewGuid().ToString();
            stateMachine = new DomainClassDoorwithLockStateMachine(this, logger);
        }

        string attr_DoorID;
        bool stateof_DoorID = false;

        string attr_PIN_Number;
        bool stateof_PIN_Number = false;

        int attr_NumberOfDigits;
        bool stateof_NumberOfDigits = false;

        DomainTypeDoorStatus attr_Status;
        bool stateof_Status = false;

        DomainClassDoorwithLockStateMachine stateMachine;
        bool stateof_current_state = false;


        public string Attr_DoorID { get { return attr_DoorID; } set { attr_DoorID = value; stateof_DoorID = true; } }
        public string Attr_PIN_Number { get { return attr_PIN_Number; } set { attr_PIN_Number = value; stateof_PIN_Number = true; } }
        public int Attr_NumberOfDigits { get { return attr_NumberOfDigits; } set { attr_NumberOfDigits = value; stateof_NumberOfDigits = true; } }
        public DomainTypeDoorStatus Attr_Status { get { return attr_Status; } set { attr_Status = value; stateof_Status = true; } }
        public int Attr_current_state { get { return stateMachine.CurrentState; } }

        public DomainClassWashingMachine LinkedR14()
        {
            var candidates = instanceRepository.GetDomainInstances("WashingMachine").Where(inst=>(this.Attr_DoorID==((DomainClassWashingMachine)inst).Attr_DoorID));
            return (DomainClassWashingMachine)candidates.First();
        }
        public void TakeEvent(EventData domainEvent)
        {
            stateMachine.ReceivedEvent(domainEvent).Wait();
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:DoorwithLock(DoorID={this.Attr_DoorID}):takeEvent({domainEvent.EventNumber})");
        }

        
        public bool Validate()
        {
            bool isValid = true;
            if (this.LinkedR14() == null)
            {
                isValid = false;
            }

            return isValid;
        }

        public void Dispose()
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:DoorwithLock(DoorID={this.Attr_DoorID}):delete");

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            attr_DoorID = (string)propertyValues["DoorID"];
            stateof_DoorID = false;
            attr_PIN_Number = (string)propertyValues["PIN_Number"];
            stateof_PIN_Number = false;
            attr_NumberOfDigits = (int)propertyValues["NumberOfDigits"];
            stateof_NumberOfDigits = false;
            attr_Status = (DomainTypeDoorStatus)propertyValues["Status"];
            stateof_Status = false;
            stateMachine.ForceUpdateState((int)propertyValues["current_state"]);
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_DoorID)
            {
                results.Add("DoorID", attr_DoorID);
                stateof_DoorID = false;
            }
            if (stateof_PIN_Number)
            {
                results.Add("PIN_Number", attr_PIN_Number);
                stateof_PIN_Number = false;
            }
            if (stateof_NumberOfDigits)
            {
                results.Add("NumberOfDigits", attr_NumberOfDigits);
                stateof_NumberOfDigits = false;
            }
            if (stateof_Status)
            {
                results.Add("Status", attr_Status);
                stateof_Status = false;
            }
            results.Add("current_state", stateMachine.CurrentState);


            return results;
        }
        
        public IDictionary<string, object> GetProperties()
        {
            var results = new Dictionary<string, object>();

            results.Add("DoorID", attr_DoorID);
            results.Add("PIN_Number", attr_PIN_Number);
            results.Add("NumberOfDigits", attr_NumberOfDigits);
            results.Add("Status", attr_Status);
            results.Add("current_state", stateMachine.CurrentState);

            return results;
        }

    }
}
