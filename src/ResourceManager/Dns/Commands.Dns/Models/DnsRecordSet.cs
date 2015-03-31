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

using Microsoft.Azure.Management.Dns.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Represents a set of records with the same name, with the same type and in the same zone.
    /// </summary>
    public class DnsRecordSet
    {
        /// <summary>
        /// Gets or sets the name of this record set, relative to the name of the zone to which it belongs and WITHOUT a terminating '.' (dot) character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the zone to which this recordset belongs.
        /// </summary>
        public string ZoneName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to which this record set belongs.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the TTL of all the records in this record set.
        /// </summary>
        public uint Ttl { get; set; }

        /// <summary>
        /// Gets or sets the Etag of this record set.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the type of DNS records in this record set. Only records of this type may be added to this record set.
        /// </summary>
        public RecordType RecordType { get; set; }

        /// <summary>
        /// Gets or sets the list of records in this record set.
        /// </summary>
        public List<DnsRecordBase> Records { get; set; }

        /// <summary>
        /// Gets or sets the tags of this record set.
        /// </summary>
        public Hashtable[] Tags { get; set; }
    }

    public abstract class DnsRecordBase
    {
        internal abstract object ToMamlRecord();

        internal static DnsRecordBase FromMamlRecord(object record)
        {
            if (record is Management.Dns.Models.ARecord)
            {
                var mamlRecord = (Management.Dns.Models.ARecord)record;
                return new ARecord
                {
                    Ipv4Address = mamlRecord.Ipv4Address
                };
            }
            else if (record is Management.Dns.Models.AaaaRecord)
            {
                var mamlRecord = (Management.Dns.Models.AaaaRecord)record;
                return new AaaaRecord
                {
                    Ipv6Address = mamlRecord.Ipv6Address
                };
            }
            else if (record is Management.Dns.Models.CnameRecord)
            {
                var mamlRecord = (Management.Dns.Models.CnameRecord)record;
                return new CnameRecord
                {
                    Cname = mamlRecord.Cname
                };
            }
            else if (record is Management.Dns.Models.NsRecord)
            {
                var mamlRecord = (Management.Dns.Models.NsRecord)record;
                return new NsRecord
                {
                    Nsdname = mamlRecord.Nsdname
                };
            }
            else if (record is Management.Dns.Models.MxRecord)
            {
                var mamlRecord = (Management.Dns.Models.MxRecord)record;
                return new MxRecord
                {
                    Exchange = mamlRecord.Exchange,
                    Preference = mamlRecord.Preference,
                };
            }
            else if (record is Management.Dns.Models.SrvRecord)
            {
                var mamlRecord = (Management.Dns.Models.SrvRecord)record;
                return new SrvRecord
                {
                    Port = mamlRecord.Port,
                    Priority = mamlRecord.Priority,
                    Target = mamlRecord.Target,
                    Weight = mamlRecord.Weight,
                };
            }
            else if (record is Management.Dns.Models.SoaRecord)
            {
                var mamlRecord = (Management.Dns.Models.SoaRecord)record;
                return new SoaRecord
                {
                    Email = mamlRecord.Email,
                    ExpireTime = mamlRecord.ExpireTime,
                    Host = mamlRecord.Host,
                    MinimumTtl = mamlRecord.MinimumTtl,
                    RefreshTime = mamlRecord.RefreshTime,
                    RetryTime = mamlRecord.RetryTime,
                    SerialNumber = mamlRecord.SerialNumber,
                };
            }
            else if (record is Management.Dns.Models.TxtRecord)
            {
                var mamlRecord = (Management.Dns.Models.TxtRecord)record;
                return new TxtRecord
                {
                    Value = mamlRecord.Value
                };
            }

            return null;
        }
    }

    public class ARecord :  DnsRecordBase
    {
        public string Ipv4Address { get; set; }

        public override string ToString()
        {
            return this.Ipv4Address;
        }

        internal override object ToMamlRecord()
        {
            return new Management.Dns.Models.ARecord
            {
                Ipv4Address = this.Ipv4Address,
            };
        }
    }

    public class AaaaRecord : DnsRecordBase
    {
        public string Ipv6Address { get; set; }

        public override string ToString()
        {
            return this.Ipv6Address;
        }

        internal override object ToMamlRecord()
        {
            return new Management.Dns.Models.AaaaRecord
            {
                Ipv6Address = this.Ipv6Address,
            };
        }
    }

    public class CnameRecord : DnsRecordBase
    {
        public string Cname { get; set; }

        public override string ToString()
        {
            return this.Cname;
        }

        internal override object ToMamlRecord()
        {
            return new Management.Dns.Models.CnameRecord
            {
                Cname = this.Cname,
            };
        }
    }

    public class NsRecord : DnsRecordBase
    {
        public string Nsdname { get; set; }

        public override string ToString()
        {
            return this.Nsdname;
        }

        internal override object ToMamlRecord()
        {
            return new Management.Dns.Models.NsRecord
            {
                Nsdname = this.Nsdname,
            };
        }
    }

    public class TxtRecord : DnsRecordBase
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return this.Value;
        }

        internal override object ToMamlRecord()
        {
            return new Management.Dns.Models.TxtRecord
            {
                Value = this.Value,
            };
        }
    }

    public class MxRecord : DnsRecordBase
    {
        public ushort Preference { get; set; }

        public string Exchange { get; set; }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", Preference, Exchange);
        }

        internal override object ToMamlRecord()
        {
            return new Management.Dns.Models.MxRecord
            {
                Exchange = this.Exchange,
                Preference = this.Preference,
            };
        }
    }

    public class SrvRecord : DnsRecordBase
    {
        public string Target { get; set; }

        public ushort Weight { get; set; }

        public ushort Port { get; set; }

        public ushort Priority { get; set; }

        public override string ToString()
        {
            return string.Format("[{0},{1},{2},{3}]", Priority, Weight, Port, Target);
        }

        internal override object ToMamlRecord()
        {
            return new Management.Dns.Models.SrvRecord
            {
                Priority = this.Priority,
                Target = this.Target,
                Weight = this.Weight,
                Port = this.Port,
            };
        }
    }

    public class SoaRecord : DnsRecordBase
    {
        public string Host { get; set; }

        public string Email { get; set; }

        public uint SerialNumber { get; set; }

        public uint RefreshTime { get; set; }

        public uint RetryTime { get; set; }

        public uint ExpireTime { get; set; }

        public uint MinimumTtl { get; set; }

        public override string ToString()
        {
            return string.Format("[{0},{1},{2},{3},{4},{5}]", Host, Email, RefreshTime, RetryTime, ExpireTime, MinimumTtl);
        }

        internal override object ToMamlRecord()
        {
            return new Management.Dns.Models.SoaRecord
            {
                Host = this.Host,
                Email = this.Email,
                SerialNumber = this.SerialNumber,
                RefreshTime = this.RefreshTime,
                RetryTime = this.RetryTime,
                ExpireTime = this.ExpireTime,
                MinimumTtl = this.MinimumTtl,
            };
        }
    }
}
