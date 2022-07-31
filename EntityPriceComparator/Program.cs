using EntityPriceComparator;

EntityComparatorService comparator = new();
var todayEntities = SeedEntities.GetRandomList(DateTime.Now);
var yesterdayEntities = SeedEntities.GetRandomList(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1)); ;

Console.WriteLine("Yesterday list\n---------------------------");
yesterdayEntities.OrderBy(e => e.EntityId).ToList().ForEach(e => Console.WriteLine(e.ToString()));
Console.WriteLine("---------------------------\n");

Console.WriteLine("Today list\n---------------------------");
todayEntities.OrderBy(e=>e.EntityId).ToList().ForEach(e=>Console.WriteLine(e.ToString()));
Console.WriteLine("---------------------------\n");

comparator.AddTodayEntities(todayEntities);
comparator.AddYesterdayEntities(yesterdayEntities);
comparator.Operation();

Console.WriteLine("Added list\n---------------------------");
comparator.AddedEntities.OrderBy(e => e.EntityId).ToList().ForEach(e => Console.WriteLine(e.ToString()));
Console.WriteLine("---------------------------\n");

Console.WriteLine("Removed list\n---------------------------");
comparator.RemovedEntities.OrderBy(e => e.EntityId).ToList().ForEach(e => Console.WriteLine(e.ToString()));
Console.WriteLine("---------------------------\n");

Console.WriteLine("Changed list\n---------------------------");
comparator.ChangedPriceEntities.OrderBy(e => e.EntityId).ToList().ForEach(e => Console.WriteLine(e.ToString()));
Console.WriteLine("---------------------------\n");

Console.ReadKey();