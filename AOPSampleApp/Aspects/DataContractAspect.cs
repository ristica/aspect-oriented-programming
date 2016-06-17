using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace AOPSampleApp.Aspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Class)]
    public sealed class DataContractAspect : TypeLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            var targetType = (Type)targetElement;

            // find all classes to attach DataContract attribute
            var dataContractAspect = new CustomAttributeIntroductionAspect(
                                        new ObjectConstruction(typeof(DataContractAttribute).GetConstructor(Type.EmptyTypes)));

            // find all properties to attach DataMemebr attribute
            var dataMemberAspect = new CustomAttributeIntroductionAspect(
                                        new ObjectConstruction(typeof(DataMemberAttribute).GetConstructor(Type.EmptyTypes)));

            yield return new AspectInstance(targetType, dataContractAspect);

            // attach to all proeprties that are public or declared or an instance
            foreach (var property in targetType.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
            {
                // here we are going to "use" our NotDataMemebrAttribute
                if (property.CanWrite && !property.IsDefined(typeof(NotADataMemberAttributeAspect), false))
                {
                    yield return new AspectInstance(property, dataMemberAspect);
                }
            }
        }
    }
}
