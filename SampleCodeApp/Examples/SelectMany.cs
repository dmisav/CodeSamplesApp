namespace SampleCodeApp.Examples;

public static class SelectMany
{
    private static PetOwner[] petOwners =
    {
        new PetOwner
        {
            Name = "Higa",
            Pets = new List<string> { "Scruffy", "Sam" }
        },
        new PetOwner
        {
            Name = "Ashkenazi",
            Pets = new List<string> { "Walker", "Sugar" }
        },
        new PetOwner
        {
            Name = "Price",
            Pets = new List<string> { "Scratches", "Diesel" }
        },
        new PetOwner
        {
            Name = "Hines",
            Pets = new List<string> { "Dusty" }
        }
    };
    
    public static void Run()
    {
        var query =
            petOwners
                .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
                //.ToDictionary(p => p.Name, p => p.Pets);
        .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
        .Select(ownerAndPet =>
            new
            {
                Owner = ownerAndPet.petOwner.Name,
                Pet = ownerAndPet.petName
            }
        );
        
        foreach (var obj in query)
        {
            Console.WriteLine(obj);
        }
    }
}

internal class PetOwner
{
    public string Name;
    public List<string> Pets;
}