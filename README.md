# 410-Assignment2
410 Game Programming Assignment 2

Gameplay Elements and Their Descriptions:

    Dot Product:
    For the Dot Product, I added some funny spinning chairs that use the dot product to spin according to player movement. I haven't been able to have them follow the player exactly how I want yet, but they are spinning based on the dot product. These chairs are placed at the beginning of the game as a fun, spooky start. The code for the script is contained in the ChairObserver.

    Linear Interpolation:
    For linear interpolation, I modified the player movement script so that instead of walking at a constant pace, the player slowly accelerates using linear interpolation. This simulates the player essentially gaining confidence in their movement. To trigger this all you need to do is continue to walk and you will begin to increase your speed gradually. Your speed will be reset after stopping and you will need to begin walking to pick up the pace again. To modify your max speed, all you need to do is increase the upper_speed and to increase the rate at which you pick up your pace, increase the float value on line 51. Note also that his interpolated speed variable is his starting speed we are beginning from. 

    Particle Effects:
    I implemented three similar particle effects in the level that are persistent throughout your playthrough. There are two placed at both the inaccessible room doors to evoke a sense of mystery about these unopenable areas. The other misty particle is placed in the bathtub to create a more dramatic steam to add a bit more humor and emphasis on the amusing ghost taking a shower. 

