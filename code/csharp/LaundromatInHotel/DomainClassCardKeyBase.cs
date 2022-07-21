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
    public partial class DomainClassCardKeyBase : DomainClassCardKey
    {
        protected static readonly string className = "CardKey";
        public string ClassName { get { return className; } }

        InstanceRepository instanceRepository;
        protected Logger logger;

        public static DomainClassCardKeyBase CreateInstance(InstanceRepository instanceRepository, Logger logger=null, IList<ChangedState> changedStates=null)
        {
            var newInstance = new DomainClassCardKeyBase(instanceRepository, logger);
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CardKey(CardKeyID={newInstance.Attr_CardKeyID}):create");

            instanceRepository.Add(newInstance);

            if (changedStates !=null) changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Create, Target = newInstance, ChangedProperties = null });

            return newInstance;
        }

        public DomainClassCardKeyBase(InstanceRepository instanceRepository, Logger logger)
        {
            this.instanceRepository = instanceRepository;
            this.logger = logger;
            attr_CardKeyID = Guid.NewGuid().ToString();
        }
        protected string attr_CardKeyID;
        protected bool stateof_CardKeyID = false;

        protected string attr_GuestStayID;
        protected bool stateof_GuestStayID = false;

        public string Attr_CardKeyID { get { return attr_CardKeyID; } set { attr_CardKeyID = value; stateof_CardKeyID = true; } }
        public string Attr_GuestStayID { get { return attr_GuestStayID; } }


        // This method can be used as compare predicattion when calling InstanceRepository's SelectInstances method. 
        public static bool Compare(DomainClassCardKey instance, IDictionary<string, object> conditionPropertyValues)
        {
            bool result = true;
            foreach (var propertyName in conditionPropertyValues.Keys)
            {
                switch (propertyName)
                {
                    case "CardKeyID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_CardKeyID)
                        {
                            result = false;
                        }
                        break;
                    case "GuestStayID":
                        if ((string)conditionPropertyValues[propertyName] != instance.Attr_GuestStayID)
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
        protected LinkedInstance relR6GuestStayIsAssignedAsKeyFor;
        public DomainClassGuestStay LinkedR6IsAssignedAsKeyFor()
        {
            if (relR6GuestStayIsAssignedAsKeyFor == null)
            {
           var candidates = instanceRepository.GetDomainInstances("GuestStay").Where(inst=>(this.Attr_GuestStayID==((DomainClassGuestStay)inst).Attr_GuestStayID));
           relR6GuestStayIsAssignedAsKeyFor = new LinkedInstance() { Source = this, Destination = candidates.First(), RelationshipID = "R6", Phrase = "IsAssignedAsKeyFor" };

            }
            return relR6GuestStayIsAssignedAsKeyFor.GetDestination<DomainClassGuestStay>();
        }

        public bool LinkR6IsAssignedAsKeyFor(DomainClassGuestStay instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR6GuestStayIsAssignedAsKeyFor == null)
            {
                this.attr_GuestStayID = instance.Attr_GuestStayID;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CardKey(CardKeyID={this.Attr_CardKeyID}):link[GuestStay(GuestStayID={instance.Attr_GuestStayID})]");

                result = (LinkedR6IsAssignedAsKeyFor()!=null);
                if (result)
                {
                    if(changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Create, Target = relR6GuestStayIsAssignedAsKeyFor });
                }
            }
            return result;
        }

        public bool UnlinkR6IsAssignedAsKeyFor(DomainClassGuestStay instance, IList<ChangedState> changedStates=null)
        {
            bool result = false;
            if (relR6GuestStayIsAssignedAsKeyFor != null && ( this.Attr_GuestStayID==instance.Attr_GuestStayID ))
            {
                if (changedStates != null) changedStates.Add(new CLinkChangedState() { OP = ChangedState.Operation.Delete, Target = relR6GuestStayIsAssignedAsKeyFor });
        
                this.attr_GuestStayID = null;
                relR6GuestStayIsAssignedAsKeyFor = null;

                if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CardKey(CardKeyID={this.Attr_CardKeyID}):unlink[GuestStay(GuestStayID={instance.Attr_GuestStayID})]");


                result = true;
            }
            return result;
        }


        
        public bool Validate()
        {
            bool isValid = true;
            if (relR6GuestStayIsAssignedAsKeyFor == null)
            {
                isValid = false;
            }
            return isValid;
        }

        public void DeleteInstance(IList<ChangedState> changedStates=null)
        {
            if (logger != null) logger.LogInfo($"@{DateTime.Now.ToString("yyyyMMddHHmmss.fff")}:CardKey(CardKeyID={this.Attr_CardKeyID}):delete");

            changedStates.Add(new CInstanceChagedState() { OP = ChangedState.Operation.Delete, Target = this, ChangedProperties = null });

            instanceRepository.Delete(this);
        }

        // methods for storage
        public void Restore(IDictionary<string, object> propertyValues)
        {
            attr_CardKeyID = (string)propertyValues["CardKeyID"];
            stateof_CardKeyID = false;
            attr_GuestStayID = (string)propertyValues["GuestStayID"];
            stateof_GuestStayID = false;
        }
        
        public IDictionary<string, object> ChangedProperties()
        {
            var results = new Dictionary<string, object>();
            if (stateof_CardKeyID)
            {
                results.Add("CardKeyID", attr_CardKeyID);
                stateof_CardKeyID = false;
            }
            if (stateof_GuestStayID)
            {
                results.Add("GuestStayID", attr_GuestStayID);
                stateof_GuestStayID = false;
            }

            return results;
        }
        
        public IDictionary<string, object> GetProperties(bool onlyIdentity)
        {
            var results = new Dictionary<string, object>();

            results.Add("CardKeyID", attr_CardKeyID);
            if (!onlyIdentity) results.Add("GuestStayID", attr_GuestStayID);

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
