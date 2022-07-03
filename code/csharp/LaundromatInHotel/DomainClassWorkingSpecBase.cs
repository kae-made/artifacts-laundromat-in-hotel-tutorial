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
    public partial class DomainClassWorkingSpecBase : DomainClassWorkingSpec
    {
        private static readonly string className = "WorkingSpec";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassWorkingSpecBase CreateInstance(InstanceRepository instanceRepository, Logger logger)
        {
            var newInstance = new DomainClassWorkingSpecBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WorkingSpec(WorkingSpecID={newInstance.Attr_WorkingSpecID}):create");
            instanceRepository.Add(newInstance);

            return newInstance;
        }

        public DomainClassWorkingSpecBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_WorkingSpecID = Guid.NewGuid().ToString();
        }

        string attr_WorkingSpecID;
        int attr_WashingTime;
        int attr_DryingTime;
        int attr_StandardWeight;
        int attr_Price;

        public string Attr_WorkingSpecID { get { return attr_WorkingSpecID; } set { attr_WorkingSpecID = value; } }
        public int Attr_WashingTime { get { return attr_WashingTime; } set { attr_WashingTime = value; } }
        public int Attr_DryingTime { get { return attr_DryingTime; } set { attr_DryingTime = value; } }
        public int Attr_StandardWeight { get { return attr_StandardWeight; } set { attr_StandardWeight = value; } }
        public int Attr_Price { get { return attr_Price; } set { attr_Price = value; } }

        public IEnumerable<DomainClassAvailableWorkingSpec> LinkedR8Other()
        {
            var result = new List<DomainClassAvailableWorkingSpec>();
            var candidates = instanceRepository.GetDomainInstances("AvailableWorkingSpec").Where(inst=>(this.Attr_WorkingSpecID==((DomainClassAvailableWorkingSpec)inst).Attr_WorkingSpecID));
            foreach (var c in candidates)
            {
                result.Add((DomainClassAvailableWorkingSpec)c);
            }
            return result;
        }
        
        public bool Validate()
        {
            bool isValid = true;
            if (this.LinkedR8Other().Count() == 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public void Dispose()
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:WorkingSpec(WorkingSpecID={this.Attr_WorkingSpecID}):delete");
            instanceRepository.Delete(this);
        }
    }
}
