using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        List<Ghost> ghosts; 
        public List<Ghost> Ghosts { get; set; }
        List<Ghost> ghostsToRemove { get; set; }  //remove these ghosts when disabled
        public string GhostTexture { get; set; }

        protected Ghost g = null; //default ghost

        public GhostManager(Game game) : base(game)
        {
            g = new Ghost(game);
            ghosts = new List<Ghost>();
            ghostsToRemove = new List<Ghost>();
        }

        public Ghost ghost()
        {
           
        }

        public Ghost ghost(Ghost g)
        {
            
        }

        protected virtual void addGhost(Ghost g)
        {
            ghosts.Add(g);
        }

        protected virtual void removeGhost(Ghost g)
        {
            ghosts.Remove(g);
        }

        public override void Update(GameTime gameTime)
        {
            ghostsToRemove.Clear(); //clear old ghosts to be removed

            foreach (Ghost g in Ghosts)
            {
                if (g.Enabled)
                {
                    g.Update(gameTime); //Only update enabled ghosts
                }
                else //If the ghost is not enabled 
                {
                    ghostsToRemove.Add(g);
                }
            }

            //Remove ghosts that are not enalbled anymore
            foreach (Ghost s in ghostsToRemove)
            {
                this.removeGhost(s);
            }
            base.Update(gameTime);
        }


        public void Draw(SpriteBatch sb)
        {
            foreach (var g in Ghosts) //draw each ghost
            {
                 g.Draw(sb);
            }
        }
    }
}
