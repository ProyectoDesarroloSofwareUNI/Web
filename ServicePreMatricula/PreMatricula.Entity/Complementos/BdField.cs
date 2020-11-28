using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreMatricula.Entity.Complementos
{
  using System;
  [AttributeUsage(AttributeTargets.Property)]
  public class DbField : Attribute
  {
    public string Name { get; set; }

    public DbField(string name)
    {
      Name = name;
    }
  }
}

