using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Pholymorphic;

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
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    NumberHandling = JsonNumberHandling.AllowReadingFromString,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true,
    WriteIndented = false,
    TypeInfoResolver =
    JsonTypeInfoResolver.Combine(
        new AnimalPolymorphicTypeResolver(),
        new DefaultJsonTypeInfoResolver())
};

var json = JsonSerializer.Serialize(response, options);
var animalResponse = JsonSerializer.Deserialize<AnimalResponse>(json, options);
Console.WriteLine("Animal: {0}", JsonSerializer.Serialize(animalResponse, options));

// [JsonDerivedType(typeof(Dog))]
// [JsonDerivedType(typeof(Cat))]