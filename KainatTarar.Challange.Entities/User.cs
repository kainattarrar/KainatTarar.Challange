using KainatTarar.Challange.Shared.Base;

namespace KainatTarar.Challange.Entities
{
    public class User : EntityBase, IEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}