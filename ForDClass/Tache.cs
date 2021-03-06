//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForDClass
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tache
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tache()
        {
            this.State = "Running";
            this.Cout_Mon = 0;
            this.Cout_Tue = 0;
            this.Cout_Wen = 0;
            this.Cout_Thu = 0;
            this.Cout_Fri = 0;
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public string State { get; set; }
        public Nullable<int> Cout { get; set; }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<int> Cout_Mon { get; set; }
        public Nullable<int> Cout_Tue { get; set; }
        public Nullable<int> Cout_Wen { get; set; }
        public Nullable<int> Cout_Thu { get; set; }
        public Nullable<int> Cout_Fri { get; set; }
    
        public virtual Backlog Backlog { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual User User { get; set; }
    }
}
