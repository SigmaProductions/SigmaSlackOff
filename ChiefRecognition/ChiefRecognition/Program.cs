using System;
using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChiefRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            //var comparer = new FaceComparer();
            //comparer.sourceImage = "girlresized.jpg";
            //comparer.targetImage = "girlsresized.jpg";
            //Task.Run(async () =>
            //{
            //    await comparer.IsSimillarFaceOnSourceImage();
            //}).GetAwaiter().GetResult();

            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44354/homehub")
                .Build();

            Task.Run(async () => { await connection.StartAsync(); }).GetAwaiter().GetResult();
            connection.SendAsync("HideWindows");
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
