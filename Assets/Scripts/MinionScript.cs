using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionScript : MonoBehaviour
{
    [SerializeField] GameObject destination;
    [SerializeField] float minionDamage = 5;
    private GameObject currentTarget;
    private NavMeshAgent minionNav;
    private TargetAquisistionScript myTargetAq;

    // Start is called before the first frame update
    void Start()
    {
        minionNav = GetComponent<NavMeshAgent>();
        myTargetAq = GetComponent<TargetAquisistionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myTargetAq.getCurrentTarget())
        {
            currentTarget = myTargetAq.getCurrentTarget();
        }
        minionNav.SetDestination(destination.transform.position);
        if (currentTarget)
        {
            currentTarget.GetComponent<TargetScript>().TakeDamage(minionDamage);
        }
    }
}
