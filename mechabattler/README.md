TODO:
Character:
  PlayerWeapon modifications:
	Make currentHeldAmmo - an int[] detailing how much ammo of each type the player holds
		bullets
		shells
		warheads
		plasma
		('**' designates values already in PlayerWeapon that just need to be moved)					
	Move Ability, Ability 1 and Ability 2
		Need logic for all
		- MOVE ABILITY FIRST
			- Dash and Jetpacks	
  Make all colliders their own Child Gameobj
    Hurtbox & Body for easier disable
    Give hurtbox collider 'Hurtbox' script
      Hurtbox can be universal, just needs to hold the gameobj's real parent
	  
Weapons:
	Make bullets hurt player characters
		- Use an interface to determine what can be damaged


BUGS:
Controller aiming doesn't work!
	- Split the logic in function 'FollowAim' into 2 functions 'FollowGamepad' and 'FollowMouse'
	- Use logic already present in 'FollowAim' for 'FollowMouse'
	- Figure out why aiming with gamepad isn't working!!