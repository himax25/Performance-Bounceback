# Udacity High Immersion Project - Tunning up Performance Bounceback game.  
This is the 2nd project for tuning up the performance of Bounceback game at High Immersion Unity 3D VR development course in Udacity.
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/BallBouncebackGame%20Screenshot0.JPG)
## How to play the Game
1. Make many balls bounces with Trampolines to get a score in given time.
2. Grab a ball, generated every 0.5 sec, and throw the ball to Trampolines.
3. Press <b>B</b> button to Reset the game.
4. Press <b>Menu</b> button on the right cotroller to Exit the game.
![youtubelink](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/YouTubesitelink.JPG)[for playing Youtube video here](https://youtu.be/Wb9o5GQAqC8)

## New features to add on this Game
1. Local Avatar with Oculus Touch Controllers to play the game.
2. Recoding the highest score in the local computer.
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/BallBouncebackGame%20Screenshot1.JPG)

## The key objective of this project
The major mission of this performance tuning project is to use profiler tools to identify problematic code, 
correct them and improve the performance of this game to play comfortably base on the following 8 checking and correcting items on this game:
* Reducing draw calls by using static and dynamic batching
* Optimizing Physics
* Creating object pools
* Caching variables and optimizing code
* Setting up lighting with MSAA(Multi Sample Anti-Aliasing)
* Baking lighting
* Using light probes
* Using the profiler for performance optimization
 
# How to tune the performance of this game up
## Reducing draw calls by enabling both static and dynamic batching
>> <li> <B>Performance tuning action 1. </B> Enabling Static batching at all grounded and non-moving objects:</li>
>> 288 Grounded Trampoline objects, Platform, Ground, Factory structure, Cube, and Ball Spawner. 
>> <li> <B>Performance tuning action 2. </B> Enabling Dynamic batching at all moving objects:</li>
>> 48 Air Trampoline objects, Lights, and Camera. 
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/Enabling%20batching%20Screenshot1.JPG)
>> <li> <B>Result: </B></li>
>> Saved by batching from 0 to 983, and the total number of Batches has been dropped from 1904 to 813. However, the frame rate, 45.4 FPS, has still not reached at 90 FPS. 

## Adjusting Physics update rate
>> <li> <B>Performance tuning action 3. </B> Adjsting Physics update rate from 0.005555556 to 0.01111111 Fixed Timestep in order to match with the VR framerate 90 FPS. 
 ![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/PhysicsUpdateRateScreenshot.JPG)

## Reducing calculation time by optimizing Physics with Rigidbody components
>> <li> <B>Performance tuning action 4. </B> Removing Rigidbody component from all Static collider game objects:</li>
>> 288 Grounded Trampoline objects. 
>> <li> <B>Performance tuning action 5. </B> Adding Rigidibody component on all moving collider game objects:</li>
>> 48 Air Trampoline objects. 
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/Optimizing%20Physics%20Screenshot2.JPG)
>> <li> <B>Result: </B></li>
>> Saved by batching from 983 to 1029, and the total number of Batches has been dropped from 813 to 640. However, the frame rate, 46.1 FPS, has still not reached at 90 FPS. 

## Refactoring Creating algorithm for ball object in the game pool
>> <li> <B>Performance tuning action 6. </B> Enhacing the algorithm for creating ball objects in the game pool:</li>
>> Changing the algorithm for creating ball objects in the pool from <B>the balls spawned forever</B> to <B>recycled 20 created balls</B>. 
>> Enhanced Creating Game object algorithm from recycling 20 occupied balls to 40 occupied balls to slow down the ball generation speed.
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/Object%20Pool%20Screenshot3.JPG)
>> <li> <B>Result: </B></li>
>> Saved by batching from 1029 to 1178, and the total number of Batches has been dropped from 640 to 498. However, the frame rate, 47.3 FPS, has still not reached at 90 FPS. 

