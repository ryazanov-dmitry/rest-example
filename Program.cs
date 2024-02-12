using rest_example;

internal class Program
{

    public static List<Cat> Cats = new List<Cat>();

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("cat", () => {
            return Cats;
        });

        app.MapPut("cat/", (Cat newCat) =>
        {
            Cats.Add(newCat);
            return newCat;
        });

        app.MapPost("cat/", (CatUpdate catUpdate) =>
        {
            var foundCat = Cats.FirstOrDefault(x=>x.Id == catUpdate.Id);
            if(foundCat is null) return Results.NotFound();

            foundCat.CatName = catUpdate.CatName;
            return Results.Ok(foundCat);
        });

        app.MapDelete("cat/", (Guid Id) =>
        {
            var foundCat = Cats.FirstOrDefault(x=>x.Id == Id);
            if(foundCat is null) return Results.NotFound();

            Cats.Remove(foundCat);
            return Results.Ok();
        });

        app.Run();
    }
}