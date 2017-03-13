using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Routing;
using System.Xml.Linq;

namespace Semprini.Mattia._5i.XMLReadWrite
{
    [HandleError(View = "ErrorePersonalizzato")]
    public class Persona
    {
        public XElement XML { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Numero { get; set; }

        public Persona(XElement e)
        {
            // prevedere un costruttore che accetta un XElement come parametro fatto.
            Nome = e.Attribute("Nome").Value;

            Cognome = e.Attribute("Cognome").Value;

            Indirizzo = e.Attribute("Indirizzo").Value;

            Numero = e.Attribute("Numero").Value;

        }



    }
    
    public class Persone : List<Persona>
    {
        public XElement XML { get; set; }

        [Required]
        public List<Persona> Persons { get; set; }
        

        public Persone(XElement e)
        {
            // prevedere un costruttore che accetta un XElement come parametro fatto.

            var persone = (from l in e.Elements("Persona")
                          select new Persona(l)).ToList();

            Persons = persone;
        }

        public Persone() { }



       public void Save(string s)
        {
            XML = new XElement("Persone",
                from l in this.Persons
                select new XElement("Persona",
                new XAttribute("Nome",
                from l2 in this.Persons
                select this.Persons.First().Nome),
                new XAttribute("Cognome",
                from l2 in this.Persons
                select this.Persons.First().Cognome),
                new XAttribute("Indirizzo",
                from l2 in this.Persons
                select this.Persons.First().Indirizzo),
                new XAttribute("Numero",
                from l2 in this.Persons
                select this.Persons.First().Numero))
            );
            XML.Save(s);
        }






    }
}
    