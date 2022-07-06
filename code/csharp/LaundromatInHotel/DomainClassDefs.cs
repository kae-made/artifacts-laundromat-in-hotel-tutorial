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
using Kae.StateMachine;

namespace LaundromatInHotel
{
    public interface DomainClassDef : IDisposable
    {
        public string ClassName { get; }
        /// <summary>
        /// Check attributes and links are valid or not.
        /// </summary>
        /// <returns></returns>
        bool Validate();

        // methods for storage
        void Restore(Dictionary<string, object> propertyValues);
        Dictionary<string, object> ChangedProperties();
        Dictionary<string, object> GetProperties();
    }

    public interface DomainClassAvailableWorkingSpec : DomainClassDef
    {
        string Attr_HotelID { get; }
        string Attr_MachineID { get; }
        string Attr_WorkingSpecID { get; }
        int Attr_PreAlarmSec { get; set; }

        bool LinkR11(DomainClassWashingMachineAssigner instance);
        bool UnlinkR11(DomainClassWashingMachineAssigner instance);
        DomainClassWashingMachineAssigner LinkedR11();

        bool LinkR8(DomainClassWashingMachine oneInstance, DomainClassWorkingSpec otherInstanceAvailableSpec);
        bool UnlinkR8(DomainClassWashingMachine oneInstance, DomainClassWorkingSpec otherInstanceAvailableSpec);
        DomainClassWashingMachine LinkedR8One();
        DomainClassWorkingSpec LinkedR8OtherAvailableSpec();

        DomainClassWashingMachineinUse LinkedR9();

        IEnumerable<DomainClassWashingMachineReservation> LinkedR13();

    }

    public interface DomainClassCardKey : DomainClassDef
    {
        string Attr_CardKeyID { get; }
        string Attr_GuestStayID { get; }

        bool LinkR6IsAssignedAsKeyFor(DomainClassGuestStay instance);
        bool UnlinkR6IsAssignedAsKeyFor(DomainClassGuestStay instance);
        DomainClassGuestStay LinkedR6IsAssignedAsKeyFor();

    }

    public interface DomainClassDoorwithLock : DomainClassDef
    {
        string Attr_DoorID { get; }
        string Attr_PIN_Number { get; set; }
        int Attr_NumberOfDigits { get; set; }
        DomainTypeDoorStatus Attr_Status { get; set; }
        int Attr_current_state { get; }

        void TakeEvent(EventData domainEvent);

        DomainClassWashingMachine LinkedR14();

        void Unlock();

        void Close();

        void Lock();

        void RequestPINCode();

        void RequestCardKey();

    }

    public interface DomainClassGuest : DomainClassDef
    {
        string Attr_Name { get; set; }
        string Attr_GuestID { get; }
        string Attr_GuestStayId { get; }
        string Attr_MailAddress { get; set; }

        bool LinkR5HaveTheRightToUse(DomainClassGuestStay instance);
        bool UnlinkR5HaveTheRightToUse(DomainClassGuestStay instance);
        DomainClassGuestStay LinkedR5HaveTheRightToUse();

    }

    public interface DomainClassGuestRoom : DomainClassDef
    {
        int Attr_Floor { get; set; }
        int Attr_RoomNumber { get; set; }
        string Attr_Name { get; set; }
        string Attr_RoomID { get; }
        int Attr_Capacity { get; set; }
        string Attr_HotelID { get; }

        bool LinkR3(DomainClassHotel instance);
        bool UnlinkR3(DomainClassHotel instance);
        DomainClassHotel LinkedR3();

        DomainClassGuestStay LinkedR4();

    }

    public interface DomainClassGuestStay : DomainClassDef
    {
        string Attr_GuestStayID { get; }
        DateTime Attr_StartTime { get; set; }
        DateTime Attr_EndTimeOfValidity { get; set; }
        string Attr_RoomID { get; }
        int Attr_Charge { get; set; }

        bool LinkR4IsAssignedFor(DomainClassGuestRoom instance);
        bool UnlinkR4IsAssignedFor(DomainClassGuestRoom instance);
        DomainClassGuestRoom LinkedR4IsAssignedFor();

        IEnumerable<DomainClassGuest> LinkedR5();

        DomainClassCardKey LinkedR6();

        DomainClassWashingMachineReservation LinkedR12RequestOfReservation();

        IEnumerable<DomainClassWashingMachineinUse> LinkedR18OneIsUsing();

        void Notify(DomainTypeNotificationForGuestStay topic);

    }

    public interface DomainClassHotel : DomainClassDef
    {
        string Attr_HotelID { get; }
        string Attr_Name { get; set; }

        IEnumerable<DomainClassLaundromatRoom> LinkedR1ProvideLaundromantService();

        IEnumerable<DomainClassGuestRoom> LinkedR3ProvideAsGuestStayingService();

        DomainClassWashingMachineAssigner LinkedR10ResponsibleForAssignment();

        void Support(string message);

    }

    public interface DomainClassLaundromatRoom : DomainClassDef
    {
        int Attr_Floor { get; set; }
        int Attr_RoomNumber { get; set; }
        string Attr_HotelID { get; }
        string Attr_RoomID { get; }

        bool LinkR1(DomainClassHotel instance);
        bool UnlinkR1(DomainClassHotel instance);
        DomainClassHotel LinkedR1();

        IEnumerable<DomainClassWashingMachine> LinkedR2();

    }

    public interface DomainClassNonReservationWashingMachine : DomainClassDef, SubClassR15
    {
        string Attr_MachineID { get; }

//        DomainClassWashingMachine GetSuperTypeR15WashingMachine();
        bool LinkR15(DomainClassWashingMachine instance);
        bool UnlinkR15(DomainClassWashingMachine instance);

    }

