using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Damage(int dmg, int direction, Vector2 pushBack);
}
