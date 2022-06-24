// ------------------------------------------------------------------------------
// <auto-generated>
//     This file is generated by tool.
//     Runtime Version : 0.0.1
//  
// </auto-generated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Kae.StateMachine;

namespace LaundromatInHotel
{
    partial class DomainClassWashingMachineReservationStateMachine
    {
        protected void ActionWaitForAssignment(string specId, string guestStayId, DateTime reservationTime)
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Request check to assigner.
            // SELECT ANY guestStay FROM INSTANCES OF GuestStay WHERE SELECTED.GuestStayID == rcvd_evt.guestStayId;
            // RELATE SELF TO guestStay ACROSS R12;
            // 
            // SELECT ANY workingSpec FROM INSTANCES OF AvailableWorkingSpec WHERE SELECTED.WorkingSpecID == rcvd_evt.specId;
            // SELECT ONE machineAssigner RELATED BY workingSpec->WashingMachineAssigner[R11];
            // SELECT ONE spec RELATED BY workingSpec->WorkingSpec[R8.'available spec'];
            // 
            // SELF.ReservationTime = rcvd_evt.reservationTime;
            // SELF.EstimatedEndTime = TIM::time_add(time:SELF.ReservationTime, days:0, hours:0, minutes:(spec.WashingTime+spec.DryingTime), seconds:0);
            // 
            // GENERATE WashingMachineAssigner1:'Request reservation'(specId:rcvd_evt.specId, guestStayId:rcvd_evt.guestStayId) TO machineAssigner;

            throw new NotImplementedException();
        }

        protected void ActionReserved()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Timer activation for pre-alarm
            // and available notification.
            // CREATE EVENT INSTANCE preAlarm OF WashingMachineReservation3 TO SELF;
            // SELECT ONE workingSpec RELATED BY SELF->AvailableWorkingSpec[R13.'target'];
            // ASSIGN preAlarmTime = TIM::time_add( days:0, hours:0, minutes:0, seconds: - workingSpec.PreAlarmSec, time:SELF.ReservationTime );
            // ASSIGN preAlarmDuration = TIM::time_duration( timestamp1:preAlarmTime, timestamp2:SELF.ReservationTime );
            // SELF.AlarmTimer = TIM::timer_start( event_inst:preAlarm, microseconds:preAlarmDuration * 1000000 );

            throw new NotImplementedException();
        }

        protected void ActionPreNotified()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Remind the guest stay of pre-alarm.
            // SELECT ONE guestStay RELATED BY SELF->GuestStay[R12.'reservation owner'];
            // guestStay.Notify( topic:NotificationForGuestStay::PreAlarm );
            // 
            // SELECT ONE workingSpec RELATED BY SELF->AvailableWorkingSpec[R13.'target'];
            // CREATE EVENT INSTANCE timeIsUp OF WashingMachineReservation4 TO SELF;
            // SELF.AlarmTimer = TIM::timer_start( event_inst:timeIsUp, microseconds: workingSpec.PreAlarmSec * 1000000 );

            throw new NotImplementedException();
        }

        protected void ActionWashingMachineIsAssigned()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Remind the guest stay that the washing machine becomes available.
            // SELECT ONE guestStay RELATED BY SELF->GuestStay[R12.'reservation owner'];
            // guestStay.Notify( topic:NotificationForGuestStay::TimeHasCome );
            // 
            // SELECT ONE machine RELATED BY SELF->AvailableWorkingSpec[R13.'target']->WashingMachine[R8]->ReservableWashingMachine[R15];
            // GENERATE ReservableWashingMachine2:Reserved TO machine;

            throw new NotImplementedException();
        }

        protected void ActionCanceled()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Notify guest stay of cancellation completion.
            // Request situation checking for assigner and machine.
            // SELECT ONE guestStay RELATED BY SELF->GuestStay[R12.'reservation owner'];
            // UNRELATE SELF FROM guestStay ACROSS R12;
            // 
            // ASSIGN cancel_result = TIM::timer_cancel( timer_inst_ref:SELF.AlarmTimer );
            // 
            // SELECT ONE machineAssigner RELATED BY SELF->AvailableWorkingSpec[R13.'target']->WashingMachineAssigner[R11];
            // GENERATE WashingMachineAssigner2(reservationId:SELF.ReservationID) TO machineAssigner;
            // 
            // SELECT ONE machine RELATED BY SELF->AvailableWorkingSpec[R13.'target']->WashingMachine[R8]->ReservableWashingMachine[R15];
            // GENERATE ReservableWashingMachine1:Check TO machine;

            throw new NotImplementedException();
        }

        protected void ActionNoWashingMachine()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // This reservation request has been rejected.
            // Delete self.
            // SELECT ONE guestStay RELATED BY SELF->GuestStay[R12.'reservation owner'];
            // UNRELATE SELF FROM guestStay ACROSS R12;

            throw new NotImplementedException();
        }

    }
}
