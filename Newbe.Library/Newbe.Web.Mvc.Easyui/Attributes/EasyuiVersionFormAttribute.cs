using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newbe.Web.Mvc.Easyui.Attributes
{
    public class EasyuiVersionFormAttribute : Attribute
    {
        public string Version { get; }

        public EasyuiVersionFormAttribute(string version)
        {
            Version = version;
        }
    }

    public class EasyuiVersionForm110Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm110Attribute() : base("1.1.0")
        {
        }
    }

    public class EasyuiVersionForm111Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm111Attribute() : base("1.1.1")
        {
        }
    }

    public class EasyuiVersionForm112Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm112Attribute() : base("1.1.2")
        {
        }
    }

    public class EasyuiVersionForm120Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm120Attribute() : base("1.2.0")
        {
        }
    }

    public class EasyuiVersionForm121Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm121Attribute() : base("1.2.1")
        {
        }
    }

    public class EasyuiVersionForm122Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm122Attribute() : base("1.2.2")
        {
        }
    }

    public class EasyuiVersionForm123Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm123Attribute() : base("1.2.3")
        {
        }
    }

    public class EasyuiVersionForm124Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm124Attribute() : base("1.2.4")
        {
        }
    }

    public class EasyuiVersionForm125Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm125Attribute() : base("1.2.5")
        {
        }
    }

    public class EasyuiVersionForm126Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm126Attribute() : base("1.2.6")
        {
        }
    }

    public class EasyuiVersionForm130Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm130Attribute() : base("1.3.0")
        {
        }
    }

    public class EasyuiVersionForm131Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm131Attribute() : base("1.3.1")
        {
        }
    }

    public class EasyuiVersionForm132Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm132Attribute() : base("1.3.2")
        {
        }
    }

    public class EasyuiVersionForm133Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm133Attribute() : base("1.3.3")
        {
        }
    }

    public class EasyuiVersionForm134Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm134Attribute() : base("1.3.4")
        {
        }
    }

    public class EasyuiVersionForm135Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm135Attribute() : base("1.3.5")
        {
        }
    }

    public class EasyuiVersionForm136Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm136Attribute() : base("1.3.6")
        {
        }
    }

    public class EasyuiVersionForm140Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm140Attribute() : base("1.4.0")
        {
        }
    }

    public class EasyuiVersionForm141Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm141Attribute() : base("1.4.1")
        {
        }
    }

    public class EasyuiVersionForm142Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm142Attribute() : base("1.4.2")
        {
        }
    }

    public class EasyuiVersionForm143Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm143Attribute() : base("1.4.3")
        {
        }
    }

    public class EasyuiVersionForm144Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm144Attribute() : base("1.4.4")
        {
        }
    }

    public class EasyuiVersionForm145Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm145Attribute() : base("1.4.5")
        {
        }
    }

    public class EasyuiVersionForm150Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm150Attribute() : base("1.5.0")
        {
        }
    }

    public class EasyuiVersionForm151Attribute : EasyuiVersionFormAttribute
    {
        public EasyuiVersionForm151Attribute() : base("1.5.1")
        {
        }
    }
}