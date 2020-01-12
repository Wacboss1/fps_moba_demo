using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionScript : MonoBehaviour
{
    [SerializeField] GameObject destination;
    [SerializeField] float speed = 5;
    NavMeshAgent minionNav;
    // Start is called before the first frame update
    void Start()
    {
        minionNav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        minionNav.SetDestination(destination.transform.position);
    }
}
