using System;
using static Onecm.Users.UserEnums;

namespace Onecm.Users
{
    /// <summary>
    /// An entity that represents a client/party/user.
    /// It could be a person or a company or a restaurant.
    /// </summary>
    public record User
    {
        public User(Guid id, UserType type, string firstName, string lastName, string companyName, string companyRegistrationNumber)
        {
            Id = id;
            Type = type;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            CompanyRegistrationNumber = companyRegistrationNumber;
        }

        public Guid Id { get; }

        public UserType Type { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string CompanyName { get; }

        public string CompanyRegistrationNumber { get; }
    }
}