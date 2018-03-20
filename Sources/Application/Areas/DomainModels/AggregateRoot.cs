namespace Mmu.Mlh.LanguageExtensions.Areas.DomainModels
{
    public abstract class AggregateRoot : Entity
    {
        protected AggregateRoot(string id) : base(id)
        {
        }

        public string AggregateTypeName => GetType().FullName;
    }
}