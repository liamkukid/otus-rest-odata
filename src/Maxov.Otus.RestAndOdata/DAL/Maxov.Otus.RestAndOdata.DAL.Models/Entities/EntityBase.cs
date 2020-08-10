namespace Maxov.Otus.RestAndOdata.DAL.Models.Entities
{
    public abstract class EntityBase<TId>
        where TId : struct
    {
        public TId Id { get; set; }
    }
}