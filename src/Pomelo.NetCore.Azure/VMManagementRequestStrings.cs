﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomelo.NetCore.Azure
{
    internal class VMManagementRequestStrings
    {
        // vmname, adminname, adminpasswd, image
        public const string CREATE_VM =
            @"{
    ""id"": ""/subscriptions/<subid>/resourceGroups/Pomelo/providers/Microsoft.Compute/virtualMachines/<vmname>"",
    ""name"": ""<vmname>"",
    ""type"": ""Microsoft.Compute/virtualMachines"",
    ""location"": ""japanwest"",
    ""properties"": {
        ""hardwareProfile"": {
            ""vmSize"": ""Basic_A1""
        },
        ""storageProfile"": {
            ""osDisk"": {
                ""name"": ""<vmname>"",
                ""osType"": ""Linux"",
                ""image"": {
                    ""uri"": ""<image>""
                },
                ""vhd"": {
                    ""uri"": ""http://pomeloide.blob.core.windows.net/vhds/<vmname>.vhd""
                },
                ""caching"": ""ReadWrite"",
                ""createOption"": ""FromImage""
            }
        },
        ""osProfile"": {
            ""computerName"": ""<vmname>"",
            ""adminUsername"": ""<adminname>"",
            ""adminPassword"": ""<adminpasswd>"",
            ""linuxConfiguration"": {
                ""disablePasswordAuthentication"": false
            },
            ""secrets"": []
        },
        ""networkProfile"": {
            ""networkInterfaces"": [
                {
                    ""id"": ""/subscriptions/<subid>/resourceGroups/pomelo/providers/Microsoft.Network/networkInterfaces/<vmname>""
                }
            ]
        }
    }
}";

        public const string CREATE_PUBLIC_IP = 
            @"{
   ""location"": ""japanwest"",
   ""properties"": {
      ""publicIPAllocationMethod"": ""Static"",
      ""idleTimeoutInMinutes"": 30
   }
}";


        public const string CREATE_NIC = 
            @"{
   ""location"":""japanwest"",
   ""properties"":{  
      ""networkSecurityGroup"":{  
         ""id"":""/subscriptions/<subid>/resourceGroups/pomelo/providers/Microsoft.Network/networkSecurityGroups/Pomelo""
      },
      ""ipConfigurations"":[
         {
            ""name"":""<vmname>"",
            ""properties"":{  
               ""subnet"":{
                  ""id"":""/subscriptions/<subid>/resourceGroups/pomelo/providers/Microsoft.Network/virtualNetworks/Pomelo/subnets/default""
               },
               ""privateIPAllocationMethod"":""Dynamic"",
               ""publicIPAddress"":{
                  ""id"":""/subscriptions/<subid>/resourceGroups/pomelo/providers/Microsoft.Network/publicIPAddresses/<vmname>""
               }
            }
         }
      ]
   }
}";

        public const string UPDATE_PASSWORD_EXTENSION =
            @"{
  ""id"":""/subscriptions/<subid>/resourceGroups/pomelo/providers/Microsoft.Compute/virtualMachines/<vmname>/extensions/VMAccessForLinux"",
  ""name"": ""enablevmaccess"",
  ""type"": ""Microsoft.Compute/virtualMachines/extensions"",
  ""location"": ""japanwest"",
  ""properties"": {
        ""publisher"": ""Microsoft.OSTCExtensions"",
        ""type"": ""VMAccessForLinux"",
        ""typeHandlerVersion"": ""1.4"",
        ""autoUpgradeMinorVersion"": true,
        ""settings"": {
        },
        ""protectedSettings"": {
            ""username"":""<username>"",
            ""password"":""<password>"",
        }
    }
}";
    }
}
