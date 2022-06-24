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

namespace LaundromatInHotel
{
    public partial class DomainClassDoorwithLockBase : DomainClassDoorwithLock
    {
        private static readonly string className = "DoorwithLock";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;

        public static DomainClassDoorwithLockBase CreateInstance(InstanceRepository instanceRepository)
        {
            var newInstance = new DomainClassDoorwithLockBase(instanceRepository);
            instanceRepository.Add(newInstance);

            return newInstance;
        }

        public DomainClassDoorwithLockBase(InstanceRepository instanceRepository)
        {
            this.instanceRepository = instanceRepository;
            attr_DoorID = Guid.NewGuid().ToString();
            stateMachine = new DomainClassDoorwithLockStateMachine(this);
        }

        string attr_DoorID;
        string attr_PIN_Number;
        int attr_NumberOfDigits;
        DomainTypeDoorStatus attr_Status;
        DomainClassDoorwithLockStateMachine stateMachine;

        public string Attr_DoorID { get { return attr_DoorID; } set { attr_DoorID = value; } }
        public string Attr_PIN_Number { get { return attr_PIN_Number; } set { attr_PIN_Number = value; } }
        public int Attr_NumberOfDigits { get { return attr_NumberOfDigits; } set { attr_NumberOfDigits = value; } }
        public DomainTypeDoorStatus Attr_Status { get { return attr_Status; } set { attr_Status = value; } }
        public int Attr_current_state { get { return stateMachine.CurrentState; } }

        public DomainClassWashingMachine LinkedR14()
        {
            var candidates = instanceRepository.GetDomainInstances("WashingMachine").Where(inst=>(this.Attr_DoorID==((DomainClassWashingMachine)inst).Attr_DoorID));
            return (DomainClassWashingMachine)candidates.First();
        }
        public void TakeEvent(EventData domainEvent)
        {
            stateMachine.ReceivedEvent(domainEvent).Wait();
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
            instanceRepository.Delete(this);
        }
    }
}