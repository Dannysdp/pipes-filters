using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;
using TwitterUCU;

namespace CompAndDel.Pipes
{
    public class PipePost : IPipe
    {
        protected IFilter filtro;
        protected IPipe nextPipe;
        protected string path;
        protected string text;
        /// <summary>
        /// La cañería recibe una imagen, la postea en twitter y la envía a la siguiente cañería
        /// </summary>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipePost(IPipe nextPipe,string path, string text)
        {
            this.nextPipe = nextPipe;
            this.path = path;
            this.text = text;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe Next
        {
            get { return this.nextPipe; }
        }
        /// <summary>
        /// Devuelve el path en donde se guarda la picture.
        /// </summary>
        public string Path 
        {
            get { return path; }
        }
        /// <summary>
        /// Devuelve el text para la publicación.
        /// </summary>
        public string Text 
        {
            get { return text; }
        }
        
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(Text, @$"{Path}.png"));
            return this.nextPipe.Send(picture);
        }
    }
}
