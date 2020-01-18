using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] float towerDamage = 5;

    GameObject currentTarget;
    Transform[] transforms;
    Transform turrent;
    TargetScript myTargetScript;
    TargetScript.team myTeam;
    TargetAquisistionScript myTargetAq;

    // Start is called before the first frame update
    void Start()
    {
        myTargetScript = this.GetComponent<TargetScript>();
        myTeam = myTargetScript.getTeam();

        transforms = this.GetComponentsInChildren<Transform>();
        turrent = transforms[1];

        myTargetAq = GetComponent<TargetAquisistionScript>();
    }


    // Update is called once per frame
    void Update()
    {
        currentTarget = myTargetAq.getCurrentTarget();
        if(currentTarget)
        {
            currentTarget.GetComponent<TargetScript>().TakeDamage(towerDamage);
        }
    }

    //TODO determine if tower force feilds should be a thing
}
