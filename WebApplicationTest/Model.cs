using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using PocketCsvReader;
using Microsoft.Data.Analysis;


namespace BackEnd_proj
{

    public class Model
    {
        private static ITransformer ? model;
        public string _assetsPath;
        public string _imagesFolder;
        public string _trainTagsTsv;
        public string _testTagsTsv;
        public string _predictSingleImage;

        public string _inceptionTensorFlowModel;
       public Model()
        {
            _assetsPath = Path.Combine(Environment.CurrentDirectory, "assets");
            _imagesFolder = "ImageData";
            _trainTagsTsv =  "TrainData.tsv";
            _testTagsTsv = "TestData.tsv";
            _predictSingleImage = "Validation.jpg";
            _inceptionTensorFlowModel = Path.Combine(_assetsPath, "inception", "tensorflow_inception_graph.pb");


        }
        public static string[] ModelFit()

        {
            DataViewSchema modelSchema;

            var mod = new Model();
           //string data = Load_data.Load();  // train data tsv
            //test_tsv.Load();  // Test data TSV


            // Create MLContext to be shared across the model creation workflow objects
            // <SnippetCreateMLContext>
            MLContext mlContext = new MLContext();
            // IDataView trainingDataView = mlContext.Data.LoadFromEnumerable(data);


            if (File.Exists("model.zip") != true)

            {
                Console.WriteLine(Environment.CurrentDirectory);
                model = ModelGen.GenerateModel(mlContext);
                var dataView = mlContext.Data.LoadFromTextFile("Data.tsv");

                mlContext.Model.Save(model, dataView.Schema, "model.zip");
            }
            else
            {

                // Load trained model
                Console.WriteLine(Environment.CurrentDirectory);
                model = mlContext.Model.Load("model.zip", out modelSchema);

            }
            // </SnippetCallGenerateModel>
            // model.Save("mymodel.h5");
            // <SnippetCallClassifySingleImage>
           string[] output = Classifing.ClassifySingleImage(mlContext, model);
            // </SnippetCallClassifySingleImage>

            return output;





        }

        public struct InceptionSettings
        {
            public const int ImageHeight = 224;
            public const int ImageWidth = 224;
            public const float Mean = 117;
            public const float Scale = 1;
            public const bool ChannelsLast = true;
        }


    }
}
