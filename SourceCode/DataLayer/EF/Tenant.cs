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
    
    public partial class Tenant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tenant()
        {
            this.Location = new HashSet<Location>();
        }
    
        public int TenantId { get; set; }
        public string TenantSecret { get; set; }
        public string TenantName { get; set; }
        public string ContactEmail { get; set; }
        public Nullable<int> SubscriptionId { get; set; }
        public Nullable<System.DateTime> SubscriptionStartDate { get; set; }
        public Nullable<System.DateTime> SubscriptionEndDate { get; set; }
        public byte Is_Active { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public int Created_By { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public Nullable<int> Modified_By { get; set; }
        public Nullable<long> Audit_Id { get; set; }
        public string User_IP { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Location { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
