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
    public partial class DomainClassReservableWashingMachineStateMachine : StateMachineBase, ITransition
    {
        public enum Events
        {
            ReservableWashingMachine1 = 0,     // Check
            ReservableWashingMachine2 = 1    // Reserved
        }

        public enum States
        {
            _NoState_ = 0,
            CheckedSituation = 1,
            ResevingForGuest = 2
        }

        public class ReservableWashingMachine1_Check : EventData
        {
            public ReservableWashingMachine1_Check() : base((int)Events.ReservableWashingMachine1)
            {
                ;
            }

            ReservableWashingMachine1_Check Create(DomainClassReservableWashingMachine receiver)
            {
                var newEvent = new ReservableWashingMachine1_Check();
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        public class ReservableWashingMachine2_Reserved : EventData
        {
            public ReservableWashingMachine2_Reserved() : base((int)Events.ReservableWashingMachine2)
            {
                ;
            }

            ReservableWashingMachine2_Reserved Create(DomainClassReservableWashingMachine receiver)
            {
                var newEvent = new ReservableWashingMachine2_Reserved();
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        protected DomainClassReservableWashingMachine target;

        public DomainClassReservableWashingMachineStateMachine(DomainClassReservableWashingMachine target, Logger logger) : base(1, logger)
        {
            this.target = target;
            this.stateTransition = this;
            this.logger = logger;
        }

        protected int[,] stateTransitionTable = new int[2, 2]
            {
                { (int)States.CheckedSituation, (int)States.ResevingForGuest }, 
                { (int)States.CheckedSituation, (int)ITransition.Transition.CantHappen }
            };

        public int GetNextState(int currentState, int eventNumber)
        {
            return stateTransitionTable[currentState, eventNumber];
        }

        protected override void RunEntryAction(int nextState, EventData eventData)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:ReservableWashingMachine(MachineID={target.Attr_MachineID}):entering[current={CurrentState},event={eventData.EventNumber}");

            switch (nextState)
            {
            case (int)States.CheckedSituation:
                ActionCheckedSituation();
                break;
            case (int)States.ResevingForGuest:
                ActionResevingForGuest();
                break;
            }
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:ReservableWashingMachine(MachineID={target.Attr_MachineID}):entered[current={CurrentState},event={eventData.EventNumber}");

        }
    }
}
