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
    public partial class DomainClassHotelBase : DomainClassHotel
    {
        private static readonly string className = "Hotel";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassHotelBase CreateInstance(InstanceRepository instanceRepository, Logger logger)
        {
            var newInstance = new DomainClassHotelBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:Hotel(HotelID={newInstance.Attr_HotelID}):create");
            instanceRepository.Add(newInstance);

            return newInstance;
        }

        public DomainClassHotelBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_HotelID = Guid.NewGuid().ToString();
        }

        string attr_HotelID;
        string attr_Name;

        public string Attr_HotelID { get { return attr_HotelID; } set { attr_HotelID = value; } }
        public string Attr_Name { get { return attr_Name; } set { attr_Name = value; } }

        public IEnumerable<DomainClassLaundromatRoom> LinkedR1ProvideLaundromantService()
        {
            var result = new List<DomainClassLaundromatRoom>();
            var candidates = instanceRepository.GetDomainInstances("LaundromatRoom").Where(inst=>(this.Attr_HotelID==((DomainClassLaundromatRoom)inst).Attr_HotelID));
            foreach (var c in candidates)
            {
                result.Add((DomainClassLaundromatRoom)c);
            }
            return result;
        }
        public IEnumerable<DomainClassGuestRoom> LinkedR3ProvideAsGuestStayingService()
        {
            var result = new List<DomainClassGuestRoom>();
            var candidates = instanceRepository.GetDomainInstances("GuestRoom").Where(inst=>(this.Attr_HotelID==((DomainClassGuestRoom)inst).Attr_HotelID));
            foreach (var c in candidates)
            {
                result.Add((DomainClassGuestRoom)c);
            }
            return result;
        }
        public DomainClassWashingMachineAssigner LinkedR10ResponsibleForAssignment()
        {
            var candidates = instanceRepository.GetDomainInstances("WashingMachineAssigner").Where(inst=>(this.Attr_HotelID==((DomainClassWashingMachineAssigner)inst).Attr_HotelID));
            return (DomainClassWashingMachineAssigner)candidates.First();
        }
        
        public bool Validate()
        {
            bool isValid = true;
            if (this.LinkedR3ProvideAsGuestStayingService().Count() == 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public void Dispose()
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:Hotel(HotelID={this.Attr_HotelID}):delete");
            instanceRepository.Delete(this);
        }
    }
}