    public interface DomainClassReservableWashingMachine : DomainClassDef, SubClassR15
    {
        string Attr_MachineID { get; }
        int Attr_current_state { get; }
        string Attr_Next_ReservationID { get; }

        void TakeEvent(EventData domainEvent);

//        DomainClassWashingMachine GetSuperTypeR15WashingMachine();
        bool LinkR15(DomainClassWashingMachine instance);
        bool UnlinkR15(DomainClassWashingMachine instance);

        bool LinkR19NextReservation(DomainClassWashingMachineReservation instance);
        bool UnlinkR19NextReservation(DomainClassWashingMachineReservation instance);
        DomainClassWashingMachineReservation LinkedR19NextReservation();

    }

    public interface DomainClassWashingMachine : DomainClassDef
    {
        string Attr_MachineID { get; }
        string Attr_FriendryName { get; set; }
        bool Attr_IsBusy { get; set; }
        string Attr_RoomID { get; }
        string Attr_DoorID { get; }
        DomainTypeWashingMachineStatus Attr_Status { get; set; }
        int Attr_current_state { get; }

        void TakeEvent(EventData domainEvent);

        bool LinkR2IsSetUpAt(DomainClassLaundromatRoom instance);
        bool UnlinkR2IsSetUpAt(DomainClassLaundromatRoom instance);
        DomainClassLaundromatRoom LinkedR2IsSetUpAt();

        bool LinkR14FrontDoor(DomainClassDoorwithLock instance);
        bool UnlinkR14FrontDoor(DomainClassDoorwithLock instance);
        DomainClassDoorwithLock LinkedR14FrontDoor();

        IEnumerable<DomainClassAvailableWorkingSpec> LinkedR8OneAvailableSpec();

        SubClassR15 GetSubR15();

        DomainClassNonReservationWashingMachine LinkedR15NonReservationWashingMachine();

        DomainClassReservableWashingMachine LinkedR15ReservableWashingMachine();

        DomainClassWashingMachineinUse LinkedR18OtherIsUsedBy();

        bool IsAvailable();

        void StopExecution();

        void StartWashing(int timeInMinutes);

        void StartDrying(int timeInMinutes);

    }

    public interface DomainClassWashingMachineAssigner : DomainClassDef
    {
        string Attr_HotelID { get; }
        int Attr_current_state { get; }
        DomainTypeComplexDataType Attr_Test { get; set; }

        void TakeEvent(EventData domainEvent);

        bool LinkR10(DomainClassHotel instance);
        bool UnlinkR10(DomainClassHotel instance);
        DomainClassHotel LinkedR10();

        IEnumerable<DomainClassAvailableWorkingSpec> LinkedR11AssigningTarget();

    }

    public interface DomainClassWashingMachineinUse : DomainClassDef
    {
        string Attr_UseId { get; }
        string Attr_WorkingSpecID { get; }
        string Attr_GuestStayID { get; }
        string Attr_MachineID { get; }

        bool LinkR9CurrentSpec(DomainClassAvailableWorkingSpec instance);
        bool UnlinkR9CurrentSpec(DomainClassAvailableWorkingSpec instance);
        DomainClassAvailableWorkingSpec LinkedR9CurrentSpec();

        bool LinkR18(DomainClassGuestStay oneInstanceIsUsedBy, DomainClassWashingMachine otherInstanceIsUsing);
        bool UnlinkR18(DomainClassGuestStay oneInstanceIsUsedBy, DomainClassWashingMachine otherInstanceIsUsing);
        DomainClassGuestStay LinkedR18OneIsUsedBy();
        DomainClassWashingMachine LinkedR18OtherIsUsing();

    }

    public interface DomainClassWashingMachineReservation : DomainClassDef
    {
        string Attr_ReservationID { get; }
        DateTime Attr_ReservationTime { get; set; }
        DateTime Attr_EstimatedEndTime { get; set; }
        int Attr_PreAlarmTime { get; set; }
        string Attr_GuestStayID { get; }
        string Attr_WorkingSpecID { get; }
        string Attr_successor_ReservationID { get; }
        int Attr_current_state { get; }
        string Attr_MachineID { get; }
        string Attr_AlarmTimer { get; set; }

        void TakeEvent(EventData domainEvent);

        bool LinkR12ReservationOwner(DomainClassGuestStay instance);
        bool UnlinkR12ReservationOwner(DomainClassGuestStay instance);
        DomainClassGuestStay LinkedR12ReservationOwner();

        bool LinkR13Target(DomainClassAvailableWorkingSpec instance);
        bool UnlinkR13Target(DomainClassAvailableWorkingSpec instance);
        DomainClassAvailableWorkingSpec LinkedR13Target();

        bool LinkR17Successor(DomainClassWashingMachineReservation instance);
        bool UnlinkR17Successor(DomainClassWashingMachineReservation instance);
        DomainClassWashingMachineReservation LinkedR17Successor();

        DomainClassWashingMachineReservation LinkedR17Predecessor();

        DomainClassReservableWashingMachine LinkedR19();

    }

    public interface DomainClassWorkingSpec : DomainClassDef
    {
        string Attr_WorkingSpecID { get; }
        int Attr_WashingTime { get; set; }
        int Attr_DryingTime { get; set; }
        int Attr_StandardWeight { get; set; }
        int Attr_Price { get; set; }

        IEnumerable<DomainClassAvailableWorkingSpec> LinkedR8Other();

    }
}
