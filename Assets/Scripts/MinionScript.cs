using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionScript : MonoBehaviour
{
    [SerializeField] GameObject destination;
    [SerializeField] float minionDamage = 5;
    private GameObject currentTarget;
    private GameObject mainDestination;
    private NavMeshAgent minionNav;
    private TargetAquisistionScript myTargetAq;

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
            if (!currentTarget.activeSelf)
            {
                destination = mainDestination;
            }else{
                destination = currentTarget;
            }
        }
        minionNav.SetDestination(destination.transform.position);
        // TODO switch currentTarget back to mainTarget kill.
        if ((currentTarget != null) && currentTarget.GetComponent<TargetScript>() != null)
        {
            currentTarget.GetComponent<TargetScript>().TakeDamage(minionDamage);
        } else
        {
            destination = mainDestination;
        }
    }
}
