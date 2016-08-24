using System;

namespace CSIrc
{
    [AttributeUsage(AttributeTargets.Method)]
    class MessageProcessorAttribute : Attribute
    {
        public string Property { get; private set; }

        public MessageProcessorAttribute(string _property)
        {
            Property = _property;
        }
    }
}
