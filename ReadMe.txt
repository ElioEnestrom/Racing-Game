Elio Eneström

Unity Version and Packages: 2022.3.9f1, TextMeshPro, New Input System

How to boot up in unity
You start the game from the scene named "StartScene" where you will navigate through the menu and can choose from 
a variety of levels. If you want to look at the code there is a "Scripts" folder in the "Assets" folder. Alternatively, 
if you're looking for something else there is most likely a folder of that in the "Assets" folder too. There will most likely appear some errors when you play but all of them don't have any actual impact on the gameplay.

How to play/Pitch
This game is a competitive racing game where you and a friend try to make your ways through the 
winding paths of a race track, aiming to be the first one to do 3 laps. However, the walls of the race track 
are so dangerous that your car instantly explodes if it comes into contact with one. With one player 
controlling their car with WASD and the other with the Arrow Keys they have to decide if they want to drive 
their cars slowly and potentially lag behind, or if they want to drive quickly with the risk of sliding into a wall.
The car's wheels can also spin very, very fast which results in that if you build up ample speed, the steering will 
turn significantly harder. Obstruct your enemy or empower yourself by collecting one of various power-ups that have 
strewn across the tracks. You can pause to exit the game or return to the main menu to pick another map. 
Finally have fun and race on!

How I solve problems
When I try to solve a problem I generally try to tackle it from different angles. For example, when I tried to make 
the cars a power-up which gives ice physics I tried to first find a way to lower the variables on the four wheel 
colliders of the cars. Then that proved more difficult than I first expected so I then tried to see if I could lower 
the floor's friction instead. Upon realizing that changing the friction for some reason didn't really change how the 
car slides, and that changing the floor will give the player ice physics too, I decided to implement another 
debuff power-up, namely lowering the motor's max output. Then since I had my bare minimum amount of power-ups 
I shelved the ice physics debuff power-up until I made sure that I could finish the rest of the project in time.

Code structure:
I wrote my code with the intent of it being very easy to expand upon, but also good 
enough that I didn't have to add any new features for it to be "Finished". In this way it was easier for me to both 
add new features and finish the product without having a big polishing process (Though I wish I polished some more).
I tried to not spread out my code into a lot of different scripts and instead generally had around one script per 
mechanic or object. I was also not really sure how you wanted me to comment on my code since I knew I shouldn't 
overexplain everything but I didn't really know where to draw the line, so I hope it was good enough!

Design
To me the design of the game didn't really matter as long as I stuck to my one rule: All the 3D modeling should 
be done by me. This is because I believe working on this project in the right way could help me improve both my 
game programming and 3D modeling. And also it was very fun to make my own race track. This helped me in the end 
because it enabled me to separate the wall from the ground to easily make a system for destroying the cars when 
they drive into the walls.

Assets Used
Racing Car Image - https://pixabay.com/vectors/car-auto-vehicle-red-car-30984/
Cog - https://pixabay.com/vectors/gear-settings-options-icon-1077550/
Exit - https://pixabay.com/vectors/emergency-exit-exit-door-way-sign-98585/
Skull - https://pixabay.com/vectors/skull-head-dead-human-skeleton-41416/
Fire - https://pixabay.com/vectors/koster-flame-fire-1898042/
Helmet - https://pixabay.com/vectors/bike-helmet-motorcycle-protection-160116/

Unity References and Inspiration
Cars - https://docs.unity3d.com/Manual/WheelColliderTutorial.html
Start Menu - https://www.youtube.com/watch?v=zc8ac_qUXQY
Sound Slider - https://www.youtube.com/watch?v=_m6nTQOMFl0
