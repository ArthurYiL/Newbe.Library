﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newbe.Web.Mvc.Easyui.Attributes
{
    public class JsFunctionAttribute : Attribute
    {
        public string[] ParamNames { get; }

        public JsFunctionAttribute(params string[] paramNames)
        {
            ParamNames = paramNames;
        }
    }
}