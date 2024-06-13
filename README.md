## RPG Systems

This is a collection of expandable RPG systems.

### Systems
* Inventory System
* Skill Creation System
* Turn System

Note: This project uses my utility plugin https://github.com/enes-ozdemir/Enca-Unity-Plugins

### Inventory System
The Inventory system supports drag and drop, swapping items, stacking items, and unstacking items. It is very easy to create new inventories like chests or quick slots.

This sample contains a CharacterInventory as well, and it is controlled by the CharacterInventory class. The CharInventory class can only equip EquippableItem, which are items that inherit from the Item class.

The Inventory system is controlled by InventoryManager. Each inventory must have an Inventory MonoBehaviour attached to it.

![inv](https://github.com/enes-ozdemir/2D-RPG/assets/41696219/37bcf529-ef4d-4883-ae72-bd30119c702f)


### Skill Creation System
This skill creation system uses DOTween to create complex animations.

You can join animations or make them wait for the previous animation to finish. Skills contain SkillParts that hold the parts of the animation, like an explosion.

For example, an Ability can contain a Fireball SkillPart and an Explosion SkillPart to create a fireball animation. SkillParts contain several different types of animations like Fade, Go To Position, etc. However, it is very easy to add new types of animations.
![Animation](https://github.com/enes-ozdemir/2D-RPG/assets/41696219/3d34290d-22a4-4ef1-9417-28a6757294b7)
![1](https://github.com/enes-ozdemir/2D-RPG/assets/41696219/e963ccfb-8496-430c-84ea-68b0cc3163d6)
![2](https://github.com/enes-ozdemir/2D-RPG/assets/41696219/d44fcc8c-6b98-48f7-b673-3ee180c96580)
![3](https://github.com/enes-ozdemir/2D-RPG/assets/41696219/e6cd7518-05f0-4fc4-aa20-8fe28f888a67)

### Turn system
Async turn system that uses tasks.

![image](https://github.com/enes-ozdemir/2D-RPG/assets/41696219/6285e46c-8d0b-42ac-8107-927d045d136d)

**Note:** This repository doesn't include the assets those I don't hold the right to distrubute. You have to acquire the assets to properly run the game in Unity. I will publish the name of the assets list after game completes. If you have the rights to use the assets I can share the my asset submodule folder for easier access.

