using MCronberg.Sap.ConsoleInput.Core;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MCronberg.Sap.ConsoleInput.ConsoleTest
{
public class Root {
    public Settings Settings { get; set; }
}

public class Settings
{
    [DescriptionText("MyNumber description")]
    [ShortName("n")]
    public int? MyNumber { get; set; }

    [DescriptionText("MyString description")]
    [ShortName("s")]
    public string MyString { get; set; }

    [DescriptionText("MyBool description")]
    [ShortName("b")]
    [IsRequired]
    public bool? MyBool { get; set; }
}
}
