# GDIM33 Vertical Slice
## Milestone 1 Devlog
The visual scripting graph that I'll talk about will be the Playing script state in the gameStateGraph state machine. The graph is a game state that activates when the game is...well, playing, and it sets the dialogue UI, NPC, and friendship bar (which are all scene variables) active. The dialogue UI sets the dialogue to the NPC's current line of its current node (which it gets from the NPC scene variable), which is set in the transitions between states. It also turns both the pause and start screen off during play mode so that those screens don't interfere with the gameplay.

<img width="1085" height="914" alt="jess tran (gdim 33) - vertical slice breakdown(1)" src="https://github.com/user-attachments/assets/e6dd9ab7-a07e-4535-b0d7-a87ba2b6f7a9" />
I mainly edited my GameController with more details to better represent the implemented state machine. The state machine currently switches from 3 states: a start state, a play state, and a pause state. The start state displays a start screen with only one button (as of now) to start the game, the play state contains all the gameplay for the game, and the pause screen simply lets the player pause the game and either resume gameplay or return back to the start screen.

The state machine controls what UI is available on-screen as well as what player input is allowed to be registered. On both the start and pause screen, the player is not allowed to click through dialogue. In addition to that, transitioning from the start state to the play state will reset all player values, allowing the player to basically restart the game. The pause button basically just turns off the dialogue UI as to create a "paused" state where the player cannot progress while the game is paused.
## Milestone 2 Devlog
### Complicating Gameplay Feature
My complicating gameplay feature is to have the persuasion bar increase or decrease depending on the amount of times a player has made a certain type of choice + if an increase/decrease makes sense in the context of the situation. For example, the player might be able to make up to 3 nice choices to increase persuasion before another nice choice will instead decrease persuasion.
#### 1. Breakdown
- Assign choice types to dialogue choices.
    - Each dialogue choice can have an enum to identify the type of choice it is.
        - Currently there should be nice, mean, and neutral choices. Choice types outside of these are not available in this vertical slice.
- Make a counter for how much of each type of choice has been made in a row.
    - When the player selects an option, check what type of choice it is.
        - If the choice is the same type of choice as the previous choice made, add to a counter that keeps track of how many of the same type of choice has been made since the most recently made choice with the same type.
        - If the choice type is different from the choice type of the previous choice, reset the counter.
        - If this is the first choice that has been made, don't add to the counter yet.
    - The choice should then be stored as a variable to compare with the next player choice.
- Increase or decrease the persuasion score based on how many of the same type of choices have been made in a row and according to the previous dialogue sequence.
    - Each dialogue sequence should have a set number to compare to the number of "same choice type" choices made. This creates a way for the NPC to react according to the dialogue context without having to analyze the dialogue lines themselves through code.
    - Compare the number assigned to the dialogue sequence and the number of "same choice type" choices.
        - The persuasion bar should increase if the number of "same choice type" choices is less than or equal to the number assigned to the dialogue sequence.
        - Else, the persuasion bar should decrease.
#### 2. Breakdown Reflection
I think that the breakdown was ultimately helpful to help guide me through exactly what steps I needed to do, though I feel like I did end up deviating from my original plans (mainly because I discovered how to REALLY use ScriptableObjects...oops....). I think for future breakdowns I'd want to have a clearer idea of what I want to do and how to execute it.
#### 3. Visual Scripting Graph
Right now, my only visual scripting graph is still my state machine (though that will probably change once I add the visual effects... maybe). It's kind of a spiderwebbed mess, but I basically have a bunch of nodes calling methods and accessing variables from C# and grab a bunch of things from the same variable (check out the NPC node... eugh....). I mainly wanted to create this as a visual scripting graph over pure C# scripts so that I could easily visualize how the states operate (kind of looking at it from a designer perspective?? I guess). The C# scripts involved in this spaghetti mess are mainly the NPC script and the DialogueUI script.
#### 4. Unity System 
The Unity system I'd like to be graded is my ScriptableObjects system.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- [Unity Dialogue System w/ ScriptableObjects - 2019 Update](https://youtu.be/YJLcanHcJxo) - Showed me what structs were and blew my mind...