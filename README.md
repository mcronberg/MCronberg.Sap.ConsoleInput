# MCronberg.Sap.ConsoleInput

MCronberg.Sap.ConsoleInput is a Simple As Possible Console Input package. It can be used to include arguments to console applications from

- a json-file
- application arguments
- input from console

Please note that it's a "simple as possible" package - use it as is, as inpspiration or as a template.

## Model

To use the package you need to create a model of one of these types

- string
- bool? (nullable)
- int? (nullable)

and decorate the properties with attributes like

- DescriptionText
- ShortName
- IsRequired

Example:

```csharp
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
```

Based on this model you can use a binder to serialize to an object.

## FileBinder

Use the FileBinder to serialize data from a json file to an object.

### Simple JSON

```json
{
    "MyNumber": 1,
    "MyString": "s",
    "MyBool": true
}
```

Bind with:

```csharp
var s1 = FileBinder.Bind<Settings>("path to file");
```

### JSON with root

```json
{
  "Settings": {
    "MyNumber": 1,
    "MyString": "s",
    "MyBool": true
  }
}
```

Create a root class to map the JSON structure:

```csharp
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
```

and then bind with

```csharp
var s2 = FileBinder.Bind<Settings, Root>("path to file");
```
## Arguments

Given that an application is started with

```
[app.exe] -shortname1 value1 -shortname2 value2 ...

like

[app.exe] -i 1 -n test

where -i and -n are shortnames and 1 and test are values.
```

and all properties in the model are decorated with the ShortName-attribute you can bind with

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var s4 = ArgumentsBinder.Bind<Settings>(args);
    }
}
```

## Console

If needed you can use the ConsoleBinder to make the user enter data for the model. Bind with:

```
var s3 = ConsoleBinder.Bind<Settings>();
```

## Examples

See test-project for examples.
