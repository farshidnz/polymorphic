// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using JsonStuff;

Console.WriteLine("Hello, World!");


var response = new AnimalResponse
{
    ResourceList = new AnimalList
    {
        Animals = new List<Animal>()
        {
            new Cat() {Name = "Shane"},
            new Cat() {Name = "James"},
            new Dog() {Name = "Farshid"},
        }
    }
};


JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
{
    WriteIndented = true,
    TypeInfoResolver =
        JsonTypeInfoResolver.Combine(
            new AnimalPolymorphicTypeResolver(),
            new DefaultJsonTypeInfoResolver())
};

var json = JsonSerializer.Serialize(response, options);
var animalResponse = JsonSerializer.Deserialize<AnimalResponse>(json, options);
Console.WriteLine("Animal: {0}", JsonSerializer.Serialize(animalResponse, options));