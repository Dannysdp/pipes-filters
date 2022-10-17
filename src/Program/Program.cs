using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("./luke.jpg");

            PipeNull nullPipe = new PipeNull();
            
            PipeSerial negativePipe = new PipeSerial(new FilterNegative(), nullPipe);
            
            PipeSerial greyScale = new PipeSerial(new FilterGreyscale(), negativePipe);
            
            picture = greyScale.Send(picture);
            
            provider.SavePicture(picture, "./luke.jpg");
        }
    }
}