## Caching variables and optimizing code
>> <li> <B>Performance tuning action 7. </B> Caching variables:</li>
>> Refactoring scripts to minimize to use Update, Start functions, and directly invoke Getcomponent functions massively: <B>BallSpawner.cs</b>, <b>Ball.cs</B>, and <B>Trampoline.cs</B>.
>> Geting rid of unnecersly debuging log functions from scripts: <B>Ball.cs</B>, <B>BallSpawner.cs</B>, <B>GameManager.cs</B>, <B>PlatformIdManager.cs</B>, and <B>Trampoline.cs</B>. 
>> Refactoring <B>GameManager.cs</B> script to enhance the score updating algorithm by update the score when the player get a point.
>> <li> <B>Performance tuning action 8. </B> Optimizing code:</li>
>> There are 4 scripts, <B>GameManager.cs</B>, <b>Trampoline.cs</B>, <B>Ball.cs</B>, and <B>BallSpawner.cs</B>, to refactor for enhancing performance.
>> And, there is a script, <B>AvatarCalibrator.cs</B>, to create for tracking Oculus Touch Controllers to be assigned to Avatar's hands.  
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/Optimizing%20Code%20Screenshot4.JPG)
>> <li> <B>Result: </B></li>
>> Saved by batching from 1178 to 829, and the total number of Batches has been dropped from 498 to 413. Finally, the frame rate, 103.8 FPS, has reached over 90 FPS.

## Optimizing all lighting by changing Lighting rendering path with MSAA, Performant Lighting mode, Baking lighting, and using light probes. 
>> <li> <B>Performance tuning action 9. </B> Changing Lighting rendering path from <B>Deferred</B> to <B>Forward</B> with supporting MSAA</li>
>> <li> <B>Performance tuning action 10. </B> Changing Performant Lighting mode from <B>Realtime</B> to either <B>Mixed</B> mode or <B>Baked</B> mode.</li>
>> <li> <B>Performance tuning action 11. </B> Applyinging the <B>global illumination baking</B> with lightmaps</li>
>> <li> <B>Performance tuning action 12. </B> Applying <B>light probes group</B> with point lights<li>
 
## Using the profiler for performance optimization 
>> <li> <B> Performance tuning action. </B> Using Oculus' profiler & Unity's profiler to monitor and optimize the game performance with above action 9, 10, 11, and 12. </li>
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/Optimizing%20Lighting%20Screenshot5.JPG)
>> <li> <B>Result: </B></li>
>> Draw call had dropped from 931 to 190 with 99.3 FPS.

## The period of developing
It takes 35 hours to turn up this project.

## Major challenges in this project.
There were a challenges to build up this game: 
>> <li> <B>1. To configure a visual controller for Oculus Touch controllers in this game; </B></li> 
>> The are many prefabs and Mesh for SteamVR with Oculus. However, there are few prefabs and Mesh for Oculus' Touch Controllers and they are not free of charge asset for. I lucky found out such local avatar SDK from Oculus website to build this game with.
>>
# Conclusion
It is a pretty tough objective to satisfy that is enhancing the game performance with maintaining the visual quality assurance of this game. I was able to achieve obtaining more than 90FPS performance but unable to get less than 100 draw calls to sustain during playing this game. I need to give up some performance related some visual effects in this game.   

## **Author of this coding**
* Hyo Lee, linkedin [here](https://www.linkedin.com/in/hyomaxlee/)
 
## Versions
- Unity 2017.2.0f3
- GVR Unity SDK v1.60.0
- Oculus Utilities v1.25.1 
- OVRPlugin v1.27.0 & Bundled version 1.14.1 
- Oculus Avartar SDK v1.28.0
- Test Platform: Windows 10 Home Edition 64 Bit OS /w Oculus Rift HMD

## Free Assets to download from online Store for this game. 
- ownload Oculus SDK Package v1.27.0 and v1.28.0 from Oculus website;
>> (1) Oculus Avartar SDK and Oculus Intergration SDK scripts for OVRPlayer Controllers and OVRCameraRig
- Download Background Music from Unity Asset Store;
>> (1) Absolutely Free Music, Vertex Studio
