using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SimpleView : IView
    {
        public IDictionary<string, string> menuOptions = new Dictionary<string, string>(){
            {"Play", "p"},
            {"Hit", "h"},
            {"Stand", "s"},
            {"Quit", "q"}
        };
        private string ChoosenOption;

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            DisplayMenuOptions();
        }

        public void DisplayMenuOptions()
        {
            string menuAsString = "Type ";
            foreach(KeyValuePair<string, string> entry in menuOptions)
                {
                    menuAsString += "'" + entry.Value + "' to " + entry.Key + ", ";
                }
            menuAsString = menuAsString.Remove(menuAsString.Length - 2);
            menuAsString += "\n";
            System.Console.WriteLine(menuAsString);
        }

        public void SetInputOption()
        {
            ChoosenOption = System.Console.In.ReadLine();   
        }

        public bool doesUserWantToPlay()
        {
            if (ChoosenOption == menuOptions["Play"])
            {
                return true;
            }
            return false;
        }
        
        public bool doesUserWantToHit()
        {
            if (ChoosenOption == menuOptions["Hit"])
            {
                return true;
            }
            return false;
        }

        public bool doesUserWantToStand()
        {
            if (ChoosenOption == menuOptions["Stand"])
            {
                return true;
            }
            return false;
        }
        public bool doesUserWantToQuit()
        {
            if (ChoosenOption == menuOptions["Quit"])
            {
                return true;
            }
            return false;
        }
        

        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
            
        }
    }
}
