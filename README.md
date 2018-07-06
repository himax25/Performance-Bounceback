# Udacity High Immersion Project - Tunning up Performance Bounceback game.  
This is the 2nd project for tunning up the performance of Bounceback game at High Immersion Unity with Oculus' Rift HMD at 3D VR development course in Udacity.
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/BallBouncebackGame%20Screenshot0.JPG)
## How to play the Game
1. Make many balls bounces with Trampolines to get a score in given time.
2. Grab a ball, generated every 0.5 sec, and throw the ball to Trampolines.
3. Press <b>B</b> button to Reset the game.
4. Press <b>Menu</b> button on the right cotroller to Exit the game.

## new features to add on this Game
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
>> <li> <B>Performance tunning action 1. </B> Enabling Static batching at all grounded and non-moving objects:</li>
>> 288 Grounded Trampoline objects, Platform, Ground, Factory structure, Cube, and Ball Spawner. 
>> <li> <B>Performance tunning action 2. </B> Enabling Dynamic batching at all moving objects:</li>
>> 48 Air Trampoline objects, Lights, and Camera. 
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/Enabling%20batching%20Screenshot1.JPG)
>> <li> <B>Result: </B></li>
>> Saved by batching from 0 to 983, and the total number of Batches has been dropped from 1904 to 813. However, the frame rate, 45.4 FPS, has still not reached at 90 FPS. 

## Reducing calculation time by optimizing Physics with Rigidbody components
>> <li> <B>Performance tunning action 1. </B> Removing Rigidbody component from all Static collider game objects:</li>
>> 288 Grounded Trampoline objects. 
>> <li> <B>Performance tunning action 2. </B> Adding Rigidibody component on all moving collider game objects:</li>
>> 48 Air Trampoline objects. 
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/Optimizing%20Physics%20Screenshot2.JPG)
>> <li> <B>Result: </B></li>
>> Saved by batching from 983 to 1029, and the total number of Batches has been dropped from 813 to 640. However, the frame rate, 46.1 FPS, has still not reached at 90 FPS. 

## Refactoring Creating algorithm for ball object in the game pool
>> <li> <B>Performance tunning action 1. </B> Enhacing the algorithm for creating ball objects in the game pool:</li>
>> Changing the algorithm for creating ball objects in the pool from <B>the balls spawned forever</B> to <B>recycled 20 created balls</B>. 
>> Enhanced Creating Game object algorithm from recycling 20 occupied balls to 40 occupied balls to slow down the ball generation speed.
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/Object%20Pool%20Screenshot3.JPG)
>> <li> <B>Result: </B></li>
>> Saved by batching from 1029 to 1178, and the total number of Batches has been dropped from 640 to 498. However, the frame rate, 47.3 FPS, has still not reached at 90 FPS. 

## Caching variables and optimizing code
>> <li> <B>Performance tunning action 1. </B> Caching variables:</li>
>> Refactoring scripts to minimize to use Update, Start functions, and directly invoke Getcomponent functions massively: <b>BallSpawner.cs</b>, <b>Ball.cs</b>, and <b>Trampoline.cs</B>.
>> Geting rid of unnecersly debuging log functions from scripts: <b>Ball.cs</b>, <b>BallSpawner.cs</b>, <b>GameManager.cs</b>, <b>PlatformIdManager.cs</b>, and <b>Trampoline.cs</b>. 
>> <li> <B>Performance tuning action 2. </B> Optimizing code:</li>
>> There are 4 scripts, <B>GameManager.cs</B>, <b>Trampoline.cs</B>, <B>Ball.cs</B>, and <B>BallSpawner.cs</B>, to refactor for enhancing performance.
>> And, there is a script, <B>AvatarCalibrator.cs</B>, to create for tracking Oculus Touch Controllers to be assigned to Avatar's hands.  
![screenshot](https://github.com/himax25/Performance-Bounceback/blob/master/Screenshots/Optimizing%20Code%20Screenshot4.JPG)
>> <li> <B>Result: </B></li>
>> Saved by batching from 1178 to 829, and the total number of Batches has been dropped from 498 to 413. Finally, the frame rate, 103.8 FPS, has upper reached at 90 FPS.

## Setting up lighting with MSAA
>> <li> Action Item 1. with screenshots </li>
>> <li> ![screenshot](https://github.com/himax25/Performance-Bounceback/Screenshot1.PNG) </li>
>> <li> Action Item 2. with screenshots </li>

## Baking lighting
>> <li> Action Item 1. with screenshots </li>
>> <li> ![screenshot](https://github.com/himax25/Performance-Bounceback/Screenshot1.PNG) </li>
>> <li> Action Item 2. with screenshots </li>

## Using light probes
>> <li> Action Item 1. with screenshots </li>
>> <li> ![screenshot](https://github.com/himax25/Performance-Bounceback/Screenshot1.PNG) </li>
>> <li> Action Item 2. with screenshots </li>

## Using the profiler for performance optimization 
>> <li> Action Item 1. with screenshots </li>
>> <li> ![screenshot](https://github.com/himax25/Performance-Bounceback/Screenshot1.PNG) </li>
>> <li> Action Item 2. with screenshots </li>

## The period of developing
It takes 25 hours to turn up this project.

## Major challenges in this project.
There 

# Conclusion

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
- Downloaded prefabs from Unity Asset Store;
>> (1) Tube constructor Kit prefabs, Environments, Urban, https://deployer117.deviantart.com/
- Download FX Sound from Unity Asset Store;
>> (1) FREE Casual Game SFX Pack from dustyroom.com, UX/UI sounds, 24-bit WAV format, 44.1 kHz Stereo.
- Download Background Music from Unity Asset Store;
>> (1) Absolutely Free Music, Vertex Studio
