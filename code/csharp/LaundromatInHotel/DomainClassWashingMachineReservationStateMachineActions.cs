// ------------------------------------------------------------------------------
// <auto-generated>
//     This file is generated by tool.
//     Runtime Version : 0.1.0
//  
// </auto-generated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Kae.StateMachine;
using Kae.DomainModel.Csharp.Framework;

namespace LaundromatInHotel
{
    partial class DomainClassWashingMachineReservationStateMachine
    {
        protected void ActionWaitForAssignment(string specId, string guestStayId, DateTime reservationTime)
        {
            // Action Description on Model as a reference.

            //   1 : // Request check to assigner.
            //   2 : SELECT ANY guestStay FROM INSTANCES OF GuestStay WHERE SELECTED.GuestStayID == rcvd_evt.guestStayId;
            //   3 : RELATE SELF TO guestStay ACROSS R12;
            //   4 : 
            //   5 : SELECT ANY workingSpec FROM INSTANCES OF AvailableWorkingSpec WHERE SELECTED.WorkingSpecID == rcvd_evt.specId;
            //   6 : SELECT ONE machineAssigner RELATED BY workingSpec->WashingMachineAssigner[R11];
            //   7 : SELECT ONE spec RELATED BY workingSpec->WorkingSpec[R8.'available spec'];
            //   8 : 
            //   9 : SELF.ReservationTime = rcvd_evt.reservationTime;
            //  10 : SELF.EstimatedEndTime = TIM::time_add(time:SELF.ReservationTime, days:0, hours:0, minutes:(spec.WashingTime+spec.DryingTime), seconds:0);
            //  11 : 
            //  12 : GENERATE WashingMachineAssigner1:'Request reservation'(specId:rcvd_evt.specId, guestStayId:rcvd_evt.guestStayId) TO machineAssigner;

            // External Entities Reference Declarations.
            var _eeTIMRef_ = (Kae.DomainModel.Csharp.Framework.ExternalEntities.TIM.TIMWrapper)instanceRepository.GetExternalEntity("TIM");

            // Line : 2
            var guestStay = (DomainClassGuestStay)(instanceRepository.GetDomainInstances("GuestStay").Where(selected => ((((DomainClassGuestStay)selected).Attr_GuestStayID == guestStayId))).First());

            // Line : 3
            // SELF - R12 -> guestStay;
            target.LinkR12ReservationOwner(guestStay, changedStates);;

            // Line : 5
            var workingSpec = (DomainClassAvailableWorkingSpec)(instanceRepository.GetDomainInstances("AvailableWorkingSpec").Where(selected => ((((DomainClassAvailableWorkingSpec)selected).Attr_WorkingSpecID == specId))).First());

            // Line : 6
            var machineAssigner = workingSpec.LinkedR11();

            // Line : 7
            var spec = workingSpec.LinkedR8OtherAvailableSpec();

            // Line : 9
            target.Attr_ReservationTime = reservationTime;
            // Line : 10
            target.Attr_EstimatedEndTime = _eeTIMRef_.time_add(time:target.Attr_ReservationTime, days:0, hours:0, minutes:(spec.Attr_WashingTime + spec.Attr_DryingTime), seconds:0);
            // Line : 12
            DomainClassWashingMachineAssignerStateMachine.WashingMachineAssigner1_RequestReservation.Create(receiver:machineAssigner, specId:specId, guestStayId:guestStayId, sendNow:true);


        }

        protected void ActionReserved()
        {
            // Action Description on Model as a reference.

            //  1 : // Timer activation for pre-alarm
            //  2 : // and available notification.
            //  3 : CREATE EVENT INSTANCE preAlarm OF WashingMachineReservation3 TO SELF;
            //  4 : SELECT ONE workingSpec RELATED BY SELF->AvailableWorkingSpec[R13.'target'];
            //  5 : ASSIGN preAlarmTime = TIM::time_add( days:0, hours:0, minutes:0, seconds: - workingSpec.PreAlarmSec, time:SELF.ReservationTime );
            //  6 : ASSIGN preAlarmDuration = TIM::time_duration( timestamp1:preAlarmTime, timestamp2:SELF.ReservationTime );
            //  7 : SELF.AlarmTimer = TIM::timer_start( event_inst:preAlarm, microseconds:preAlarmDuration * 1000000 );

            // External Entities Reference Declarations.
            var _eeTIMRef_ = (Kae.DomainModel.Csharp.Framework.ExternalEntities.TIM.TIMWrapper)instanceRepository.GetExternalEntity("TIM");

            // Line : 3
            var preAlarm = DomainClassWashingMachineReservationStateMachine.WashingMachineReservation3_PreAlarmIsTimeUp.Create(receiver:target, sendNow:false);

            // Line : 4
            var workingSpec = target.LinkedR13Target();

            // Line : 5
            var preAlarmTime = _eeTIMRef_.time_add(days:0, hours:0, minutes:0, seconds:-workingSpec.Attr_PreAlarmSec, time:target.Attr_ReservationTime);
            // Line : 6
            var preAlarmDuration = _eeTIMRef_.time_duration(timestamp1:preAlarmTime, timestamp2:target.Attr_ReservationTime);
            // Line : 7
            target.Attr_AlarmTimer = _eeTIMRef_.timer_start(event_inst:preAlarm, microseconds:(preAlarmDuration * 1000000));

        }

