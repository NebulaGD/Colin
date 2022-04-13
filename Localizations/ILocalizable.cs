﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colin.Localizations
{
     public interface ILocalizable
    {
         string GetName( );
         string GetInformation( );
    }
}