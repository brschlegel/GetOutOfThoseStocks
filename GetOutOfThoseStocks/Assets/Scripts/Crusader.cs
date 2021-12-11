using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusader : ReynoldsAgent
{
    public List<Guard> Guards;
    public Guard target;
    public GameManager manager;
    public float attackRadius = 1.0f;
    public float attackDamage = 1.0f;
    public bool attackActive = true;
    // Start is called before the first frame update
    void Start()
    {
        Guards = manager.guards;
        SetNewTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null)
        {
            if(Vector3.Distance(target.transform.position, transform.position) < attackRadius)
            {
                if(attackActive)
                {
                    target.locked = true;
                    Debug.Log("Attack");
                    target.health -= attackDamage;
                    target.hb.SetScale(target.health, target.maxHealth);
                    StartCoroutine(WaitForAttackCooldown());
                }
          
            }
            else 
            {
                MoveToTarget(target.transform);
            }

        }
        if(target == null && Guards.Count > 0)
        {
            SetNewTarget();
        }
    }

    public void SetNewTarget()
    {
        Guard closest = null;
        float dist = float.PositiveInfinity;
        foreach(Guard guard in Guards)
        {
            if(dist > Vector3.Distance(transform.position, guard.transform.position))
            {
                closest = guard;
                dist = Vector3.Distance(transform.position, guard.transform.position);
            }
        }
        target = closest;
    }

    IEnumerator WaitForAttackCooldown(float cooldown = 1.0f)
    {
        attackActive = false;
        yield return new WaitForSeconds(cooldown);
        attackActive = true;
    }
}
