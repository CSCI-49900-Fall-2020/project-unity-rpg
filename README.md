# project-unity-rpg-project-proposal
project-unity-rpg created by GitHub Classroom

## Project Proposal:

__**Title:**__ Unity RPG

## Group Members:
James Zhao
Hubert Ye
Paolo Tejeda
Phillip Chen

## Introduction
Our project is to create a 2-D Side Scroller RPG game in Unity using C#. Each person will be responsible for every part of the project including some sprites, enemy ai, bosses ai, and a bit of storyline, etc. Using the already existing template in Unity, we will make modifications and add in original designs. We will start with a generic “Hero on a quest to defeat the Big Bad Evil Guy (BBEG)” story and add twists and more complex backstories for each playable character as time goes on.

## Features
1. Bullet hell mechanics - The players need to dodge enemy projectiles or else they take damage.
	* Create an object script so that when an object collides/touches a wall or entity, it destroys itself and removes itself from the screen. 
	* If a “bullet” touches a entity, it deals the corresponding “damage” depending on the origin of the “bullet” 
2. HP system for player characters so they have incentive to dodge enemy projectiles and MP system to let players use special skills.
	* Every playable player character will have variables that will denote what the character can do and make each one play differently. So a character with high HP and low MP will be inclined to play differently than a character with low HP but a lot of MP
3. Rebindable keys so players can customize their own unique key bindings to what they feel comfortable with
4. Save system and checkpoints, so that players can respawn when they die and not have to start over from the beginning.
	* Stores the state of all the player characters and their current location in a variable that when the player dies, they can choose to restart from the beginning or from that save point.
5. A character swapping feature - Because the player can only control 1 character at a time and the player’s characters are working in a party, players will be able to swap between them (by pressing the shift key, the game will pause to let the player change to a different character) to change between how they battle.(each unique character will have a unique ultimate skill bound to the I key)
	* Each playable character will be stored in a map.
	* We create a class which contains the template for each player character that will be stored in the map for reference. So that it is expandable in the future for when there are more player characters developed. 
	* The current player character will be stored/update the one in the map in 5a, and then replace the variables with new character’s variables from the map in 5a.
6. A skill tree/point system (map implementation) where players can learn more skills. But only able to equip 4 at a time to the J, K, I, L keys. (movement through W,A,S,D) at the start of a stage.
	* All possible skills will be stored in a map. This will reduce redundancy for when some player characters have the same skill.
	* Each playable character will have a map of skills from the map that are learnable. And when a player learns one, a bool will update saying that it is learned or not learned.
	* Each player character will have a vector of skills that are chosen from the ones in 6b before a stage starts and the vector will be in 5b.
7. Create a database of items (map implementation) in the game players can equip their characters with, that they can pick up along the way. 
	* Create a map of all the possible items that a player character can pick up and have different abilities or effects upon being picked up,
	* Create a variable on player characters that when an item is picked up, the variable updates to having that item by using the id of the item.
	* Possibly delete obtained items upon exiting a stage by returning the variable to null.

## Bonus Features:
1. Local/Online co-op, allowing for a friend/s to play with you
2. A template map for enemies so we can randomly generate a stage so it’s different every time.
3. Replace all placeholder art with good pixel art so that it looks nice and add sound files so it sounds nice too.
4. Replace dialogue with an actual story.

## Test Plan (1 paragraph)

Our plan to test our game will be to make sure all the features work. Our beta testing will include putting in dev cheats to jump to certain stages and parts of the levels to test stages and boss mechanics. We will also allow our friends and family to playtest the game, so we get more opinions about its playability. We will then ask questions according to whether they enjoyed playing the game, what they would want the game to include, whether they encountered any bugs, etc. Then, according to their feedback, we will improve the game mechanics and we will repeat this process until the game is completed. Afterwards, we will go through a few more tests for debugging the game until we officially publish the game. 

## How to Test
1. git clone this repository
2. Open Unity Hub
3. Choose to Add a Project
4. Open the cloned repository

