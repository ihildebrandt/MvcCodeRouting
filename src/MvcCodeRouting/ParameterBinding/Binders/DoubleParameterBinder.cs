﻿// Copyright 2013 Max Toro Q.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MvcCodeRouting.ParameterBinding.Binders {
   
   public class DoubleParameterBinder : ParameterBinder {

      readonly Regex regex = new Regex(@"^(-?(0|[1-9]\d*)(\.\d+)?)$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

      public override Type ParameterType {
         get { return typeof(double); }
      }

      public override bool TryBind(string value, IFormatProvider provider, out object result) {

         result = null;

         if (String.IsNullOrWhiteSpace(value))
            return false;

         double parsedResult;

         if (!Double.TryParse(value, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, provider, out parsedResult)
            || !this.regex.IsMatch(value)) {
            
            return false;
         }

         result = parsedResult;

         return true;
      }
   }
}