using System;

namespace BeerDrinkin.Models
{
    /// <summary>
    /// Separate table for private data
    /// We don't use sync table for this to not auto sync into local db
    /// </summary>
    public class UserPrivateData : EntityData
    {
        public DateTime? DateOfBirth { get; set; }
    }
}