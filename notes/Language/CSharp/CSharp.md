
### Structs 
- unlike classes it's direct value, hence the storage will be handled within the stack instead of the traditional Heap for objects
```csharp
public struct user {
	public string Name {get; set;}
	public int Age {get; set;}
}
```

### Enums
- Special class of group of constants ( unchangeable/read-only )
```csharp
enum Level 
{
  Low,
  Medium,
  High
}
  // general usecase
  Level myVar = Level.Medium;
  switch(myVar) 
  {
    case Level.Low:
      Console.WriteLine("Low level");
      break;
    case Level.Medium:
       Console.WriteLine("Medium level");
      break;
    case Level.High:
      Console.WriteLine("High level");
      break;
  }
```

### Records
- Value type ( But classes are Reference )
- Portable
- Immutable and treated as value


### Abstract Class
- Can't be instantiated


### Deligate
- unicast & multi cast deligate
- The lambdas

### Extension methods
Extension methods that are not part of that class, but can be used like that
```csharp
string message = "value";
message.Reverse(); // uses message as it's first parameter
											   |	
public static class String Methods{            v 
	public static string Reverse(this string msg){
		var charArray = msg.ToChararray();
		Array.Reverse(chars);
		return new string(chars);
	}
}
```