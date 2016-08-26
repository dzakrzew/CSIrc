using System;
using System.Linq;
using System.Reflection;

namespace CSIrc
{
    static class CommandProcessing
    {
        public static MethodInfo GetMethod(string _str)
        {
            MethodInfo oMethodInfo = null;
            Type oType = typeof(CommandProcessingMethods);
            MethodInfo[] aoInfo = oType.GetMethods();

            foreach (MethodInfo oInfo in aoInfo)
            {
                var oAttributes = oInfo.GetCustomAttributes(typeof(CommandProcessorAttribute), false);

                if (oAttributes == null || oAttributes.Count() == 0)
                {
                    continue;
                }

                foreach (CommandProcessorAttribute oAttribute in oAttributes)
                {
                    if (oAttribute.Property == _str)
                    {
                        oMethodInfo = oInfo;
                        break;
                    }
                }
            }

            return oMethodInfo;
        }
    }
}