        protected void ActionPreNotified()
        {
            // Action Description on Model as a reference.

            //  1 : // Remind the guest stay of pre-alarm.
            //  2 : SELECT ONE guestStay RELATED BY SELF->GuestStay[R12.'reservation owner'];
            //  3 : guestStay.Notify( topic:NotificationForGuestStay::PreAlarm );
            //  4 : 
            //  5 : SELECT ONE workingSpec RELATED BY SELF->AvailableWorkingSpec[R13.'target'];
            //  6 : CREATE EVENT INSTANCE timeIsUp OF WashingMachineReservation4 TO SELF;
            //  7 : SELF.AlarmTimer = TIM::timer_start( event_inst:timeIsUp, microseconds: workingSpec.PreAlarmSec * 1000000 );

            // External Entities Reference Declarations.
            var _eeTIMRef_ = (Kae.DomainModel.Csharp.Framework.ExternalEntities.TIM.TIMWrapper)instanceRepository.GetExternalEntity("TIM");

            // Line : 2
            var guestStay = target.LinkedR12ReservationOwner();

            // Line : 3
            guestStay.Notify(topic:DomainTypeNotificationForGuestStay.PreAlarm);
            // Line : 5
            var workingSpec = target.LinkedR13Target();

            // Line : 6
            var timeIsUp = DomainClassWashingMachineReservationStateMachine.WashingMachineReservation4_TimeIsUp.Create(receiver:target, sendNow:false);

            // Line : 7
            target.Attr_AlarmTimer = _eeTIMRef_.timer_start(event_inst:timeIsUp, microseconds:(workingSpec.Attr_PreAlarmSec * 1000000));

        }

        protected void ActionWashingMachineIsAssigned()
        {
            // Action Description on Model as a reference.

            //  1 : // Remind the guest stay that the washing machine becomes available.
            //  2 : SELECT ONE guestStay RELATED BY SELF->GuestStay[R12.'reservation owner'];
            //  3 : guestStay.Notify( topic:NotificationForGuestStay::TimeHasCome );
            //  4 : 
            //  5 : SELECT ONE machine RELATED BY SELF->AvailableWorkingSpec[R13.'target']->WashingMachine[R8]->ReservableWashingMachine[R15];
            //  6 : GENERATE ReservableWashingMachine2:Reserved TO machine;

            // Line : 2
            var guestStay = target.LinkedR12ReservationOwner();

            // Line : 3
            guestStay.Notify(topic:DomainTypeNotificationForGuestStay.TimeHasCome);
            // Line : 5
            var machine = target.LinkedR13Target().LinkedR8One().LinkedR15ReservableWashingMachine();

            // Line : 6
            DomainClassReservableWashingMachineStateMachine.ReservableWashingMachine2_Reserved.Create(receiver:machine, sendNow:true);


        }

        protected void ActionCanceled()
        {
            // Action Description on Model as a reference.

            //   1 : // Notify guest stay of cancellation completion.
            //   2 : // Request situation checking for assigner and machine.
            //   3 : SELECT ONE guestStay RELATED BY SELF->GuestStay[R12.'reservation owner'];
            //   4 : UNRELATE SELF FROM guestStay ACROSS R12;
            //   5 : 
            //   6 : ASSIGN cancel_result = TIM::timer_cancel( timer_inst_ref:SELF.AlarmTimer );
            //   7 : 
            //   8 : SELECT ONE machineAssigner RELATED BY SELF->AvailableWorkingSpec[R13.'target']->WashingMachineAssigner[R11];
            //   9 : GENERATE WashingMachineAssigner2(reservationId:SELF.ReservationID) TO machineAssigner;
            //  10 : 
            //  11 : SELECT ONE machine RELATED BY SELF->AvailableWorkingSpec[R13.'target']->WashingMachine[R8]->ReservableWashingMachine[R15];
            //  12 : GENERATE ReservableWashingMachine1:Check TO machine;

            // External Entities Reference Declarations.
            var _eeTIMRef_ = (Kae.DomainModel.Csharp.Framework.ExternalEntities.TIM.TIMWrapper)instanceRepository.GetExternalEntity("TIM");

            // Line : 3
            var guestStay = target.LinkedR12ReservationOwner();

            // Line : 4
            // Unrelate SELF From guestStay Across R12
            target.UnlinkR12ReservationOwner(guestStay, changedStates);;

            // Line : 6
            var cancel_result = _eeTIMRef_.timer_cancel(timer_inst_ref:target.Attr_AlarmTimer);
            // Line : 8
            var machineAssigner = target.LinkedR13Target().LinkedR11();

            // Line : 9
            DomainClassWashingMachineAssignerStateMachine.WashingMachineAssigner2_CancelReservation.Create(receiver:machineAssigner, reservationId:target.Attr_ReservationID, sendNow:true);

            // Line : 11
            var machine = target.LinkedR13Target().LinkedR8One().LinkedR15ReservableWashingMachine();

            // Line : 12
            DomainClassReservableWashingMachineStateMachine.ReservableWashingMachine1_Check.Create(receiver:machine, sendNow:true);


        }

        protected void ActionNoWashingMachine()
        {
            // Action Description on Model as a reference.

            //  1 : // This reservation request has been rejected.
            //  2 : // Delete self.
            //  3 : SELECT ONE guestStay RELATED BY SELF->GuestStay[R12.'reservation owner'];
            //  4 : UNRELATE SELF FROM guestStay ACROSS R12;

            // Line : 3
            var guestStay = target.LinkedR12ReservationOwner();

            // Line : 4
            // Unrelate SELF From guestStay Across R12
            target.UnlinkR12ReservationOwner(guestStay, changedStates);;


        }

    }
}
