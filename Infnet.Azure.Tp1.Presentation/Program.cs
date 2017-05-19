using Infnet.Azure.Tp1.Data;
using Infnet.Azure.Tp1.Domain;
using Infnet.Azure.Tp1.Helpers;
using System;

namespace Infnet.Azure.Tp1.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = string.Empty;
            var csv = FileHelper.Open(out path);

            var contacts = Contact.CreateContacts(csv);

            var tableDao = new ContactTableStorageDAO();
            tableDao.Add(contacts);

            var blobDao = new ContactBlobStorageDAO();
            blobDao.AddBlob(path);

            tableDao.DeleteTable();
            blobDao.DeleteBlob();
            blobDao.DeleteContainer();

            Console.ReadKey();
        }
    }
}
