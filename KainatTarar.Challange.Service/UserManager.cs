using KainatTarar.Challange.Data.UOW;
using KainatTarar.Challange.Entities;
using KainatTarar.Challange.Model.Dtos;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace KainatTarar.Challange.Service
{
    public class UserManager
    {
        private readonly IUnitOfWork unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public UserManager()
        {
            this.unitOfWork = new UnitOfWork();
        }

        public LoginResult LoginControl(string username, string password)
        {

            return unitOfWork.Users.Get(u => u.Username == username && u.Password == password && !u.IsDeleted).Select(ToResult).First();
        }

        public string GetGreeting(string name)
        {
            if (DateTime.Now.Hour > 0 && DateTime.Now.Hour < 12)
                return "Günaydın " + name + "!";

            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 18)
                return "İyi Günler " + name + "!";

            else if (DateTime.Now.Hour > 18 && DateTime.Now.Hour < 21)
                return "İyi Akşamlar " + name + "!";

            else
                return "İyi Geceler " + name + "!";
        }

        private Expression<Func<User, LoginResult>> ToResult => user =>
        new LoginResult()
        {
            Id = user.Id,
            Username = user.Username
        };
    }
}