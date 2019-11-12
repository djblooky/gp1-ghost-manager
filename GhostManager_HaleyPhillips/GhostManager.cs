using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostManager_HaleyPhillips
{
    public interface IGhostManager
    {
        List<Ghost> Ghosts { get; set; }
        Ghost ghost();
        Ghost ghost(Ghost g);
        string GhostTexture { get; set; }
    }

    public class GhostManager : GameComponent, IGhostManager
    {
        public List<Ghost> Ghosts { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string GhostTexture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Ghost ghost()
        {
            throw new NotImplementedException();
        }

        public Ghost ghost(Ghost g)
        {
            throw new NotImplementedException();
        }
    }
}
