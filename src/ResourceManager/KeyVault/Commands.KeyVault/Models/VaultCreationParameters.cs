﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class VaultCreationParameters
    {        
        public string VaultName { get; set; }
        public string ResourceGroupName { get; set; }
        public string Location { get; set; }
        public Hashtable[] Tags { get; set; }
        public string SkuName { get; set; }
        public string SkuFamilyName { get; set; }
        public bool EnabledForDeployment { get; set; }
        public Guid TenantId { get; set; }
        public Guid ObjectId { get; set; }
        public string[] PermissionsToKeys { get; set; }
        public string[] PermissionsToSecrets { get; set; }
    }
}