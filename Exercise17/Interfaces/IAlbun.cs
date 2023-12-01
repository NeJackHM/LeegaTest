using System.Collections.Generic;

namespace Example17.Interfaces
{
    public interface IAlbun
    {
        void PrincipalMenuAlbun(List<Albun> albuns, List<Artista> artistas = null);
    }
}
