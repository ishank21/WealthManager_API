using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Common
{
    public class CommonMethods
    {
        public static int GetRoleType(string Role)
        {
            switch(Role)
            {
                case "Agent":
                    return 1;
                case "Client":
                    return 2;
                case "Admin":
                    return 3;
                default:
                    return 0;
            }
        }
        public static int GenerateRandomNo()
        {
            int min = 0000;
            int max = 9999;
            Random rand = new Random();
            return rand.Next(min, max);
        }
    }
}
