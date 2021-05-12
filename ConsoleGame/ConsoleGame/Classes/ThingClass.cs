using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGame.Classes
{
    class ThingClass
    {
        protected string name;

        public ThingClass( string name)
        {
            this.name = name;
        }
        public string GetName() { return name; }

        public virtual string WrithDiscription() 
        {
            return name;
        }
    }
   
}
