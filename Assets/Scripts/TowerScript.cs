using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] float towerDamage = 5;
    [SerializeField] float attackper = 1;
    private GameObject currentTarget;
    private Transform[] transforms;
    private Transform turrent;
    private TargetScript myTargetScript;
    private TargetScript.Team myTeam;
    private TargetAquisistionScript myTargetAq;

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
        if (currentTarget)
        {
            print(this.name + " Target is " + currentTarget.name);
        }
        if (myTargetAq.getCurrentTarget() != null) 
        {
            /*
             * Whenever an enemy is target by the tower
             *  the towers sheilds will go down and the tower will deal damage to that things
             *  
             *  once the sheilds are down the tower can be targeted from outside tower range
             */
            myTargetScript.setImmune(false);
            StartCoroutine(shootAndRecharge());
            StopCoroutine(shootAndRecharge());
        } else {
            //otherwise the tower is immune to damage 
            myTargetScript.setImmune(true);
        }
    }

    IEnumerator shootAndRecharge()
    {
        //print("attacking @ " + Time.time);
        yield return new WaitForSeconds(attackper);
        myTargetAq.getCurrentTarget().GetComponent<TargetScript>().TakeDamage(towerDamage);
        //print("ready to attack @" + Time.time);
    }
}
