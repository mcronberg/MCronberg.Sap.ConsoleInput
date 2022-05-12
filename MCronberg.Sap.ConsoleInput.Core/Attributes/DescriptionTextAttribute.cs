using System;

namespace MCronberg.Sap.ConsoleInput.Core
{
    public class DescriptionTextAttribute : Attribute
    {
        public string Description { get; set; }

        public DescriptionTextAttribute(string description)
        {
            Description = description;
        }
    }
}
