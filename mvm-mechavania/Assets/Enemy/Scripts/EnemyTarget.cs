using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    private Enemy enemy;
    public Transform Target { get; private set; }
    public float TargetTimer { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        TargetTimer = enemy.waitSearchTime;
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void GetTarget(Transform newTarget)
    {
        if (newTarget != Target)
        {
            Target = newTarget;
        }
        TargetTimer = enemy.waitSearchTime;
    }
    public void TargetExitDetector()
    {
        Target = null;
    }
    public void RunTimer()
    {
        TargetTimer -= Time.deltaTime;

        if(TargetTimer < 0)
        {
            TargetTimer = 0;
        }
    }
    public void ResetTargetComponent()
    {
        TargetTimer = enemy.waitSearchTime;
        enemy.MoveController.ZeroVelocityX();
    }
    public void TrackTarget()
    {
        if (Target != null)
        {
            if (transform.position.x > Target.position.x && enemy.MoveController.FacingRight)
            {
                enemy.MoveController.Flip();
            }
            else if(transform.position.x<Target.position.x && !enemy.MoveController.FacingRight)
            {
                enemy.MoveController.Flip();
            }
        }
    }

    // end
}
