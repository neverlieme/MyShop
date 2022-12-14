namespace EntityPriceComparator;

public static class SeedEntities
{
    static SeedEntities()
    {
        Entities = new List<Entity>
        {
            new()
            {
                EntityId = Guid.Parse("bc5cf3f2-1630-4d67-a1a4-c1923f2e91f6"),
                Name = "Milk"
            },
            new()
            {
                EntityId = Guid.Parse("fba1aaaf-b572-4aa7-9c91-8f592938b14b"),
                Name = "Tea"
            },
            new()
            {
                EntityId = Guid.Parse("03cf9e8a-433e-49f3-ab47-c4ad2841786d"),
                Name = "Chicken"
            },
            new()
            {
                EntityId = Guid.Parse("b31123b5-b7bd-4b82-b4f2-6a126cfbeb28"),
                Name = "Egg"
            },
            new()
            {
                EntityId = Guid.Parse("9626d94c-b086-4b5e-ae6e-316bcdcf7e05"),
                Name = "Cheese"
            },
            new()
            {
                EntityId = Guid.Parse("1948dcc2-10d7-11ed-861d-0242ac120002"),
                Name = "Orange"
            },
            new()
            {
                EntityId = Guid.Parse("27ac07c6-10d7-11ed-861d-0242ac120002"),
                Name = "Meat"
            },
            new()
            {
                EntityId = Guid.Parse("3dcee794-10d7-11ed-861d-0242ac120002"),
                Name = "Snack"
            },
        };
    }

    private static List<Entity> Entities { get; }

    public static List<Entity> GetRandomList(DateTime fetchDatetime)
    {
        Random rnd1 = new();

        var prices = new double[] { 100, 150, 200, 250, 300, 350, 400, 450, 500, 550 };
        var entities = Entities.OrderBy(_ => rnd1.Next()).Take(4).ToList();
        entities.ForEach(e =>
        {
            e.Price = prices[rnd1.Next(0, prices.Length)];
            e.FetchDate = fetchDatetime;
        });
        return entities;
    }

}