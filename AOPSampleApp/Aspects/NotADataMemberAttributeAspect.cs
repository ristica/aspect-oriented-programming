using System;

namespace AOPSampleApp.Aspects
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NotADataMemberAttributeAspect : Attribute
    {
        // just a merker aspect to differentiate between 
        // DataMemebr needed and not needed properties
    }
}