### Deployment
Link: [Here](https://play.unity.com/mg/2d/project-unity-rpg-by-hubert-ye-james-zhao-paolo-tejeda-and-phillip-chen)


# CSCI 499 Capstone Final Report

Hubert Ye, James Zhao, Paolo Tejeda, Phillip Chen

December 15, 2020

# Abstract

Our project is to create a role playing game within the Unity2D game engine using the given 2-D platformer assets and the free Unity store assets. The game will contain multiple features including the ability to switch between 4 different characters, defeat enemies using melee attacks and shooting bullets, etc. Our end goal for this project is to create a game that works properly and shows off our experience gained with working in a new programming language.

# Introduction

With games growing in popularity amongst all age groups, we wanted to learn how to create a game using Unity 2D, which is also growing in popularity. In addition, we also plan to use the 2D Platformer template and Unity Store Assets to have a good starting point. We hoped that using these, we could create a working game within the three month time frame. With four people, we would divide the game mechanics between us and be able to code a working alpha version by the end. Within the time frame, we had hoped to create the following features: bullet mechanics, health system for players, rebindable keys, character swapping, items, and an item inventory. However, after learning more about Unity, we realized that we had to figure out how to make different scripts interact with each other and how to do so correctly so that we do not encounter any errors during compile time and runtime. The features we needed to implement must allow transition between scenes, health and mana bars for a visual representation of health and mana, a user interface so that players can see the inventory, include dialogue boxes to teach players how to use the features,  a title screen to start the game, a pause menu to let players have the time to change their keybinds, tooltips to let the player understand what each item does, a camera that follows the player, enemy recoil, melee attacks for additional types of damage besides shooting, and player/enemy aggro so that enemies will target the player. With these additional features, we hoped to be able to make a game with the initial features we proposed and create a playable game within three months.

# Main Content Section

## Recap Problem

The main problem was that we wanted to create a fun game. However, to do that we needed to create interesting and fun features and features to improve a player’s quality of life that would make our game enjoyable to play. These features we wanted to make are the bullet mechanics, health and mana system, rebindable keys, save system, character swapping, skill tree/point system and inventory system.The inventory system includes two different kinds of items. There are the consumable items and the equipment items. The bullet mechanics are designed for the player to be able to do something that can allow them to interact with the environment. However, because of character swapping, we ideally want all characters to be different instead of just an extra pool of health, so we also created melee attacks as well. However, this created another problem, which is that the players can exploit it by walking up to enemies and hitting them with no bad repercussions. So we needed to implement a recoil script that will prevent such a situation from happening. There was also an increasing need to design a working stage that can utilize all of these features, otherwise there is no environment to interact with in the first place. The problems such as these ripple out to cause more problems that require other scripts and systems to fix them, thus requiring us to go on a long journey to fix one problem with another script that causes another problem. And so on and so forth, until we get a working alpha version of our game.

## The Idea

The main idea is that we had hoped to create 7 features which are the bullet mechanics, the health and mana system, rebindable keys, save system, character swapping, skill tree/point system, and a database for items. These features are not unique, as there are many games that currently exist that have these features already. However, the novelty of our work is that we are trying to implement a different kind of character swapping than other games have which is that the characters function with different health and mana from the rest, so damage to one is not shared to the rest of them. Most 2D platformers limit the protagonist to one character and this simplifies many aspects of a 2D platformer because there is only one character to maintain. However, we are maintaining 4, so there is much more work to do, making all existing tutorials useless because they are aimed towards a one character system. The additional features, which were a necessary prelude to these 7 features we wanted to make, we also had to discard most of the 2D Platformer template that Unity has provided us because it was aimed at a 1 character system like much of the existing tutorials on the internet. Thus, we had to come up with most of our scripts on our own, including redoing most of the things provided by the template, which we will explain in more detail later. The idea of swapping characters conflicting with the original template was when it was extended to damage the player receives, because we needed the correct response to when a player was damaged. But we do not want the other players affected by the same damage. Similarly, when we want to switch a character out, we do not want them to revert to the default state and restore all the damage they had taken. In 2D platformers where there was only one character to maintain, there would be only one health object, and all damage would be tracked by that one. However, we need to manage four of them because we have 4 characters.  Another problem that arose from this came from the inventory, because all four of them share one inventory, yet they all have different equipment. So there was a necessity to make it so that when one character picks up an item, the others would be able to see that item within a shared inventory because they are a party. However, they need to have their own equipment which is separate from the inventory, so there is a necessity to not accidentally clone an item when moving it from one player to another. Meanwhile in a game with only one, it would be a simple function to move the object to inventory and move it back to the player. There are some of the few problems that we have encountered that have arisen because of the character swapping mechanic, but we feel that the character swapping mechanic made everything related to our project much more different than other 2D Platformers because they do not have to deal with such problems.

## Technical Details

Due to the many features we had to implement into our game, with a short amount of time, we needed to create a road map that states what we needed to do. Our goal with the road map was to end with a save system, because it was necessary that we prepare everything we need to save before we attempt to implement the system. So we begin with building everything from the ground up using the 2D Platformer template.

The security requirements of this project are set out by the many games that were created before ours. A secure game must adequately cater to the user experience and at the same time, keep the player within the bounds of the game. By doing so, they can properly experience the mechanics of the game without encountering any bugs that may arise if they step out of the confines that the game allows them to. If a game has too many bugs it may ruin the user experience and the game itself. The player must also be aware of what they can do once they are in the game. According to the standards set out by previous games, typically, a good game lets the player experiment with the game mechanics while experiencing as few bugs as possible and a bad game can be littered with bugs and/or unnecessarily limit the player. Our goal to meet the security requirements of our game was to create mechanics that are intuitive to the player and if the mechanics are not intuitive, must be given to the player through text and exposition, or by playing through the game. In addition, we also had to fix any bugs that arose so that it did not ruin the user experience. 

### Hubert Ye

The 2D Platformer template had some useful code, however, due to the fact that we were using 4 characters due to character swapping, most of it is rendered useless. The first of which is the health component that was innately made, which kills the player instantly upon colliding with any enemy. This is most likely because this 2D Platformer was designed for a game like Mario, however we were not making Mario, so the way it currently worked was useless to us. Thus, we needed to change how players can die. This is trivial because we simply needed to introduce an integer for a player’s current health, and similarly for their mana. However, because we are making an RPG, the player needs a visual representation of how much health is remaining, thus we needed to create a health bar. This health bar consists of a slider component, which is innately part of the Unity library, with a value between 0 and 1 attached to a red rectangle, and a C# script such that if the slider increases/decreases, the length of the red rectangle also changes. Accessor functions are then added inside of this script that will protect the slider’s value, so that it can only be changed via these functions, otherwise the slider and length of the health bar will not be synched.  

The health bar is a seperate game object than the player character, because the player’s health is on the character game object and the health bar controller is on the health bar game object. We then need another script to act as the link between the two, which is PlayerController. Using PlayerController, we have it act as the manager that activates the accessor functions of the health and health bar controllers so that the two are in sync.  This PlayerController will also be used for many other functions, to handle the interaction between multiple game objects and/or programs involving the player such as enabling and disabling control of a character when a player swaps to a different character.

To explain character swapping,  we need to introduce four characters, Alice, Bob, Charlie and Dave. By default, Alice is denoted as the first current character, and Bob, Charlie and Dave are denoted as sub-character 1, 2 and 3 respectively, with their keys to swap to them being 1, 2, 3, 4 respectively. Because there exists 4 characters, there exists 4 health bars: the main health bar for the current active character, and 3 side health bars for the inactive characters. Swapping in a character is trivial, because since Unity tracks a 2D character’s position as a vector of 2 points, we simply need to introduce a temporary vector that holds the first character’s position, then have the first character’s position equal to the second character’s position, and then finally have the second character’s position equal to the temporary vector. 

However, this method does not work for the health bars. Because swapping the health bars with this same method would shuffle the order of the health bars, resulting in an inelegant arrangement of the characters, such as Alice being the bottom most health bar even though she is character 1. Because of this, we have a situation similar to the Towers of Hanoi, where we need to be able to take out a disk from somewhere in the tower and add the current disk of some size back into the tower, all without messing up the order of the tower. To do this, since there are only 4 characters, we used the brute force approach, because the amount of cases is small: 4 characters, each with 3 possible swaps for a total of 12 different combinations. Because of this Tower of Hanoi situation where the current character is always changing, it also changes the way other scripts and programs need to be implemented.

In addition to shooting bullets, we added a melee attack to player characters and enemies. How it works is that there will always be a point, called attackPosition, in front of the player character and enemy in the direction they are facing, and upon pressing the melee attack key for players, or if the player gets within range of an enemy while their attack cooldown is at 0, the program will get all game objects within a radius of attackPosition, then check each of those game objects for a tag, “enemy” for player melee attack and “player” for enemy melee attacks, and deal an integer amount of damage to their health and health bar by calling accessor functions in PlayerController and EnemyController. 

For enemies, how the attack cooldown works is that once a player is hit, a float will become some positive number which is their attack cooldown. This will decrease by the amount of time that has passed since the last game update, called a tick. This inevitably causes more lag the more enemies are on a scene, even when they’re not in view, because the game will be both checking for if a player is within a range of them and if the cooldown is at zero, being O(n) for n enemies on a scene. This gets increasingly overwhelming, slowing down frame rate the more enemies are on a scene and the more scripts we need them to run such as line of sight. Thus a more efficient method than the built in Update() is required, which we have implemented called PlayerAggro which will trigger EnemyAggro. How it works is that instead of updating every enemy in the scene every tick, we will only update the ones within a certain radius of the player and then check if they have line of sight to the player. How we check for line of sight is similar to melee attack, except we get all objects in a line between the player and it, and if the player is the only one there, then it has line of sight to the player. How we get this line is by subtracting the enemy’s position by the player’s position to get a normalized directional vector of the enemy to the player, then multiplying it by distance between the enemy’s position and player’s position, which can be found using the pythagorean theorem. This will drastically reduce the amount of updates happening in a scene along with allowing us to control in which order that they occur.

In addition to enemies attacking, there is also a necessity to prevent players from overlapping on top of enemies, and running past them to get to the final boss. To alleviate that problem, we have introduced a knockback class that will be called to do the calculations regarding the direction and force. The direction is calculated by taking the position of the game object doing the knockback, A, and the position of the game object being knocked back, B, and subtracting the former from the latter, B-A. This will create a directional vector of the latter to the former, which we can normalize using the built in .normalize() function for 2D vectors. And then we can multiply this by a negative scalar, a float that denotes the force of the knockback and also flip the directional vector to go in the direction directly opposite of the one facing the object doing the pushing. The final result is a vector at position B pointing in the direction opposite of the way facing A, which we can plug into B’s rigidbody’s built-in addforce() function, to create the effect that A knocked away B.  

### Phillip Chen

Another feature that we added was the feature that allows characters to shoot bullets. Unity has many ways to create motion to an object. We needed a method that allowed bullets to travel across the screen at a constant rate of speed and not affected by gravity. Each object in unity has a Transform property with the directions of X,Y and Z. Since we are working with a 2D game, we only have to worry about the horizontal axis (X) and the vertical axis(Y) . Positive X moves objects to the right and positive Y moves the object higher. Using this knowledge, we can update the bullet’s location with new values in a Vector2 to make the bullet go in the direction we want. At the end we decided on allowing the player to be able to shoot in eight different directions by taking into account which directional keys are held down while the player is shooting. We encountered another problem that the bullet sprite doesn’t face the direction the bullet is moving. In order to fix this problem, we needed to look into Transform to see how to modify the rotation of the bullet sprite. The Unity Library stated that modifying the values directly in rotation is bad practice and gave us a container to store desired values to modify rotation. We modified an empty Quaternion container by changing its Euler values, which has three integers that represent degrees. Using the Quaternion.Euler we replace the Transform.rotation inorder to make the bullets image face in the direction you are shooting.

### James Zhao

The creation of rebindable keys and dialogue boxes are both user interfaces (UI) that were required by the proposal plan when we set out to create our game. The idea of creating rebindable keys is not unique nor is it difficult to implement, but it expands upon the quality of life factors of our game. We started with the idea that we would have multiple skills which would take multiple buttons to use. The idea of using too many buttons became a problem and an easy inconvenience to the user experience. Instead, the idea of rebinding the keybinds is so that it would improve the convenience for the user. The user could decide what keys they would want to press as opposed to having a key in an uncomfortable position. Starting from its script, a rebindable keys system needed a dictionary to work properly. You must store every input that you want to rebind and store the original keybind that every input is binded to. Afterwards, the creation of the interface that the user will use to change their keybinds becomes a matter of dragging every UI button into the manager for the main keybind script and adding more as more buttons are being used. 

The idea of having dialogue boxes, although not novel, is a critical component of every story driven RPG. The difficulty in implementing a dialogue system in Unity is the fact that there are many different dialogues that each accomplish a different purpose in the type of game you try to create. In our Unity based RPG, we wanted to talk with a non-playable character (NPC) by pressing a button, have a textbox triggered by the player when they enter an area, and answer “yes or no'' types of branching dialogue. The script for non-branching dialogue works by cycling through each line of a .txt file when the textbox is triggered. The implementation for branching dialogue is more complex because it requires a question, multiple buttons to branch from, and a response from each button to branch to. After all the different dialogue systems have been tested, we could start fixing small bugs within the game mechanics such as stopping the player when they initiate a conversation or disable opening every other UI element while the textbox remains active. 

### Paolo Tejeda

For this project, we thought that an inventory system could be a great implementation to our game. We decided we wanted to have two different types of items. Consumable and equipment items and make them work on the same inventory system. To make this work, we created one UI for both. This UI is composed of 15 slots for consumable items and 20 slots for the equipment items. The user can open the UI by pressing the key “B”. The game stops when the inventory is open. To make the whole inventory system work we created a script named “GameManager”. The slots for consumable items contain two buttons. The UsingButton to use the item and the RemoveButton to delete the item from the inventory.  An image to show the sprite of the item and a counter because the consumable items are stackables and we want the player to know how many items of the same type they have. For the consumable items, we created an ScriptableObject script (A class you can derive from if you want to create objects that don't need to be attached to game objects.This is most useful for assets which are only meant to store data)
 named “Item” to store the item information such as itemName, description, itemSprite, value and what they modify (for this game the consumable items modify health and mana). In the GameManager script we have a List for items to store all the consumable items, a List of itemNumbers to know how many of each item we have and an array of GameObject to store the slots of the consumable items which are gameObjects. For the consumable items we have different functions such as the addItem() to add a new item that the player picks up and if the player already has that item in their inventory the count for that item increases by 1 instead of placing the repeated item in a new slot. The displayItem() checks how many consumable items are in the inventory and displays them by getting the sprite and quantity info of each item from the list of items and enabling the UsingButton and DeleteButton for those slots. The empty slots do not show those buttons. The RemoveItem() and ResetButtonItems() take care of deleting consumable items from the inventory system. To make those items change the current character health and mana, we created a script UseItemButton. Each time the player clicks that UsingButton, which is in the top right of each slot, the button calls the UseButton() function that checks the ‘modify’ variable in the item ScriptableObject script whether it modifies health or mana. For any of those cases, the function gets the current player and modifies its health/mana and health/mana bars and decreases the quantity of items in the inventory. If the quantity was one then the item is removed from the inventory system. If the current health is equal to the max health the item is not used. For example if the character maxHP is 100 and their currentHP is 95 and the Potion item increases HP by 10 then the item is consumed and the currentHP increases to 100 and not 105 because the maxHP is 100.  The equipment items are stored in a similar way of consumable items but are more difficult to implement and use. The idea behind the equipment items is that each character is able to store 5 equipItems which are helmet, chest, pants, boots and weapon (in a private List of EquipmentItem in the player controller which is a component for each character). The first 4 modifies the maxHP of the character which is using that item and the weapon increases the damage of the range or melee attack depending on the item. When the user clicks the equipment Item the current character gets the item, the maxHP changes, the clickable button gets locked, the name of the current player is displayed in the equipment item slot and all the information is stored in the List of EquipmentItem. If the user changes character,  from Alice to Bob, in this case the user can not click the equipment item that Alice is using because it's locked. There are variables in the ScriptableObject script of equipmentItem called eUsing and eItemUsedByCharacter to control what items are being used and what character is using them. If Alice is using Helmet1 and she picks up Helmet2 which gives her more HP, she can change helmets by clicking the helmet2 slot. The maxHP is decreased by helmet1 value and then increased by Helmet2 value. Helmet1 is now available to use for other characters. The same happens for all the equipment items. A character can not use two items of the same category (helmet, chest, pants, boots). In the case of weapons, each character is allowed to have two different weapons for range attack which are activated when a character picks them up and clicks it to use it (the keys are J and K). The Inventory System also includes a tooltip which shows description of each item when the player points to the item slot. Players can find items, both consumables and equipment, in the map. Some items are on the floor, others in a box that the player has to destroy and also some enemies drop items when they die. For items and character attributes like hp, mana and damage we created a store UI where the player can buy items or buy points of health, mana or damage. They all have different prices and the player can pay it with the coins they pick up during the game. 
	
# Conclusion and further work

Our main goal of making a game is complete, but there is much to be improved upon. Given what we set out to do, what we chose to keep in mind, and the time limit, we had to compromise on many goals and decide which ones to complete, which ones we abandon, and what we can partially complete with the promise to come back to. We focused mainly on the mechanics and the core aspect of what made a game. Compared to many modern games, our game is lacking in its appearance. Many common elements in most games are absent in our own. Many actions that a person expects to be animated are not. An example of this is the melee attack animation on enemies, so players would be damaged by enemies upon getting close to them despite not visibly getting hit or touched by anything. The player’s melee attack is also much longer than the toothpick sized stick animation that plays, so a player can damage an enemy despite not being in visual range. Another is that the UI such as the health bar are constantly visible and do not turn off for other scripts, which can clog up the screen making things harder to see for players. However, these are all front end visuals that can be tinkered by modifying the animator through the Unity UI and not related to code in the back end. In addition, we focused on the back-end to the point where there are small inconsistencies between each stage of the game which can make it obvious that a different person worked on the stage. Although we kept the front end assets limited to the free assets provided by Unity, it limited our game such that if we could not find the right asset to fit in a certain spot of the game, we had to crudely make our own.  

In addition to the front end, there are also many back end features that we wanted our game to have that we could not implement due to complexity and/or time. Examples are more enemy attack and aggression patterns, because at the moment, they only try to collide with the player. More complicated attack patterns will be necessary to make the game more enjoyable, especially if the boss has different ones as well. Another is that even though it is possible to change keybindings, not everything has been linked to it yet, making so that certain keybinds cannot be changed. In addition to that, there are many inefficiencies in the code that can most likely be pruned or improved, such as moving more Update() functions into UpdateManager.cs so that it can handle more of the updates, thus uniforming where the update occurs, be controlled, and queued. 

There are also more additional features that we have thought about implementing but did not due to shortage of time. There is room to create a level system so that players have a way to gain skill points, because without it, a player will only have the default 5. However, to make a level system, there is a need to create ways to get experience to gain those levels such as defeating enemies, and then another function to check if the necessary amount of experience is gained to perform a level up which is time consuming to make because then we have to make a map for the amount of experience necessary to reach the next level, and we have to account for edge cases such as if a player goes over the necessary amount or reaches max level. Another is multiplayer capabilities, because there are four characters, there was an idea to allow up to 4 players, with each player playing a separate character. However, this would require us to set up the netcode, create a system that would allow players to connect to one game, and have the responses on one screen reflect into the other smoothly. A very crude way we can bypass the need to create a complicated netcode system is to lock the game into local multiplayer. By making multiplayer local, the idea becomes much more feasible as to what controls a second player can press because they do not need to be the same as the first player. There are several other minor features that we could add, such as selling items, crafting items, power ups, and more. Given an extended deadline, more features can be added to improve the player’s experience and create a more complex game.

While in the process of creating the game, there are several limits we have encountered within Unity2D’s system that limited our scope of the game. The first of which is when a scene loads, occasionally, the gravity loads first before any colliders, causing objects to fall and pass through other objects because their collider has not loaded in yet. A solution would most likely be to disable gravity on the things we do not want passing through the ground, and then when the scene is finally loaded in, then we enable the gravity back. Working with these limits placed on us by the game engine, we created a playable game.

# References
[Unity Documentation](https://docs.unity3d.com/2020.2/Documentation/Manual/index.html)

[Unity Programming Patterns](https://github.com/Habrador/Unity-Programming-Patterns)
