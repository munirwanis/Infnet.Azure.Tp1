using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace Infnet.Azure.Tp1.Data
{
    public class ContactBlobStorageDAO
    {
        private string ContainerReference { get; } = "munirwanis";
        private CloudStorageAccount StorageConnectionString { get; } = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));

        public void AddBlob(string path)
        {
            Console.WriteLine("Loading blob to Storage");
            CloudStorageAccount storageAccount = this.StorageConnectionString;

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(this.ContainerReference);

            container.CreateIfNotExists();

            var pathSplit = path.Split('\\');

            var nomeDoArquivo = pathSplit[pathSplit.Length - 1];

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(nomeDoArquivo);

            using (var fileStream = System.IO.File.OpenRead(path))
            {
                blockBlob.UploadFromStream(fileStream);
            }
            Console.WriteLine("Successfuly loaded file on Storage");
        }

        public void DeleteBlob()
        {
            Console.WriteLine("Which file do you want to delete?");
            string nomeDoArquivo = Console.ReadLine();

            CloudStorageAccount storageAccount = this.StorageConnectionString;

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(this.ContainerReference);


            CloudBlockBlob blockBlob = container.GetBlockBlobReference(nomeDoArquivo);
            if (blockBlob != null)
            {
                blockBlob.DeleteIfExists();
                Console.WriteLine("Successfuly deleted file from Storage");

            }
            else
            {
                Console.WriteLine("File not found");
            }

        }

        public void DeleteContainer()
        {
            Console.WriteLine("Deleting container from Storage");

            CloudStorageAccount storageAccount = this.StorageConnectionString;

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(this.ContainerReference);

            container.DeleteIfExists();
            Console.WriteLine("Successfuly deleted Container from Storage");


        }
    }
}
