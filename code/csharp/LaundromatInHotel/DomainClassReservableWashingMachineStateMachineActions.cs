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
    partial class DomainClassReservableWashingMachineStateMachine
    {
        protected void ActionCheckedSituation()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // If there is an applicable reservation in the current time slot,
            // it will transition to the reserved state.
            // SELECT ONE reservation RELATED BY SELF->WashingMachineReservation[R19.'next reservation'];
            // IF ( reservation.ReservationTime <= TIM::current_clock() )
            // 	GENERATE ReservableWashingMachine2:Reserved TO SELF;
            // END IF;

            throw new NotImplementedException();
        }

        protected void ActionResevingForGuest()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Current state is reserved for specific guest stay.
            // SELECT ONE machine RELATED BY SELF->WashingMachine[R15];
            // machine.Status = WashingMachineStatus::Reserved;

            throw new NotImplementedException();
        }

    }
}