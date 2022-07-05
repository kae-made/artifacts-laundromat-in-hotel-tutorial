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
using Kae.Utility.Logging;

namespace LaundromatInHotel
{
    public partial class DomainClassAvailableWorkingSpecBase : DomainClassAvailableWorkingSpec
    {
        private static readonly string className = "AvailableWorkingSpec";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassAvailableWorkingSpecBase CreateInstance(InstanceRepository instanceRepository, Logger logger)
        {
            var newInstance = new DomainClassAvailableWorkingSpecBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:AvailableWorkingSpec(MachineID={newInstance.Attr_MachineID},WorkingSpecID={newInstance.Attr_WorkingSpecID}):create");

            instanceRepository.Add(newInstance);

            return newInstance;
        }

        public DomainClassAvailableWorkingSpecBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
        }

        string attr_HotelID;
        string attr_MachineID;
        string attr_WorkingSpecID;
        int attr_PreAlarmSec;

        public string Attr_HotelID { get { return attr_HotelID; } }
        public string Attr_MachineID { get { return attr_MachineID; } }
        public string Attr_WorkingSpecID { get { return attr_WorkingSpecID; } }
        public int Attr_PreAlarmSec { get { return attr_PreAlarmSec; } set { attr_PreAlarmSec = value; } }

        private DomainClassWashingMachineAssigner relR11WashingMachineAssigner;
        private DomainClassWashingMachine relR8WashingMachine;
        private DomainClassWorkingSpec relR8WorkingSpecAvailableSpec;

        public DomainClassWashingMachineAssigner LinkedR11()
        {
            if (relR11WashingMachineAssigner == null)
            {
                var candidates = instanceRepository.GetDomainInstances("WashingMachineAssigner").Where(inst=>(this.Attr_HotelID==((DomainClassWashingMachineAssigner)inst).Attr_HotelID));
                relR11WashingMachineAssigner = (DomainClassWashingMachineAssigner)candidates.First();
            }
            return relR11WashingMachineAssigner;
        }

        public bool LinkR11(DomainClassWashingMachineAssigner instance)
        {
            bool result = false;
            if (relR11WashingMachineAssigner == null)
            {
                this.attr_HotelID = instance.Attr_HotelID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:AvailableWorkingSpec(MachineID={this.Attr_MachineID},WorkingSpecID={this.Attr_WorkingSpecID}):link[WashingMachineAssigner(HotelID={instance.Attr_HotelID})]");

                result = true;
            }
            return result;
        }
        public bool UnlinkR11(DomainClassWashingMachineAssigner instance)
        {
            bool result = false;
            if (relR11WashingMachineAssigner != null && ( this.Attr_HotelID==instance.Attr_HotelID ))
            {
                this.attr_HotelID = null;
                relR11WashingMachineAssigner = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:AvailableWorkingSpec(MachineID={this.Attr_MachineID},WorkingSpecID={this.Attr_WorkingSpecID}):unlink[WashingMachineAssigner(HotelID={instance.Attr_HotelID})]");


                result = true;
            }
            return result;
        }
        public bool LinkR8(DomainClassWashingMachine oneInstance, DomainClassWorkingSpec otherInstanceAvailableSpec)
        {
            bool result = false;
            if (relR8WashingMachine == null && relR8WorkingSpecAvailableSpec == null)
            {
                this.attr_MachineID = oneInstance.Attr_MachineID;
                this.attr_WorkingSpecID = otherInstanceAvailableSpec.Attr_WorkingSpecID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:AvailableWorkingSpec(MachineID={this.Attr_MachineID},WorkingSpecID={this.Attr_WorkingSpecID}):link[One(WashingMachine(MachineID={oneInstance.Attr_MachineID})),Other(WorkingSpec(WorkingSpecID={otherInstanceAvailableSpec.Attr_WorkingSpecID}))]");

                result = true;
            }
            return result;
        }
        public bool UnlinkR8(DomainClassWashingMachine oneInstance, DomainClassWorkingSpec otherInstanceAvailableSpec)
        {
            bool result = false;
            if (relR8WashingMachine != null && relR8WorkingSpecAvailableSpec != null)
            {
                if ((this.Attr_MachineID==oneInstance.Attr_MachineID) && (this.Attr_WorkingSpecID==otherInstanceAvailableSpec.Attr_WorkingSpecID))
                {

                    this.attr_MachineID = null;
                    this.attr_WorkingSpecID = null;
                    relR8WashingMachine = null;
                    relR8WorkingSpecAvailableSpec = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:AvailableWorkingSpec(MachineID={this.Attr_MachineID},WorkingSpecID={this.Attr_WorkingSpecID}):unlink[WashingMachine(MachineID={oneInstance.Attr_MachineID})]");

                    result = true;
                }
            }
            return result;
        }
        public DomainClassWashingMachine LinkedR8One()
        {
            if (relR8WashingMachine == null)
            {
                var candidates = instanceRepository.GetDomainInstances("WashingMachine").Where(inst=>(this.Attr_MachineID==((DomainClassWashingMachine)inst).Attr_MachineID));
                relR8WashingMachine = (DomainClassWashingMachine)candidates.First();
            }
            return relR8WashingMachine;
        }
        public DomainClassWorkingSpec LinkedR8OtherAvailableSpec()
        {
            if (relR8WorkingSpecAvailableSpec == null)
            {
                var candidates = instanceRepository.GetDomainInstances("WorkingSpec").Where(inst=>(this.Attr_WorkingSpecID==((DomainClassWorkingSpec)inst).Attr_WorkingSpecID));
                relR8WorkingSpecAvailableSpec = (DomainClassWorkingSpec)candidates.First();
            }
            return relR8WorkingSpecAvailableSpec;
        }


        public DomainClassWashingMachineinUse LinkedR9()
        {
            var candidates = instanceRepository.GetDomainInstances("WashingMachineinUse").Where(inst=>(this.Attr_WorkingSpecID==((DomainClassWashingMachineinUse)inst).Attr_WorkingSpecID && this.Attr_MachineID==((DomainClassWashingMachineinUse)inst).Attr_MachineID));
            return (DomainClassWashingMachineinUse)candidates.First();
        }
        public IEnumerable<DomainClassWashingMachineReservation> LinkedR13()
        {
            var result = new List<DomainClassWashingMachineReservation>();
            var candidates = instanceRepository.GetDomainInstances("WashingMachineReservation").Where(inst=>(this.Attr_WorkingSpecID==((DomainClassWashingMachineReservation)inst).Attr_WorkingSpecID && this.Attr_MachineID==((DomainClassWashingMachineReservation)inst).Attr_MachineID));
            foreach (var c in candidates)
            {
                result.Add((DomainClassWashingMachineReservation)c);
            }
            return result;
        }
        
        public bool Validate()
        {
            bool isValid = true;
            if (relR11WashingMachineAssigner == null)
            {
                isValid = false;
            }
            if (relR8WashingMachine == null)
            {
                isValid = false;
            }
            if (relR8WorkingSpecAvailableSpec == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void Dispose()
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:AvailableWorkingSpec(MachineID={this.Attr_MachineID},WorkingSpecID={this.Attr_WorkingSpecID}):delete");

            instanceRepository.Delete(this);
        }
    }
}
