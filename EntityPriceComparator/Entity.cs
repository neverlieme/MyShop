namespace EntityPriceComparator;

public class Entity
{
    public Guid EntityId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public DateTime FetchDate { get; set; }
    public override string ToString() => $"{Name} \t\t\t {Price}";


}