

namespace rest_example;
public class Cat
{
    public string CatName { get; set;}
    public Guid Id { get; }

    public Cat()
    {
        Id = Guid.NewGuid();
    }
}