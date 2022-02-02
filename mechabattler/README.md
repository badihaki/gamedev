TODO:
Character:
  PlayerWeapon modifications:
	Make currentHeldAmmo - an int[] detailing how much ammo of each type the player holds
		bullets
		shells
		warheads
		plasma
		('**' designates values already in PlayerWeapon that just need to be moved
	Finish Weapon Scriptable Object and Weapon Object
		Include values:
			currentAmmo - how much ammo in the clip, can't go past clipSize ** Weapon Object
			maxAmmo - self explanatory
			clipSize - amount of rounds until reload
			ammoType - determines which ammo to take out of
			reloadTime - Amount of time it takes to reload a gun
				Include reload function
					Adds 'clipSize' of 'ammoType' to 'currentAmmo'
					
	Tether, Move Ability, Ability 1 and Ability 2
		Need logic for all
		- MOVE ABILITY FIRST
			- Dash and Jetpacks
		- TETHER SECOND
			- basically grapple shot
	
  Make all colliders their own Child Gameobj
    Hurtbox & Body for easier disable
    Give hurtbox collider 'Hurtbox' script
      Hurtbox can be universal, just needs to hold the gameobj's real parent
