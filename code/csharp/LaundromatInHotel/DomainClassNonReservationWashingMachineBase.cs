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
    public partial class DomainClassNonReservationWashingMachineBase : DomainClassNonReservationWashingMachine
    {
        protected static readonly string className = "NonReservationWashingMachine";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassNonReservationWashingMachineBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null)
        {
            var newInstance = new DomainClassNonReservationWashingMachineBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:NonReservationWashingMachine(MachineID={newInstance.Attr_MachineID}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassNonReservationWashingMachineBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
        }
        protected string attr_MachineID;
        protected bool stateof_MachineID = false;

        public string Attr_MachineID { get { return attr_MachineID; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassNonReservationWashingMachine instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "MachineID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_MachineID)
                        {
                            result = false;
                        }
                        break;
                }
                if (result== false)
                {
                    break;
                }
            }
            return result;
        }
        protected LinkedInstance relR15WashingMachine;
        public DomainClassWashingMachine GetSuperClassR15()
        {
            if (relR15WashingMachine == null)
            {
                var candidates = instanceRepository.GetDomainInstances("WashingMachine").Where(inst => (this.Attr_MachineID==((DomainClassWashingMachine)inst).Attr_MachineID));
                relR15WashingMachine = new LinkedInstance() { Source = this, Destination = candidates.First(), RelationshipID = "R15", Phrase = null };
            }
            return relR15WashingMachine.GetDestination<DomainClassWashingMachine>();
        }

        public bool LinkR15(DomainClassWashingMachine instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR15WashingMachine == null)
            {
                this.attr_MachineID = instance.Attr_MachineID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:NonReservationWashingMachine(MachineID={this.Attr_MachineID}):link[WashingMachine(MachineID={instance.Attr_MachineID})]");

                result = (GetSuperClassR15()!=null);
                if (result)
                {
                    if (changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR15WashingMachine });
                }
            }
            return result;
        }
        
        public bool UnlinkR15(DomainClassWashingMachine instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR15WashingMachine != null && ( this.Attr_MachineID==instance.Attr_MachineID ))
            {
                if (changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR15WashingMachine });
        
                this.attr_MachineID = null;
                relR15WashingMachine = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:NonReservationWashingMachine(MachineID={this.Attr_MachineID}):unlink[WashingMachine(MachineID={instance.Attr_MachineID})]");

                result = true;
            }
            return result;
        }



        
        public bool Validate()
        {
            bool isValid = true;
            if (relR15WashingMachine == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:NonReservationWashingMachine(MachineID={this.Attr_MachineID}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            attr_MachineID = (string)propertyValues["MachineID"];
            stateof_MachineID = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_MachineID)
            {
                results.Add("MachineID", attr_MachineID);
                stateof_MachineID = false;
            }

            return results;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            if (!onlyIdentity) results.Add("MachineID", attr_MachineID);

            return results;
        }

#if false
        List<ChangedState> changedStates = new List<ChangedState>();

        public IList<ChangedState> ChangedStates()
        {
            List<ChangedState> results = new List<ChangedState>();
            results.AddRange(changedStates);
            results.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Update, Target = this, ChangedProperties = ChangedProperties() });
            changedStates.Clear();

            return results;
        }
#endif
    }
}
