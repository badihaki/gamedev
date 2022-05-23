using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public Health Health { get; private set; }
    public FXHolder FX { get; private set; }
    public Animator Anim { get; private set; }
    public EnemyMoveScript MoveController { get; private set; }

    // Stats
    #region Stats
    [Header("stats")]
    [SerializeField] float speedMin;
    [SerializeField] float speedMax;
    public float speed;
    public int attack;
    public float waitSearchTime;
    [SerializeField] float distMin;
    [SerializeField] float distMax;
    public float desiredDistanceToPlayer;
    #endregion
    //

    public EnemyTarget Target { get; private set; }

    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyIdleState IdleState { get; private set; }
    public EnemyChaseState ChaseState { get; private set; }
    public EnemySearchState SearchState { get; private set; }
    

    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<Health>();
        FX = GetComponent<FXHolder>();
        Target = GetComponent<EnemyTarget>();
        Anim = GetComponent<Animator>();
        SetStats();

        MoveController = GetComponent<EnemyMoveScript>();

        StateMachineInit();
    }

    private void SetStats()
    {
        desiredDistanceToPlayer = UnityEngine.Random.Range(distMin, distMax);
        speed = UnityEngine.Random.Range(speedMin, speedMax);
    }

    private void StateMachineInit()
    {
        StateMachine = new EnemyStateMachine();
        IdleState = new EnemyIdleState(this, StateMachine, "idle");
        ChaseState = new EnemyChaseState(this, StateMachine, "move");
        SearchState = new EnemySearchState(this, StateMachine, "move");

        StateMachine.Initialize(IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    public void Damage(int dmg, int direction, Vector2 pushBack)
    {
        Health.TakeHealth(dmg);
        Instantiate(FX.hitEffect, transform.position, transform.rotation);

        if (Health.CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    #region Grounded
    [SerializeField] LayerMask groundLayers;
    [SerializeField] float extraHeightDistance;
    [SerializeField] CapsuleCollider2D boundary;
    public bool Grounded()
    {
        RaycastHit2D rayHit = Physics2D.BoxCast(boundary.bounds.center, boundary.bounds.size, 0.0f, Vector2.down, extraHeightDistance, groundLayers);

        Color rayColor;

        if (rayHit.collider != null) // if we have something below us
            rayColor = Color.cyan;
        else // we aren't hitting shit
            rayColor = Color.red;

        Debug.DrawRay(boundary.bounds.center + new Vector3(boundary.bounds.extents.x, 0), Vector2.down * (boundary.bounds.extents.y + extraHeightDistance), rayColor);
        Debug.DrawRay(boundary.bounds.center - new Vector3(boundary.bounds.extents.x, 0), Vector2.down * (boundary.bounds.extents.y + extraHeightDistance), rayColor);
        Debug.DrawRay(boundary.bounds.center - new Vector3(boundary.bounds.extents.x, boundary.bounds.extents.y + extraHeightDistance), Vector2.right * (boundary.bounds.extents.x), rayColor);
        return rayHit.collider != null;
    }
    #endregion

}
