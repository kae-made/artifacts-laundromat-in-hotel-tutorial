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
using Kae.DomainModel.Csharp.Framework;

namespace LaundromatInHotel
{
    public partial class DomainClassWashingMachineBase : DomainClassWashingMachine
    {
        protected static readonly string className = "WashingMachine";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassWashingMachineBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null)
        {
            var newInstance = new DomainClassWashingMachineBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachine(MachineID={newInstance.Attr_MachineID}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassWashingMachineBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_MachineID = Guid.NewGuid().ToString();
            stateMachine = new DomainClassWashingMachineStateMachine(this, instanceRepository, logger);
        }
        protected string attr_MachineID;
        protected bool stateof_MachineID = false;

        protected string attr_FriendryName;
        protected bool stateof_FriendryName = false;

        protected bool attr_IsBusy;
        protected bool stateof_IsBusy = false;

        protected string attr_RoomID;
        protected bool stateof_RoomID = false;

        protected string attr_DoorID;
        protected bool stateof_DoorID = false;

        protected DomainTypeWashingMachineStatus attr_Status;
        protected bool stateof_Status = false;

        protected DomainClassWashingMachineStateMachine stateMachine;
        protected bool stateof_current_state = false;

        public string Attr_MachineID { get { return attr_MachineID; } set { attr_MachineID = value; stateof_MachineID = true; } }
        public string Attr_FriendryName { get { return attr_FriendryName; } set { attr_FriendryName = value; stateof_FriendryName = true; } }
        public bool Attr_IsBusy { get { return attr_IsBusy; } set { attr_IsBusy = value; stateof_IsBusy = true; } }
        public string Attr_RoomID { get { return attr_RoomID; } }
        public string Attr_DoorID { get { return attr_DoorID; } }
        public DomainTypeWashingMachineStatus Attr_Status { get { return attr_Status; } set { attr_Status = value; stateof_Status = true; } }
        public int Attr_current_state { get { return stateMachine.CurrentState; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassWashingMachine instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "MachineID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_MachineID)
                        {
                            result = false;
                        }
                        break;
                    case "FriendryName":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_FriendryName)
                        {
                            result = false;
                        }
                        break;
                    case "IsBusy":
                        if ((bool)conditionPropertyValues[propertyName] != instance.Attr_IsBusy)
                        {
                            result = false;
                        }
                        break;
                    case "RoomID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_RoomID)
                        {
                            result = false;
                        }
                        break;
                    case "DoorID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_DoorID)
                        {
                            result = false;
                        }
                        break;
                    case "Status":
                        if ((DomainTypeWashingMachineStatus)conditionPropertyValues[propertyName] != instance.Attr_Status)
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
        protected LinkedInstance relR2LaundromatRoomIsSetUpAt;
        protected LinkedInstance relR14DoorwithLockFrontDoor;
        public DomainClassLaundromatRoom LinkedR2IsSetUpAt()
        {
            if (relR2LaundromatRoomIsSetUpAt == null)
            {
           var candidates = instanceRepository.GetDomainInstances("LaundromatRoom").Where(inst=>(this.Attr_RoomID==((DomainClassLaundromatRoom)inst).Attr_RoomID));
           relR2LaundromatRoomIsSetUpAt = new LinkedInstance() { Source = this, Destination = candidates.First(), RelationshipID = "R2", Phrase = "IsSetUpAt" };

            }
            return relR2LaundromatRoomIsSetUpAt.GetDestination<DomainClassLaundromatRoom>();
        }

        public bool LinkR2IsSetUpAt(DomainClassLaundromatRoom instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR2LaundromatRoomIsSetUpAt == null)
            {
                this.attr_RoomID = instance.Attr_RoomID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachine(MachineID={this.Attr_MachineID}):link[LaundromatRoom(RoomID={instance.Attr_RoomID})]");

                result = (LinkedR2IsSetUpAt()!=null);
                if (result)
                {
                    if(changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR2LaundromatRoomIsSetUpAt });
                }
            }
            return result;
        }

        public bool UnlinkR2IsSetUpAt(DomainClassLaundromatRoom instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR2LaundromatRoomIsSetUpAt != null && ( this.Attr_RoomID==instance.Attr_RoomID ))
            {
                if (changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR2LaundromatRoomIsSetUpAt });
        
                this.attr_RoomID = null;
                relR2LaundromatRoomIsSetUpAt = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachine(MachineID={this.Attr_MachineID}):unlink[LaundromatRoom(RoomID={instance.Attr_RoomID})]");


