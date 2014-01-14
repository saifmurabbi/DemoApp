using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.v201309;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAdword
{
    public class ExampleUtilities
    {
        public static string FormatException(Exception ex)
        {
            List<String> messages = new List<string>();
            Exception rootEx = ex;
            while (rootEx != null)
            {
                messages.Add(String.Format("{0} ({1})\n\n{2}\n", rootEx.GetType().ToString(),
                    rootEx.Message, rootEx.StackTrace));
                rootEx = rootEx.InnerException;
            }
            return String.Join("\nCaused by\n\n", messages.ToArray());
        }
    }

}
