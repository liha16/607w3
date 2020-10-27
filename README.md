# blackjack_csharp

Workshop 3, 1dv607
Lisa Veltman

## Stand()

In the assignent, one of the requirements is to implement the operation Game::Stand. I implemented it but later modified it to remove duplicated code. The program is no longer matching the seq. diagram but it fullfills low coupling/high cohesion.


## Observer pattern

The dealer (model.dealer) is the publisher and the controller (IController) is the subscriber.
The view is not the subsriber as I thought I wanted the view to only take care about displaying UI and not when. The pause should be in all games, no mather what kind of view is used (html, console etc)

## Not implemented
As not part of the requirements the game is not automatically finished when a player or dealer gets more than 21 points and looses. 

Also, the game is not finished when a player recieves a maximum of 5 cards even if sum < 21.

##  Low coupling

Before, the INewGameStrategy was iniziated with 3 arguments, the objects Deck a_deck, Dealer a_dealer, Player a_player. Now it is only 2, Dealer a_dealer, Player a_player.