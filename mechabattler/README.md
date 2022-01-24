TODO:
Character:
  FIX JUMPING
  Make system for holding weapons
  PlayerWeapon modifications:
	Make currentHeldAmmo - an int[] detailing how much ammo of each type the player holds
		bullets
		shells
		warheads
		plasma
  Create Weapon Scriptable Obj
	Will allow easy ref to weapons' diff values
	Include values:
		inGameObj - The actual object that spawns into the player's hands
		** projectilePrefab - the actual projectile that spawns when shooting
		** projectileSpeed - self explanatory
		projectileDamage - self explanatory
		** fireRate - self explanatory
		clipSize - amount of rounds until reload
		maxAmmo - self explanatory
		('**' designates values already in PlayerWeapon that just need to be moved
	Create Weapon Gameobj Prefabs
		Include values:
			currentAmmo - how much ammo in the clip, can't go past clipSize
			ammoType - determines which ammo to take out of
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
