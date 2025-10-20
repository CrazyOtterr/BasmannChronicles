Scene Transition System for Unity
=================================

This package contains scripts to handle scene transitions in your Unity game:

1. SceneTransitionTrigger.cs
   - Attach to a GameObject with a Collider2D component set to "Is Trigger"
   - Automatically transitions to another scene when the player enters the trigger
   - Can also show a button for manual transition

2. SceneTransitionButton.cs
   - Attach to a UI Button to transition to another scene when clicked

3. GameManager.cs
   - Singleton pattern for managing scene transitions
   - Provides methods to load scenes, restart scenes, and quit the game

4. UIManager.cs
   - Manages UI elements like transition buttons

How to Set Up Scene Transitions:
-------------------------------

Method 1: Automatic Transition (Trigger Zone)
1. Create a GameObject (e.g., empty GameObject) in your scene
2. Add a Collider2D component (BoxCollider2D, CircleCollider2D, etc.)
3. Check the "Is Trigger" box in the collider component
4. Attach the SceneTransitionTrigger.cs script to the GameObject
5. In the script's Inspector, set the "Target Scene Name" to the scene you want to transition to
6. Make sure the player object is tagged as "Player" or on the "IsPlayer" layer

Method 2: Manual Transition (UI Button)
1. Create a UI Button (GameObject > UI > Button)
2. Attach the SceneTransitionButton.cs script to the Button
3. In the script's Inspector, set the "Target Scene Name" to the scene you want to transition to

Method 3: Manual Transition (Trigger + Button)
1. Follow steps 1-5 from Method 1
2. In the SceneTransitionTrigger component, uncheck "Transition On Enter"
3. Check "Show Transition Button"
4. The button will appear when the player enters the trigger zone

Important Notes:
---------------
- Make sure all scene names used in the scripts match the actual scene file names
- Add scenes to the Build Settings (File > Build Settings) to be able to transition to them
- The player object should be tagged as "Player" or placed on the "IsPlayer" layer for trigger detection to work