//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.Genre = new HashSet<Genre>();
            this.Author = new HashSet<Author>();
        }
    
        public int BookId { get; set; }
        public System.DateTime FinalReleaseDate { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
    
        public virtual ICollection<Genre> Genre { get; set; }
        public virtual ICollection<Author> Author { get; set; }
    }
}