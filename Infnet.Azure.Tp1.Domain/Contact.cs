using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;

namespace Infnet.Azure.Tp1.Domain
{
    public class Contact : TableEntity
    {
        public Contact(string firstName, string lastName, string phone, string email)
        {
            this.PartitionKey = lastName;
            this.RowKey = phone;
            this.Name = firstName;
            this.Email = email;
        }
        public string Name { get; set; }
        public string Email { get; set; }

        public static List<Contact> CreateContacts(string[] csvArray)
        {
            var contacts = new List<Contact>();

            foreach (var c in csvArray)
            {
                var data = c.Split(',');
                var contact = new Contact(data[0], data[1], data[2], data[3]);

                contacts.Add(contact);
            }
            return contacts;
        }
    }
}
