using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Microsoft.AspNet.SignalR.Infrastructure;
using Microsoft.AspNetCore.SignalR.Client;
using OpenCvSharp;

namespace ChiefRecognition
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                       .WithUrl("http://07b9f0d5.ngrok.io/homehub")
                       .Build();

            Task.Run(async () => { await connection.StartAsync(); }).GetAwaiter().GetResult();

            while (true)
            {
                VideoCapture capture = new VideoCapture(0); //assumption based on how actual openCV works.
                var screen = capture.RetrieveMat();
                screen.SaveImage("myimage.jpg");
                var comparer = new FaceComparer();
                comparer.sourceImage = "xxx.jpg";
                comparer.targetImage = "myimage.jpg";
                Task.Run(async () =>
                {
                    await comparer.IsSimillarFaceOnSourceImage(connection);

                }).GetAwaiter().GetResult();
                Thread.Sleep(5000);
                Console.WriteLine("Hello World!");
            }
        }
    }
}
