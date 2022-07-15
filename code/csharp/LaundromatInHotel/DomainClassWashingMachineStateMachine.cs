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
    public partial class DomainClassWashingMachineStateMachine : StateMachineBase, ITransition
    {
        public enum Events
        {
            WashingMachine1 = 0,     // Assigned guest
            WashingMachine3 = 1,     // Done washing
            WashingMachine5 = 2,     // Done drying
            WashingMachine6 = 3,     // Start taking
            WashingMachine7 = 4,     // Taken out
            WashingMachine8 = 5,     // Interupted
            WashingMachine9 = 6    // Interupt action completed
        }

        public enum States
        {
            _NoState_ = 0,
            Standby = 1,
            Washing = 2,
            WashingCompletedAndDrying = 3,
            DryingCompleted = 4,
            WaitForTaking = 5,
            Interupting = 6,
            Interupted = 7
        }

        public class WashingMachine1_AssignedGuest : EventData
        {
            public WashingMachine1_AssignedGuest() : base((int)Events.WashingMachine1)
            {
                ;
            }

            public static WashingMachine1_AssignedGuest Create(DomainClassWashingMachine receiver)
            {
                var newEvent = new WashingMachine1_AssignedGuest();
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        public class WashingMachine3_DoneWashing : EventData
        {
            public WashingMachine3_DoneWashing() : base((int)Events.WashingMachine3)
            {
                ;
            }

            public static WashingMachine3_DoneWashing Create(DomainClassWashingMachine receiver)
            {
                var newEvent = new WashingMachine3_DoneWashing();
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        public class WashingMachine5_DoneDrying : EventData
        {
            public WashingMachine5_DoneDrying() : base((int)Events.WashingMachine5)
            {
                ;
            }

            public static WashingMachine5_DoneDrying Create(DomainClassWashingMachine receiver)
            {
                var newEvent = new WashingMachine5_DoneDrying();
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        public class WashingMachine6_StartTaking : EventData
        {
            public WashingMachine6_StartTaking() : base((int)Events.WashingMachine6)
            {
                ;
            }

            public static WashingMachine6_StartTaking Create(DomainClassWashingMachine receiver)
            {
                var newEvent = new WashingMachine6_StartTaking();
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        public class WashingMachine7_TakenOut : EventData
        {
            public WashingMachine7_TakenOut() : base((int)Events.WashingMachine7)
            {
                ;
            }

            public static WashingMachine7_TakenOut Create(DomainClassWashingMachine receiver)
            {
                var newEvent = new WashingMachine7_TakenOut();
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        public class WashingMachine8_Interupted : EventData
        {
            public WashingMachine8_Interupted() : base((int)Events.WashingMachine8)
            {
                ;
            }

            public static WashingMachine8_Interupted Create(DomainClassWashingMachine receiver)
            {
                var newEvent = new WashingMachine8_Interupted();
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        public class WashingMachine9_InteruptActionCompleted : EventData
        {
            public WashingMachine9_InteruptActionCompleted() : base((int)Events.WashingMachine9)
            {
                ;
            }

            public static WashingMachine9_InteruptActionCompleted Create(DomainClassWashingMachine receiver)
            {
                var newEvent = new WashingMachine9_InteruptActionCompleted();
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        protected DomainClassWashingMachine target;

        protected InstanceRepository instanceRepository;

        public DomainClassWashingMachineStateMachine(DomainClassWashingMachine target, InstanceRepository instanceRepository, Logger logger) : base(1, logger)
        {
            this.target = target;
            this.stateTransition = this;
            this.logger = logger;
            this.instanceRepository = instanceRepository;
        }

        protected int[,] stateTransitionTable = new int[7, 7]
            {
                { (int)States.Washing, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.CantHappen, (int)States.WashingCompletedAndDrying, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.Interupting, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.DryingCompleted, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.Interupting, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.WaitForTaking, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.Standby, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }, 
                { (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.Interupted }, 
                { (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)States.WaitForTaking, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen, (int)ITransition.Transition.CantHappen }
            };

        public int GetNextState(int currentState, int eventNumber)
        {
            return stateTransitionTable[currentState, eventNumber];
        }

        private List<ChangedState> changedStates;

        protected override void RunEntryAction(int nextState, EventData eventData)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachine(MachineID={target.Attr_MachineID}):entering[current={CurrentState},event={eventData.EventNumber}");


            changedStates = new List<ChangedState>();

            switch (nextState)
            {
            case (int)States.Standby:
                ActionStandby();
                break;
            case (int)States.Washing:
                ActionWashing();
                break;
            case (int)States.WashingCompletedAndDrying:
                ActionWashingCompletedAndDrying();
                break;
            case (int)States.DryingCompleted:
                ActionDryingCompleted();
                break;
            case (int)States.WaitForTaking:
                ActionWaitForTaking();
                break;
            case (int)States.Interupting:
                ActionInterupting();
                break;
            case (int)States.Interupted:
                ActionInterupted();
                break;
            }
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachine(MachineID={target.Attr_MachineID}):entered[current={CurrentState},event={eventData.EventNumber}");


            instanceRepository.SyncChangedStates(changedStates);
        }
    }
}
