using System.Net;

namespace StudentGroups
{
    public class Student
    {
        public string Name { get; set; }
        public Address ResidentialAddress { get; set; }
        public Address MailingAddress { get; set; }
    }
}