using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SwedishView : IView 
    {
        public IDictionary<string, string> menuOptions = new Dictionary<string, string>(){
            {"Spela", "s"},
            {"Kort", "k"},
            {"Stanna", "o"},
            {"Avsluta", "a"}
        };
        private string ChoosenOption;
        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hej Black Jack Världen");
            DisplayMenuOptions();
        }

        public void DisplayMenuOptions()
        {
            string menuAsString = "Skriv ";
            foreach(KeyValuePair<string, string> entry in menuOptions)
                {
                    menuAsString += "'" + entry.Value + "' för " + entry.Key + ", ";
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
            if (ChoosenOption == menuOptions["Spela"])
            {
                return true;
            }
            return false;
        }
        
        public bool doesUserWantToHit()
        {
            if (ChoosenOption == menuOptions["Kort"])
            {
                return true;
            }
            return false;
        }

        public bool doesUserWantToStand()
        {
            if (ChoosenOption == menuOptions["Stanna"])
            {
                return true;
            }
            return false;
        }
        public bool doesUserWantToQuit()
        {
            if (ChoosenOption == menuOptions["Avsluta"])
            {
                return true;
            }
            return false;
        }
        public void DisplayCard(model.Card a_card)
        {
            if (a_card.GetColor() == model.Card.Color.Hidden)
            {
                System.Console.WriteLine("Dolt Kort");
            }
            else
            {
                String[] colors = new String[(int)model.Card.Color.Count]
                    { "Hjärter", "Spader", "Ruter", "Klöver" };
                String[] values = new String[(int)model.Card.Value.Count] 
                    { "två", "tre", "fyra", "fem", "sex", "sju", "åtta", "nio", "tio", "knekt", "dam", "kung", "ess" };
                System.Console.WriteLine("{0} {1}", colors[(int)a_card.GetColor()], values[(int)a_card.GetValue()]);
            }
        }
        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Spelare", a_hand, a_score);
        }
        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Croupier", a_hand, a_score);
        }
        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("Slut: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Croupiern Vann!");
            }
            else
            {
                System.Console.WriteLine("Du vann!");
            }
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Har: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Poäng: {0}", a_score);
            System.Console.WriteLine("");
        }
    }
}
