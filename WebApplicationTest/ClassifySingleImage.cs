using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
namespace BackEnd_proj
{
    internal class Classifing
    {
        public static string[] ClassifySingleImage(MLContext mlContext, ITransformer model)
        {
            // load the fully qualified image file name into ImageData
            // <SnippetLoadImageData>
            var mod = new Model();
            var imageData = new ImageData()
            {
                ImagePath = mod._predictSingleImage
            };
            // </SnippetLoadImageData>

            // <SnippetPredictSingle>
            // Make prediction function (input = ImageData, output = ImagePrediction)
            var predictor = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);

            var prediction = predictor.Predict(imageData);
            // </SnippetPredictSingle>

            Console.WriteLine("=============== Making single image classification ===============");
            // <SnippetDisplayPrediction>
            Console.WriteLine($"Image: {Path.GetFileName(imageData.ImagePath)} predicted as: {prediction.PredictedLabelValue} with score: {prediction.Score.Max()} ");

            // </SnippetDisplayPrediction>
            string[] output = new string[2];
            output[0] = prediction.PredictedLabelValue;
            output[1]= prediction.Score.Max().ToString();

            return output;
        }
    }
}
