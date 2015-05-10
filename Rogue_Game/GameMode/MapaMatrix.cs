using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Rogue_Game.GameMode
{
    public class MapaMatrix
    {
        private static MapaMatrix instance;

        private MapaMatrix()
        {

        }

        public static MapaMatrix Instance
   {
      get 
      {
         if (instance == null)
         {
             instance = new MapaMatrix();
         }
         return instance;
      }
   }
        public Block[,] mapa = new Block[9, 9];
        public void draw (Graphics g,Point p)
        {
            for (int i = 0; i < 9;i++ )
            for(int y =0; y< 9 ;y++){
               if(mapa[i,y]!=null) mapa[i,y].draw(g,i,y);
            }
        }
        public void fill(Block[,] Mapa)
        {

            mapa = Mapa;

        }
        public void clean()
        {
            for (int i = 0; i < 9; i++)
                for (int y = 0; y < 9; y++)
                {
                   mapa[i, y] = null;
                }
        }


    }
}
