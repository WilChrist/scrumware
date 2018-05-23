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
    
    public partial class Backlog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Backlog()
        {
            this.State = "Running";
            this.UserStory = new HashSet<UserStory>();
            this.Sprint = new HashSet<Sprint>();
            this.Tache = new HashSet<Tache>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public string State { get; set; }
        public Nullable<int> TotalEstimation { get; set; }
    
        public virtual Projet Projet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserStory> UserStory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sprint> Sprint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tache> Tache { get; set; }
        public virtual User User { get; set; }
    }
}
