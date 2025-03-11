using ErrorOr;
using L2Art.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.Users
{
    public class User : Entity
    {
        public PersonalData PersonalData { get; private set; }

        private User()
        {
        }

        private User(Guid id, PersonalData personalData) : base(id)
        {
            Id = id;
            PersonalData = personalData;
        }

        public static ErrorOr<User> Create(PersonalData personalData)
        {
            var user = new User(Guid.NewGuid(), personalData);
            
            return user;
        }
    }
}
