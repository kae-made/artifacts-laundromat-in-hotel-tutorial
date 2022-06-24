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
    public partial class DomainClassDoorwithLockStateMachine : StateMachineBase, ITransition
    {
        public enum Events
        {
            DoorwithLock1 = 0,     // Touch card key
            DoorwithLock2 = 1,     // Door Closed
            DoorwithLock3 = 2,     // Door Opened
            DoorwithLock4 = 3,     // Set PIN code
            DoorwithLock5 = 4,     // Validated user
            DoorwithLock6 = 5,     // Judged as improper
            DoorwithLock7 = 6,     // Enter Spec
            DoorwithLock8 = 7    // Unlocked Allowed
        }

        public enum States
        {
            _NoState_ = 0,
            Locked = 1,
            CheckingSituationForUse = 2,
            WaitForPINCodeToOpen = 3,
            LockedForWashing = 4,
            CheckingSituationForTake = 5,
            CheckingPINCodeForOpen = 6,
            DoorOpened = 7,
            WaitForClose = 8,
            WaitForDoorOpen = 9,
            WaitForSpec = 10,
            WaitForPINCodeForOpen = 11,
            UnlockAvailabled = 12
        }

        private interface IEventArgsCardKeyIdDef
        {
            public string cardKeyId { get; set; }
        }
        private interface IEventArgsPinCodeDef
        {
            public string pinCode { get; set; }
        }
        private interface IEventArgsSpecIdGuestStayIdDef
        {
            public string specId { get; set; }
            public string guestStayId { get; set; }
        }
        public class DoorwithLock1_TouchCardKey : EventData, IEventArgsCardKeyIdDef
        {
            public DoorwithLock1_TouchCardKey() : base((int)Events.DoorwithLock1)
            {
                ;
            }

            public string cardKeyId { get; set; }
            DoorwithLock1_TouchCardKey Create(DomainClassDoorwithLock receiver, string cardKeyId, InstanceRepository instanceRepository=null)
            {
                var newEvent = new DoorwithLock1_TouchCardKey() { cardKeyId = cardKeyId };
                if (receiver == null && instanceRepository !=null)
                {
                    receiver = DomainClassDoorwithLockBase.CreateInstance(instanceRepository);
                }
                receiver.TakeEvent(newEvent);

                return newEvent;
            }
        }

        public class DoorwithLock2_DoorClosed : EventData
        {
            public DoorwithLock2_DoorClosed() : base((int)Events.DoorwithLock2)
            {
                ;
            }

            DoorwithLock2_DoorClosed Create(DomainClassDoorwithLock receiver, InstanceRepository instanceRepository=null)
            {
                var newEvent = new DoorwithLock2_DoorClosed();
                if (receiver == null && instanceRepository !=null)
                {
                    receiver = DomainClassDoorwithLockBase.CreateInstance(instanceRepository);
                }
                receiver.TakeEvent(newEvent);

                return newEvent;
            }
        }

        public class DoorwithLock3_DoorOpened : EventData
        {
            public DoorwithLock3_DoorOpened() : base((int)Events.DoorwithLock3)
            {
                ;
            }

            DoorwithLock3_DoorOpened Create(DomainClassDoorwithLock receiver, InstanceRepository instanceRepository=null)
            {
                var newEvent = new DoorwithLock3_DoorOpened();
                if (receiver == null && instanceRepository !=null)
                {
                    receiver = DomainClassDoorwithLockBase.CreateInstance(instanceRepository);
                }
                receiver.TakeEvent(newEvent);

                return newEvent;
            }
        }

        public class DoorwithLock4_SetPINCode : EventData, IEventArgsPinCodeDef
        {
            public DoorwithLock4_SetPINCode() : base((int)Events.DoorwithLock4)
            {
                ;
            }

            public string pinCode { get; set; }
            DoorwithLock4_SetPINCode Create(DomainClassDoorwithLock receiver, string pinCode, InstanceRepository instanceRepository=null)
            {
                var newEvent = new DoorwithLock4_SetPINCode() { pinCode = pinCode };
                if (receiver == null && instanceRepository !=null)
                {
                    receiver = DomainClassDoorwithLockBase.CreateInstance(instanceRepository);
                }
                receiver.TakeEvent(newEvent);

                return newEvent;
            }
        }

        public class DoorwithLock5_ValidatedUser : EventData
        {
            public DoorwithLock5_ValidatedUser() : base((int)Events.DoorwithLock5)
            {
                ;
            }

            DoorwithLock5_ValidatedUser Create(DomainClassDoorwithLock receiver, InstanceRepository instanceRepository=null)
            {
                var newEvent = new DoorwithLock5_ValidatedUser();
                if (receiver == null && instanceRepository !=null)
                {
                    receiver = DomainClassDoorwithLockBase.CreateInstance(instanceRepository);
                }
                receiver.TakeEvent(newEvent);

                return newEvent;
            }
        }

        public class DoorwithLock6_JudgedAsImproper : EventData
        {
            public DoorwithLock6_JudgedAsImproper() : base((int)Events.DoorwithLock6)
            {
                ;
            }

            DoorwithLock6_JudgedAsImproper Create(DomainClassDoorwithLock receiver, InstanceRepository instanceRepository=null)
            {
                var newEvent = new DoorwithLock6_JudgedAsImproper();
                if (receiver == null && instanceRepository !=null)
                {
                    receiver = DomainClassDoorwithLockBase.CreateInstance(instanceRepository);
                }
                receiver.TakeEvent(newEvent);

                return newEvent;
            }
        }

        public class DoorwithLock7_EnterSpec : EventData, IEventArgsSpecIdGuestStayIdDef
        {
            public DoorwithLock7_EnterSpec() : base((int)Events.DoorwithLock7)
            {
                ;
            }

            public string specId { get; set; }
            public string guestStayId { get; set; }
            DoorwithLock7_EnterSpec Create(DomainClassDoorwithLock receiver, string specId, string guestStayId, InstanceRepository instanceRepository=null)
            {
                var newEvent = new DoorwithLock7_EnterSpec() { specId = specId, guestStayId = guestStayId };
                if (receiver == null && instanceRepository !=null)
                {
                    receiver = DomainClassDoorwithLockBase.CreateInstance(instanceRepository);
                }
                receiver.TakeEvent(newEvent);

                return newEvent;
            }
        }

        public class DoorwithLock8_UnlockedAllowed : EventData
        {
            public DoorwithLock8_UnlockedAllowed() : base((int)Events.DoorwithLock8)
            {
                ;
            }

            DoorwithLock8_UnlockedAllowed Create(DomainClassDoorwithLock receiver, InstanceRepository instanceRepository=null)
            {
                var newEvent = new DoorwithLock8_UnlockedAllowed();
                if (receiver == null && instanceRepository !=null)
                {
                    receiver = DomainClassDoorwithLockBase.CreateInstance(instanceRepository);
                }
                receiver.TakeEvent(newEvent);

                return newEvent;
            }
        }

        protected DomainClassDoorwithLock target;

        public DomainClassDoorwithLockStateMachine(DomainClassDoorwithLock target) : base(1)
        {
            this.target = target;
            this.stateTransition = this;
        }

        protected int[,] stateTransitionTable = new int[12, 8]
            {
                { (int)States.CheckingSituationForUse, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.Ignore, (int)ITransition.Transition.CantHappen, (int)States.WaitForPINCodeToOpen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.Locked, (int)States.WaitForSpec, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.Ignore, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.WaitForClose, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.Ignore, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.UnlockAvailabled }, 
                { (int)States.CheckingSituationForTake, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.WaitForPINCodeForOpen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.Ignore, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.CheckingPINCodeForOpen, (int)States.WaitForDoorOpen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.Ignore, (int)States.Locked, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.Ignore, (int)States.LockedForWashing, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.Ignore, (int)ITransition.Transition.CantHappen, (int)States.DoorOpened, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.Ignore, (int)ITransition.Transition.CantHappen, (int)States.WaitForPINCodeToOpen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.Ignore, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.CheckingPINCodeForOpen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)States.CheckingSituationForTake, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }
            };

        public int GetNextState(int currentState, int eventNumber)
        {
            return stateTransitionTable[currentState, eventNumber];
        }

        protected override void RunEntryAction(int nextState, EventData eventData)
        {
            switch (nextState)
            {
            case (int)States.Locked:
                ActionLocked();
                break;
            case (int)States.CheckingSituationForUse:
                ActionCheckingSituationForUse(((IEventArgsCardKeyIdDef)eventData).cardKeyId);
                break;
            case (int)States.WaitForPINCodeToOpen:
                ActionWaitForPINCodeToOpen();
                break;
            case (int)States.LockedForWashing:
                ActionLockedForWashing();
                break;
            case (int)States.CheckingSituationForTake:
                ActionCheckingSituationForTake(((IEventArgsCardKeyIdDef)eventData).cardKeyId);
                break;
            case (int)States.CheckingPINCodeForOpen:
                ActionCheckingPINCodeForOpen(((IEventArgsPinCodeDef)eventData).pinCode);
                break;
            case (int)States.DoorOpened:
                ActionDoorOpened();
                break;
            case (int)States.WaitForClose:
                ActionWaitForClose(((IEventArgsPinCodeDef)eventData).pinCode);
                break;
            case (int)States.WaitForDoorOpen:
                ActionWaitForDoorOpen();
                break;
            case (int)States.WaitForSpec:
                ActionWaitForSpec(((IEventArgsSpecIdGuestStayIdDef)eventData).specId, ((IEventArgsSpecIdGuestStayIdDef)eventData).guestStayId);
                break;
            case (int)States.WaitForPINCodeForOpen:
                ActionWaitForPINCodeForOpen();
                break;
            case (int)States.UnlockAvailabled:
                ActionUnlockAvailabled();
                break;
            }
        }
    }
}