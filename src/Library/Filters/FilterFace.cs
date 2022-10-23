using System;
using System.Drawing;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterFace
    {
        public bool Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            CognitiveFace cog = new CognitiveFace(false);
            provider.SavePicture(image, "/tmp/faceRecognition.jpg");
            cog.Recognize("/tmp/faceRecognition.jpg");

            return cog.FaceFound;
        }
    }
}
