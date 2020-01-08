using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] float towerHealth = 100f;

    GameObject currentTarget;
    Transform[] transforms;
    Transform turrent;

    // Start is called before the first frame update
    void Start()
    {
        transforms = this.GetComponentsInChildren<Transform>();
        turrent = transforms[1];
    }


    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(turrent.position, currentTarget.transform.position, Color.red);
    }

    private void OnTriggerStay(Collider other)
    {
        AquireTarget(other);
    }

    private void OnTriggerExit(Collider other)
    {
        UnaquireTarget(other);
    }

    //Stops Targeting when player leaves tower range
    private void UnaquireTarget(Collider other)
    {
        if (other.gameObject == currentTarget)
        {
            currentTarget = null;
        }
    }

    //targets the closet player to the tower center
    private void AquireTarget(Collider other)
    {
        if (currentTarget == null) //targets first person to enter
        {
            currentTarget = other.gameObject;
        }
        else if ((Vector3.Distance(transform.position, other.gameObject.transform.position) < Vector3.Distance(transform.position, currentTarget.transform.position)) && other.gameObject.layer == 9) //targets whoever is closest to the middle of the tower
        {
            currentTarget = other.gameObject;
        }
    }
}
