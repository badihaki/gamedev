using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockade : MonoBehaviour
{
    public float maxShootTime;
    public float shootTimer;
    public GameObject projectile;
    public bool facingRight = true;

    public bool activelyActing = false;
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        maxShootTime = Random.Range(2.2f, 7.5f);
        shootTimer = maxShootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (activelyActing)
        {
            ManageShootTimer();
        }
    }

    private void ManageShootTimer()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else
        {
            if(projectile!=null)
                Shoot();
        }
    }

    private void Shoot()
    {
        GameObject projPrefab = Instantiate(projectile, transform.position, transform.rotation);
        Projectile projScr = projPrefab.GetComponent<Projectile>();
        projScr.tag = "Enemy";
        projScr.facingRight = facingRight;

        shootTimer = maxShootTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && dialogue != null)
        GameObject.Find("Game Master").GetComponent<GM>().DialogueManager.StartDialogue(dialogue);
    }
}
