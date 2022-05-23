using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.Target.GetTarget(collision.transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemy.Target.GetTarget(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform == enemy.Target.Target)
        {
            enemy.Target.TargetExitDetector();
        }
    }
}
