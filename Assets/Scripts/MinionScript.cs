using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionScript : MonoBehaviour
{
    [SerializeField] GameObject destination;
    [SerializeField] float minionDamage = 5;
    [SerializeField] float attackper = 1;
    private GameObject currentTarget;
    private GameObject mainDestination;
    private NavMeshAgent minionNav;
    private TargetAquisistionScript myTargetAq;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        minionNav = GetComponent<NavMeshAgent>();
        myTargetAq = GetComponent<TargetAquisistionScript>();
        mainDestination = destination;

    }

    // Update is called once per frame
    void Update()
    {
        if (myTargetAq.getCurrentTarget())
        {
            currentTarget = myTargetAq.getCurrentTarget();
            if (currentTarget.GetComponent<TargetScript>())
            {
                if (currentTarget.GetComponent<TargetScript>().checkDead())
                {
                    destination = mainDestination;
                } else {
                    destination = currentTarget;
                }
            }
        }
        minionNav.SetDestination(destination.transform.position);
        // TODO switch currentTarget back to mainTarget kill.
        if ((currentTarget != null) && currentTarget.GetComponent<TargetScript>() != null && !attacking)
        {
            StartCoroutine(attack());
            attacking = true;
        } else
        {
            destination = mainDestination;
        }
    }
    // TODO get the minions to focus each other then attack the next tower
    private IEnumerator attack()
    {
        currentTarget.GetComponent<TargetScript>().TakeDamage(minionDamage);
        yield return new WaitForSeconds(attackper);
        attacking = false;
    }
}
