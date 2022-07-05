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
    public partial class DomainClassLaundromatRoomBase : DomainClassLaundromatRoom
    {
        private static readonly string className = "LaundromatRoom";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassLaundromatRoomBase CreateInstance(InstanceRepository instanceRepository, Logger logger)
        {
            var newInstance = new DomainClassLaundromatRoomBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:LaundromatRoom(RoomID={newInstance.Attr_RoomID}):create");

            instanceRepository.Add(newInstance);

            return newInstance;
        }

        public DomainClassLaundromatRoomBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_RoomID = Guid.NewGuid().ToString();
        }

        int attr_Floor;
        int attr_RoomNumber;
        string attr_HotelID;
        string attr_RoomID;

        public int Attr_Floor { get { return attr_Floor; } set { attr_Floor = value; } }
        public int Attr_RoomNumber { get { return attr_RoomNumber; } set { attr_RoomNumber = value; } }
        public string Attr_HotelID { get { return attr_HotelID; } }
        public string Attr_RoomID { get { return attr_RoomID; } set { attr_RoomID = value; } }

        private DomainClassHotel relR1Hotel;

        public DomainClassHotel LinkedR1()
        {
            if (relR1Hotel == null)
            {
                var candidates = instanceRepository.GetDomainInstances("Hotel").Where(inst=>(this.Attr_HotelID==((DomainClassHotel)inst).Attr_HotelID));
                relR1Hotel = (DomainClassHotel)candidates.First();
            }
            return relR1Hotel;
        }

        public bool LinkR1(DomainClassHotel instance)
        {
            bool result = false;
            if (relR1Hotel == null)
            {
                this.attr_HotelID = instance.Attr_HotelID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:LaundromatRoom(RoomID={this.Attr_RoomID}):link[Hotel(HotelID={instance.Attr_HotelID})]");

                result = true;
            }
            return result;
        }
        public bool UnlinkR1(DomainClassHotel instance)
        {
            bool result = false;
            if (relR1Hotel != null && ( this.Attr_HotelID==instance.Attr_HotelID ))
            {
                this.attr_HotelID = null;
                relR1Hotel = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:LaundromatRoom(RoomID={this.Attr_RoomID}):unlink[Hotel(HotelID={instance.Attr_HotelID})]");


                result = true;
            }
            return result;
        }

        public IEnumerable<DomainClassWashingMachine> LinkedR2()
        {
            var result = new List<DomainClassWashingMachine>();
            var candidates = instanceRepository.GetDomainInstances("WashingMachine").Where(inst=>(this.Attr_RoomID==((DomainClassWashingMachine)inst).Attr_RoomID));
            foreach (var c in candidates)
            {
                result.Add((DomainClassWashingMachine)c);
            }
            return result;
        }
        
        public bool Validate()
        {
            bool isValid = true;
            if (relR1Hotel == null)
            {
                isValid = false;
            }
            if (this.LinkedR2().Count() == 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public void Dispose()
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:LaundromatRoom(RoomID={this.Attr_RoomID}):delete");

            instanceRepository.Delete(this);
        }
    }
}
