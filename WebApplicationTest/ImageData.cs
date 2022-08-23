using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd_proj;
using Microsoft.ML;
using Microsoft.ML.Data;
namespace BackEnd_proj
{
    public class ImageData
    {

        [LoadColumn(0)]
        public string ? ImagePath;

        [LoadColumn(1)]
        public string ? Label;

    }
}