                result = true;
            }
            return result;
        }
        public DomainClassDoorwithLock LinkedR14FrontDoor()
        {
            if (relR14DoorwithLockFrontDoor == null)
            {
           var candidates = instanceRepository.GetDomainInstances("DoorwithLock").Where(inst=>(this.Attr_DoorID==((DomainClassDoorwithLock)inst).Attr_DoorID));
           relR14DoorwithLockFrontDoor = new LinkedInstance() { Source = this, Destination = candidates.First(), RelationshipID = "R14", Phrase = "FrontDoor" };

            }
            return relR14DoorwithLockFrontDoor.GetDestination<DomainClassDoorwithLock>();
        }

        public bool LinkR14FrontDoor(DomainClassDoorwithLock instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR14DoorwithLockFrontDoor == null)
            {
                this.attr_DoorID = instance.Attr_DoorID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachine(MachineID={this.Attr_MachineID}):link[DoorwithLock(DoorID={instance.Attr_DoorID})]");

                result = (LinkedR14FrontDoor()!=null);
                if (result)
                {
                    if(changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR14DoorwithLockFrontDoor });
                }
            }
            return result;
        }

        public bool UnlinkR14FrontDoor(DomainClassDoorwithLock instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR14DoorwithLockFrontDoor != null && ( this.Attr_DoorID==instance.Attr_DoorID ))
            {
                if (changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR14DoorwithLockFrontDoor });
        
                this.attr_DoorID = null;
                relR14DoorwithLockFrontDoor = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachine(MachineID={this.Attr_MachineID}):unlink[DoorwithLock(DoorID={instance.Attr_DoorID})]");


                result = true;
            }
            return result;
        }

        public IEnumerable<DomainClassAvailableWorkingSpec> LinkedR8OtherAvailableSpec()
        {
            var result = new List<DomainClassAvailableWorkingSpec>();
            var candidates = instanceRepository.GetDomainInstances("AvailableWorkingSpec").Where(inst=>(this.Attr_MachineID==((DomainClassAvailableWorkingSpec)inst).Attr_MachineID));
            foreach (var c in candidates)
            {
                result.Add((DomainClassAvailableWorkingSpec)c);
            }
            return result;
        }


        public SubClassR15 GetSubR15()
        {
            SubClassR15 result = null;
            var subClassKeys = new List<string>() { "NonReservationWashingMachine", "ReservableWashingMachine" };
            foreach (var key in subClassKeys)
            {
                var candidates = instanceRepository.GetDomainInstances(key).Where(inst=>((this == ((SubClassR15)inst).GetSuperClassR15())));
                if (candidates.Count()>0)
                {
                    result = (SubClassR15)candidates.First();
                    break;
                }
            }
            return result;
        }


        public DomainClassNonReservationWashingMachine LinkedR15NonReservationWashingMachine()
        {
            return (DomainClassNonReservationWashingMachine)GetSubR15();
        }


        public DomainClassReservableWashingMachine LinkedR15ReservableWashingMachine()
        {
            return (DomainClassReservableWashingMachine)GetSubR15();
        }


        public DomainClassWashingMachineinUse LinkedR18OneIsUsedBy()
        {
            var candidates = instanceRepository.GetDomainInstances("WashingMachineinUse").Where(inst=>(this.Attr_MachineID==((DomainClassWashingMachineinUse)inst).Attr_MachineID));
            return (DomainClassWashingMachineinUse)candidates.First();
        }



        public void TakeEvent(EventData domainEvent, bool selfEvent=false)
        {
            if (selfEvent)
            {
                stateMachine.ReceivedSelfEvent(domainEvent).Wait();
            }
            else
            {
                stateMachine.ReceivedEvent(domainEvent).Wait();
            }
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachine(MachineID={this.Attr_MachineID}):takeEvent({domainEvent.EventNumber})");
        }

        
        public bool Validate()
        {
            bool isValid = true;
            if (relR2LaundromatRoomIsSetUpAt == null)
            {
                isValid = false;
            }
            if (relR14DoorwithLockFrontDoor == null)
            {
                isValid = false;
            }
            if (this.LinkedR8OtherAvailableSpec().Count() == 0)
            {
                isValid = false;
            }

            if (this.GetSubR15() == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachine(MachineID={this.Attr_MachineID}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            attr_MachineID = (string)propertyValues["MachineID"];
            stateof_MachineID = false;
            attr_FriendryName = (string)propertyValues["FriendryName"];
            stateof_FriendryName = false;
            attr_IsBusy = (bool)propertyValues["IsBusy"];
            stateof_IsBusy = false;
            attr_RoomID = (string)propertyValues["RoomID"];
            stateof_RoomID = false;
            attr_DoorID = (string)propertyValues["DoorID"];
            stateof_DoorID = false;
            attr_Status = (DomainTypeWashingMachineStatus)propertyValues["Status"];
            stateof_Status = false;
            stateMachine.ForceUpdateState((int)propertyValues["current_state"]);
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_MachineID)
            {
                results.Add("MachineID", attr_MachineID);
                stateof_MachineID = false;
            }
            if (stateof_FriendryName)
            {
                results.Add("FriendryName", attr_FriendryName);
                stateof_FriendryName = false;
            }
            if (stateof_IsBusy)
            {
                results.Add("IsBusy", attr_IsBusy);
                stateof_IsBusy = false;
            }
            if (stateof_RoomID)
            {
                results.Add("RoomID", attr_RoomID);
                stateof_RoomID = false;
            }
            if (stateof_DoorID)
            {
                results.Add("DoorID", attr_DoorID);
                stateof_DoorID = false;
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

            results.Add("MachineID", attr_MachineID);
            if (!onlyIdentity) results.Add("FriendryName", attr_FriendryName);
            if (!onlyIdentity) results.Add("IsBusy", attr_IsBusy);
            if (!onlyIdentity) results.Add("RoomID", attr_RoomID);
            if (!onlyIdentity) results.Add("DoorID", attr_DoorID);
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
