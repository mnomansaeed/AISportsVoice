//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Custom_Audience_Segment
    {
        public int Segment_Id { get; set; }
        public Nullable<int> Location_ID { get; set; }
        public string Segment_Name { get; set; }
        public string Filter_Logic { get; set; }
        public string Language_Preference { get; set; }
        public string Commentary_Mode { get; set; }
        public Nullable<int> Voice_Id { get; set; }
        public string Notes { get; set; }
        public byte Is_Active { get; set; }
        public System.DateTime Created_Date { get; set; }
        public int Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public Nullable<int> Modified_By { get; set; }
        public Nullable<long> Audit_Id { get; set; }
        public string User_IP { get; set; }
        public int Site_Id { get; set; }
    }
}
