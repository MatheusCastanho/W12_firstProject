using System;

namespace Projeto.Models.Proxy
{
    public class RepositoriesProxy
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Full_Name { get; set; }
        public OwnerProxy Owner{ get; set; }
        public string Description { get; set; } 
        public string Language {get; set; }
        public DateTime updated_at { get; set; }
        
       
    }
}