using System.ComponentModel.DataAnnotations.Schema;
using InSys.Repository.Pattern.Infrastructure;

namespace InSys.Repository.Pattern.Ef6
{
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
}