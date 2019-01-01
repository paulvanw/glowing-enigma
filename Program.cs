
namespace wingmen.io
{
    using System;
    using Docker.DotNet;

    public class Program
    {
       public static void Main(string[] args)
        {
            AnonymousCredentials creds = new AnonymousCredentials();

            DockerClient client = new DockerClientConfiguration(new Uri("http://127.0.0.1:3128")).CreateClient();

            var containers = client.Containers.ListContainersAsync
            (
                new Docker.DotNet.Models.ContainersListParameters() 
                { 
                   All = true
                }
            ).Result;

            foreach (var item in containers)
            {
                Console.WriteLine($"Id: {item.ID}");
                Console.WriteLine($"Status: {item.Status}");
            }
        }
    }
}