using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Lisa

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            model.Game g = new model.Game();
            view.IView v = new view.SwedishView();
            //controller.PlayGame ctrl = new controller.PlayGame();
            controller.IController ctrl = new controller.PlayGame();
            
            ctrl.StartGame(g, v);
            while (ctrl.Play());
        }
    }
}
