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
        protected static readonly string className = "DoorwithLock";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassDoorwithLockBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null)
        {
            var newInstance = new DomainClassDoorwithLockBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:DoorwithLock(DoorID={newInstance.Attr_DoorID}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassDoorwithLockBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_DoorID = Guid.NewGuid().ToString();
            stateMachine = new DomainClassDoorwithLockStateMachine(this, instanceRepository, logger);
        }

        protected string attr_DoorID;
        protected bool stateof_DoorID = false;

        protected string attr_PIN_Number;
        protected bool stateof_PIN_Number = false;

        protected int attr_NumberOfDigits;
        protected bool stateof_NumberOfDigits = false;

        protected DomainTypeDoorStatus attr_Status;
        protected bool stateof_Status = false;

        protected DomainClassDoorwithLockStateMachine stateMachine;
        protected bool stateof_current_state = false;


        public string Attr_DoorID { get { return attr_DoorID; } set { attr_DoorID = value; stateof_DoorID = true; } }
        public string Attr_PIN_Number { get { return attr_PIN_Number; } set { attr_PIN_Number = value; stateof_PIN_Number = true; } }
        public int Attr_NumberOfDigits { get { return attr_NumberOfDigits; } set { attr_NumberOfDigits = value; stateof_NumberOfDigits = true; } }
        public DomainTypeDoorStatus Attr_Status { get { return attr_Status; } set { attr_Status = value; stateof_Status = true; } }
        public int Attr_current_state { get { return stateMachine.CurrentState; } }

        public static bool Compare(DomainClassDoorwithLock instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "DoorID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_DoorID)
                        {
                            result = false;
                        }
                        break;
                    case "PIN_Number":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_PIN_Number)
                        {
                            result = false;
                        }
                        break;
                    case "NumberOfDigits":
                        if ((int)conditionPropertyValues[propertyName] != instance.Attr_NumberOfDigits)
                        {
                            result = false;
                        }
                        break;
                    case "Status":
                        if ((DomainTypeDoorStatus)conditionPropertyValues[propertyName] != instance.Attr_Status)
                        {
                            result = false;
                        }
                        break;
                }
                if (result== false)
                {
                    break;
                }
            }
            return result;
        }

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

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:DoorwithLock(DoorID={this.Attr_DoorID}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

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
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            results.Add("DoorID", attr_DoorID);
            if (!onlyIdentity) results.Add("PIN_Number", attr_PIN_Number);
            if (!onlyIdentity) results.Add("NumberOfDigits", attr_NumberOfDigits);
            if (!onlyIdentity) results.Add("Status", attr_Status);
            results.Add("current_state", stateMachine.CurrentState);

            return results;
        }

#if false
        List<ChangedState> changedStates = new List<ChangedState>();

        public IList<ChangedState> ChangedStates()
        {
            List<ChangedState> results = new List<ChangedState>();
            results.AddRange(changedStates);
            results.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Update, Target = this, ChangedProperties = ChangedProperties() });
            changedStates.Clear();

            return results;
        }
#endif
    }
}
