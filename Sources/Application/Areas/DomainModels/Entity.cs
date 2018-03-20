using Mmu.Mlh.LanguageExtensions.Areas.DomainModels.Abstractions;

namespace Mmu.Mlh.LanguageExtensions.Areas.DomainModels
{
    public abstract class Entity : ComparableIdentityProvider, IIdentityProvider
    {
        protected Entity(string id) => Id = id;

        public string Id { get; private set; }
        protected override string ComparedId => Id;
    }
}