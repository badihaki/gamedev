TODO:
Character:
  * FIX JUMPING * Most Important!!
  Make system for holding weapons
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
	
  Ride vehicle
  Make all colliders their own Child Gameobj
    Hurtbox & Body for easier disable
    Give hurtbox collider 'Hurtbox' script
      Hurtbox can be universal, just needs to hold the gameobj's real parent

Vehicles:
  Create mech prototype
  Figure out how to get player 'IN' the damn thing
    Prob have to attach the player to a point on the mech
    AND
    disable the colliders for hitbox and body