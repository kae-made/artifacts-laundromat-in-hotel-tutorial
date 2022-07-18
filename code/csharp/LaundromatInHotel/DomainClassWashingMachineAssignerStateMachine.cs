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
    public partial class DomainClassWashingMachineAssignerStateMachine : StateMachineBase, ITransition
    {
        public enum Events
        {
            WashingMachineAssigner1 = 0,     // Request reservation
            WashingMachineAssigner2 = 1    // Cancel reservation
        }

        public enum States
        {
            _NoState_ = 0,
            WaitForReservationRequest = 1,
            CanceledReservation = 2
        }

        private interface IEventArgsGuestStayIdSpecIdDef
        {
            public string guestStayId { get; set; }
            public string specId { get; set; }
        }
        private interface IEventArgsReservationIdDef
        {
            public string reservationId { get; set; }
        }
        public class WashingMachineAssigner1_RequestReservation : EventData, IEventArgsGuestStayIdSpecIdDef
        {
            public WashingMachineAssigner1_RequestReservation() : base((int)Events.WashingMachineAssigner1)
            {
                ;
            }

            public string guestStayId { get; set; }
            public string specId { get; set; }
            public static WashingMachineAssigner1_RequestReservation Create(DomainClassWashingMachineAssigner receiver, string guestStayId, string specId)
            {
                var newEvent = new WashingMachineAssigner1_RequestReservation() { guestStayId = guestStayId, specId = specId };
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        public class WashingMachineAssigner2_CancelReservation : EventData, IEventArgsReservationIdDef
        {
            public WashingMachineAssigner2_CancelReservation() : base((int)Events.WashingMachineAssigner2)
            {
                ;
            }

            public string reservationId { get; set; }
            public static WashingMachineAssigner2_CancelReservation Create(DomainClassWashingMachineAssigner receiver, string reservationId)
            {
                var newEvent = new WashingMachineAssigner2_CancelReservation() { reservationId = reservationId };
                if (receiver != null)
                {
                    receiver.TakeEvent(newEvent);
                }

                return newEvent;
            }
        }

        protected DomainClassWashingMachineAssigner target;

        protected InstanceRepository instanceRepository;

        public DomainClassWashingMachineAssignerStateMachine(DomainClassWashingMachineAssigner target, InstanceRepository instanceRepository, Logger logger) : base(1, logger)
        {
            this.target = target;
            this.stateTransition = this;
            this.logger = logger;
            this.instanceRepository = instanceRepository;
        }

        protected int[,] stateTransitionTable = new int[2, 2]
            {
                { (int)States.WaitForReservationRequest, (int)States.CanceledReservation }, 
                { (int)States.WaitForReservationRequest, (int)States.CanceledReservation }
            };

        public int GetNextState(int currentState, int eventNumber)
        {
            return stateTransitionTable[currentState, eventNumber];
        }

        private List<ChangedState> changedStates;

        protected override void RunEntryAction(int nextState, EventData eventData)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineAssigner(HotelID={target.Attr_HotelID}):entering[current={CurrentState},event={eventData.EventNumber}");


            changedStates = new List<ChangedState>();

            switch (nextState)
            {
            case (int)States.WaitForReservationRequest:
                ActionWaitForReservationRequest(((IEventArgsGuestStayIdSpecIdDef)eventData).guestStayId, ((IEventArgsGuestStayIdSpecIdDef)eventData).specId);
                break;
            case (int)States.CanceledReservation:
                ActionCanceledReservation(((IEventArgsReservationIdDef)eventData).reservationId);
                break;
            }
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WashingMachineAssigner(HotelID={target.Attr_HotelID}):entered[current={CurrentState},event={eventData.EventNumber}");


            instanceRepository.SyncChangedStates(changedStates);
        }
    }
}
