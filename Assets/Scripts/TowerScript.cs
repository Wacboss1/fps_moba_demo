using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] float towerDamage = 5;
    [SerializeField] bool immune = true;

    GameObject currentTarget;
    Transform[] transforms;
    Transform turrent;
    TargetScript myTargetScript;
    TargetScript.Team myTeam;
    TargetAquisistionScript myTargetAq;

    /*
    *Towers will have a sheild that goes down whenever an enemy enters the tower range
     */

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
        if(myTargetAq.getCurrentTarget())
        {
            /*
             * Whenever an enemy is target by the tower
             *  the towers sheilds will go down and the tower will deal damage to that things
             */
            myTargetScript.setImmune(false);
            myTargetAq.getCurrentTarget().GetComponent<TargetScript>().TakeDamage(towerDamage);
        }
        else
        {
            //otherwise the tower is immune to damage 
            myTargetScript.setImmune(true);
        }
    }


}
