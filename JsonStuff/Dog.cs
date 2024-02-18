namespace JsonStuff;

public sealed class Dog : Animal
{
    public override string Type => nameof(Dog);
    public required string Name { get; set; }
}