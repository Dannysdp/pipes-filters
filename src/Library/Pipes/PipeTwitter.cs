using TwitterUCU;

namespace CompAndDel.Pipes
{
    public class PipeTwitter : IPipe
    {   
        protected IFilter filtro;
        protected IPipe nextPipe;
        public PipeTwitter(IFilter filtro, IPipe nextPipe)
        {
            this.nextPipe = nextPipe;
            this.filtro = filtro;
        }
        public IPipe Next
        {
            get { return this.nextPipe; }
        }
        IPicture image;
        /// <summary>
        /// Recibe una imagen y la sube a twitter.
        /// </summary>
        /// <param name="picture">Imagen a recibir</param>
        /// <returns>La misma imagen</returns>
        public IPicture Send(IPicture picture)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(picture, "./twitter.jpg");

            var twitter = new TwitterImage();
            twitter.PublishToTwitter("Mi nueva imagen","./twitter.jpg");
            picture = this.filtro.Filter(picture);
            return this.nextPipe.Send(picture);
        }

    }
}
