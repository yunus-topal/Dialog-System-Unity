-> conversation_with_npc

=== conversation_with_npc ===
Salih: "Hello, traveler! What brings you to our village?"
*   [I'm looking for adventure.]
    -> adventure_response
*   [Just passing through.]
    -> passing_through_response
*   [None of your business.]
    -> rude_response

=== adventure_response ===
Salih: "You've come to the right place! There's always something exciting happening around here."
*   [Tell me more.]
    -> tell_more
*   [I'll find out on my own.]
    -> end

=== tell_more ===
Salih: "Well, there have been reports of strange creatures in the forest nearby. It might be worth checking out."
*    [Thanks. Farewell]
    -> end

=== passing_through_response ===
Salih: "I see. Well, safe travels then!"
* [basa don]
-> conversation_with_npc
* [asds]
-> end

=== rude_response ===
Salih: "Well, there's no need to be rude! Be on your way then."
-> end

=== end ===
Salih: "Goodbye, traveler."

->END
