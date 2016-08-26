using System;

namespace CSIrc
{
    [AttributeUsage(AttributeTargets.Method)]
    class CommandProcessorAttribute : Attribute
    {
        public string Property { get; private set; }

        public CommandProcessorAttribute(string _property)
        {
            Property = _property;
        }
    }
}
