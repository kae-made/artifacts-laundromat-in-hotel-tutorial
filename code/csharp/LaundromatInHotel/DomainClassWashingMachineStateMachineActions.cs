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
    partial class DomainClassWashingMachineStateMachine
    {
        protected void ActionStandby()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // No one is using the washing machine.
            // SELECT ONE inUse RELATED BY SELF->WashingMachineinUse[R18];
            // SELECT ONE guestStay RELATED BY inUse->GuestStay[R18.'is used by'];
            // UNRELATE guestStay FROM SELF ACROSS R18 USING inUse;
            // DELETE OBJECT INSTANCE inUse;
            // 
            // SELF.Status = WashingMachineStatus::Ready;

            throw new NotImplementedException();
        }

        protected void ActionWashing()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Guest user is assigned.
            // If there is a washing instruction, transition to start washing.
            // If there is no washing instruction and there is drying instruction, transition to start drying.
            // SELECT ONE inUse RELATED BY SELF->WashingMachineinUse[R18];
            // SELECT ONE workingSpec RELATED BY inUse->AvailableWorkingSpec[R9.'current spec']->WorkingSpec[R8.'available spec'];
            // IF ( workingSpec.WashingTime > 0 )
            // 	SELF.StartWashing( timeInMinutes: workingSpec.WashingTime );
            // 	SELF.Status = WashingMachineStatus::Washing;
            // ELSE
            // 	GENERATE WashingMachine3 TO SELF;
            // END IF;

            throw new NotImplementedException();
        }

        protected void ActionWashingCompletedAndDrying()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Start drying...
            // SELECT ONE inUse RELATED BY SELF->WashingMachineinUse[R18];
            // SELECT ONE workingSpec RELATED BY inUse->AvailableWorkingSpec[R9.'current spec']->WorkingSpec[R8.'available spec'];
            // IF ( workingSpec.DryingTime > 0 )
            // 	SELF.StartDrying( timeInMinutes: workingSpec.WashingTime );
            // 	SELF.Status = WashingMachineStatus::Drying;
            // ELSE
            // 	GENERATE WashingMachine6 TO SELF;
            // END IF;

            throw new NotImplementedException();
        }

        protected void ActionDryingCompleted()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Notify now is that door unlock become available.
            // SELECT ONE door RELATED BY SELF->DoorwithLock[R14.'front door'];
            // GENERATE DoorwithLock8 TO door;
            // 
            // SELF.Status = WashingMachineStatus::WaitForTaking;

            throw new NotImplementedException();
        }

        protected void ActionWaitForTaking()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Tell the guest to take out and wait.

            throw new NotImplementedException();
        }

        protected void ActionInterupting()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // By some reason, try to stop working.
            // SELF.StopExecution();

            throw new NotImplementedException();
        }

        protected void ActionInterupted()
        {
            // TODO: Let's write action code!
            // Action Description on Model as a reference.
            // Notify now is that door unlock become available.
            // SELECT ONE door RELATED BY SELF->DoorwithLock[R14.'front door'];
            // GENERATE DoorwithLock8 TO door;
            // 
            // SELF.Status = WashingMachineStatus::Interupted;

            throw new NotImplementedException();
        }

    }
}