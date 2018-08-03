## Introduction
*Legacy* - by Matthew Morris

For the best reading experience, please view this in a markdown viewer. This readme will give a brief explanation of how to interact with my game and a description of each of the features that were implemented by requirement.

To run the game, you may play the main menu scene from inside Unity (Assets/Scenes/Menu). Alternatively, you may also run *Legacy.exe*, which can be found in the root of the project.

## Gameplay
The game begins in a main menu, which I adapted from my previous Unity assignment. Simply click "New Game" to begin. In game, you control a small robot moving around a virtual environment (the entire aesthetic is meant to be reminiscent of Tron). You may shoot the objects around you, although the pillars cannot be broken and the cubes take 3 hits to destroy.

## Controls
The following controls can be changed as the game is launched via the Unity interface; but here follows the default keybindings and what they do.

#### Movement
*w* - Move forwards.
*s* - Move backwards.
*a* - Move left.
*d* - Move right.
*mouse* - aim gun / first person camera.
*space* - jump.
*left shift* - sprint.

#### 3rd Person Camera Control
*t* - Radius increase.
*g* - Radius decrease.
*y* - Height increase.
*h* - Height decrease.

#### Orbiting Camera Control
*u* - Radius increase.
*j* - Radius decrease.
*i* - Height increase.
*k* - Height decrease.

#### Other
*c* - Change camera mode.
*left mouse* - Fire gun.
*enter* - Submit.
*backspace* - Cancel.

## Features

#### Player Movement and Animation
All player movement is done as specified. The forces applied in movement are done with respect to the current active camera. The gun orientation and first person camera are controlled by mouse input.

#### Cameras
I have implemented the 3 cameras as specified. The height and radius of the 3rd Person and Orbiting cameras can be controlled in game as specified in the *Controls* section of the readme.

#### Environment Setup and Physics
The entire game is set on one big platform. All objects placed in the world have attached colliders and several have rigidbodies. The world is built at runtime with random generation. Concentric circles of alternating pillars and other objects are spawned in when the game begins. The parameters for this generation can all be tweaked in the *World Builder* script attached to the *Scripts* game object in the *Game* scene.

#### Raycasting
The gun is shot using raycasting, with a laser line tracing out the path of the shot. The pillars are not destructible but everything else is. You can make something destructible in my game by simply attaching an instance of the *DamageableObject* script to the object. The cubes and random junk all have attached *ExplodingObject* scripts which extends *DamageableObject*.

#### Visual Effects
**Lighting**: In my scene, I made use of point lights on the objects and one big area light to illuminate the entire map. I also used a reflection probe to create the lighting for the ball the player rests on. Finally, I made use of emissive materials on the game world objects to create a Sci-Fi aesthetic.
**Textures**: The textures for some of the randomly spawned objects are assigned at random when the game starts.
**3D Text**: This can be seen hovering in the sky.
**Particle Effects**: I created my own particle effect for when an object explodes.

#### Sounds
I have implemented sound effects for when the gun shoots and for when an object explodes. There is also a music controller that randomizes the soundtrack playing in the background so it doesn't get repetitive. See the *MusicController* script.

#### Randomness
The entire generation of the game world is randomized based off parameters set in the *World Builder* script. The objects are spawned in concentric circles, alternating between pillars and other objects. The gaps between the circles and between the objects therein are randomized. The non-pillar objects are randomly selected between glowing cubes and junk objects. Every junk object is assigned a random texture.
