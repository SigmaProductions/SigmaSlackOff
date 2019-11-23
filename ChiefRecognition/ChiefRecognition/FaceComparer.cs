using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChiefRecognition
{
    public class FaceComparer
    {
        float similarityThreshold = 70F;
        public string sourceImage { get; set; }
        public string targetImage { get; set; }

        public async Task<bool> IsSimillarFaceOnSourceImage()
        {
            AmazonRekognitionClient rekognitionClient = new AmazonRekognitionClient("AKIA3GGXKFL7TG4ARQ5F", "iXqBARX00AiblMAAfvOIp6tKdwRrd/bQlvTicUcq",Amazon.RegionEndpoint.EUWest1);

            Image imageSource = new Image();
            using (FileStream fs = new FileStream(sourceImage, FileMode.Open, FileAccess.Read))
            {
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                imageSource.Bytes = new MemoryStream(data);
            }

            Image imageTarget = new Image();
            using (FileStream fs = new FileStream(targetImage, FileMode.Open, FileAccess.Read))
            {
                byte[] data = new byte[fs.Length];
                data = new byte[fs.Length];
                fs.Read(data, 0, (int)fs.Length);
                imageTarget.Bytes = new MemoryStream(data);
            }
            CompareFacesRequest compareFacesRequest = new CompareFacesRequest()
            {
                SourceImage = imageSource,
                TargetImage = imageTarget,
                SimilarityThreshold = similarityThreshold
            };

            CompareFacesResponse compareFacesResponse = await rekognitionClient.CompareFacesAsync(compareFacesRequest);
            foreach (CompareFacesMatch match in compareFacesResponse.FaceMatches)
            {
                ComparedFace face = match.Face;
                BoundingBox position = face.BoundingBox;
                Console.WriteLine("Face at " + position.Left
                      + " " + position.Top
                      + " matches with " + match.Similarity
                      + "% confidence.");
            }

            Console.WriteLine("There was " + compareFacesResponse.UnmatchedFaces.Count + " face(s) that did not match");

            return true;
        }
    }
}
