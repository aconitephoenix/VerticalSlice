# GDIM33 Vertical Slice
## Milestone 1 Devlog
The visual scripting graph that I'll talk about will be the Playing script state in the gameStateGraph state machine. The graph is a game state that activates when the game is...well, playing, and it sets the dialogue UI, NPC, and friendship bar (which are all scene variables) active. The dialogue UI sets the dialogue to the NPC's current line of its current node (which it gets from the NPC scene variable), which is set in the transitions between states. It also turns both the pause and start screen off during play mode so that those screens don't interfere with the gameplay.

<img width="1085" height="914" alt="jess tran (gdim 33) - vertical slice breakdown(1)" src="https://github.com/user-attachments/assets/e6dd9ab7-a07e-4535-b0d7-a87ba2b6f7a9" />
I mainly edited my GameController with more details to better represent the implemented state machine. The state machine currently switches from 3 states: a start state, a play state, and a pause state. The start state displays a start screen with only one button (as of now) to start the game, the play state contains all the gameplay for the game, and the pause screen simply lets the player pause the game and either resume gameplay or return back to the start screen.

The state machine controls what UI is available on-screen as well as what player input is allowed to be registered. On both the start and pause screen, the player is not allowed to click through dialogue. In addition to that, transitioning from the start state to the play state will reset all player values, allowing the player to basically restart the game. The pause button basically just turns off the dialogue UI as to create a "paused" state where the player cannot progress while the game is paused.

## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
