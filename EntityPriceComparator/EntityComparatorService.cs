namespace EntityPriceComparator
{
    internal class EntityComparatorService
    {
        private readonly List<Entity> _todayEntities = new();
        private readonly List<Entity> _yesterdayEntities = new();

        public readonly List<Entity> ChangedPriceEntities = new();
        public readonly List<Entity> RemovedEntities = new();
        public readonly List<Entity> AddedEntities = new();
        public void AddTodayEntities(IEnumerable<Entity> entities) => _todayEntities.AddRange(entities);
        public void AddYesterdayEntities(IEnumerable<Entity> entities) => _yesterdayEntities.AddRange(entities);
        public void Operation()
        {
            var items = _todayEntities.Concat(_yesterdayEntities).OrderBy(e => e.EntityId).ThenBy(e => e.FetchDate).ToList();
            Clear();
            for (var i = 0; i < items.Count; i++)
            {
                var next = i + 1;
                var yesterdayItem = items[i];
                var todayItem = next > items.Count - 1 ? null : items[next];
                var entityState = GetEntityState(todayItem, yesterdayItem);
                switch (entityState)
                {
                    case EntityState.PriceChanged:
                        i++;
                        ChangedPriceEntities.Add(todayItem);
                        ChangedPriceEntities.Add(yesterdayItem);
                        break;
                    case EntityState.Added:
                        AddedEntities.Add(yesterdayItem);
                        break;
                    case EntityState.Removed:
                        RemovedEntities.Add(yesterdayItem);
                        break;
                    case EntityState.PriceUnchanged:
                        i++;
                        break;
                    default:
                        RemovedEntities.Add(yesterdayItem);
                        break;
                }
            }
        }

        private void Clear()
        {
            ChangedPriceEntities.Clear();
            RemovedEntities.Clear();
            AddedEntities.Clear();
        }

        private static EntityState GetEntityState(Entity? todayEntity, Entity yesterdayEntity)
        {
            if (todayEntity == null || todayEntity.EntityId != yesterdayEntity.EntityId)
                return yesterdayEntity.FetchDate.Day == DateTime.Now.Day ? EntityState.Added : EntityState.Removed;

            return Math.Abs(todayEntity.Price - yesterdayEntity.Price) > 0 ?
                EntityState.PriceChanged : EntityState.PriceUnchanged;
        }
    }
}
