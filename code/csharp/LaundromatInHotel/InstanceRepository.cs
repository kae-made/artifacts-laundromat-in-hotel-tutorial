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

namespace LaundromatInHotel
{
    public class InstanceRepository
    {
        private Dictionary<string, List<DomainClassDef>> domainInstances = new Dictionary<string, List<DomainClassDef>>();

        public void Add(DomainClassDef instance)
        {
            if (!domainInstances.ContainsKey(instance.ClassName))
            {
                domainInstances.Add(instance.ClassName, new List<DomainClassDef>());
            }
            domainInstances[instance.ClassName].Add(instance);
        }

        public bool Delete(DomainClassDef instance)
        {
            bool result = false;

            if (domainInstances.ContainsKey(instance.ClassName))
            {
                if (domainInstances[instance.ClassName].Contains(instance))
                {
                    domainInstances[instance.ClassName].Remove(instance);
                    if (domainInstances[instance.ClassName].Count == 0)
                    {
                        domainInstances.Remove(instance.ClassName);
                    }
                    result = true;
                }
            }

            return result;
        }

        public IEnumerable<DomainClassDef> GetDomainInstances(string domainName)
        {
            List<DomainClassDef> result = new List<DomainClassDef>();

            if (domainInstances.ContainsKey(domainName))
            {
                var instances = domainInstances[domainName];
                foreach(var instance in instances)
                {
                    result.Add(instance);
                }
            }

            return result;
        }

        public void UpdateState(DomainClassDef instance, IDictionary<string,object> chnaged)
        {
            // TODO : write code to store changed state into eternal storage.
        }

    }
}
