using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;

namespace CompAndDel.Pipes
{
    public class PipeDownload : IPipe
    {
        protected string path;
        protected IPipe nextPipe;
        
        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="path">Path a donde se decarga la imagen.</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeDownload(string path, IPipe nextPipe)
        {
            this.nextPipe = nextPipe;
            this.path = path;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe Next
        {
            get { return this.nextPipe; }
        }
        /// <summary>
        /// Devuelve el el path en donde se guarda la picture.
        /// </summary>
        public string Path
        {
            get { return this.path; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture picture)
        {
            new PictureProvider().SavePicture(picture, path);
            return this.nextPipe.Send(picture);
        }
    }
}
