namespace JsonStuff;

public sealed class Cat : Animal
{
    public override string Type => nameof(Cat);
    public required string Name { get; set; }
}