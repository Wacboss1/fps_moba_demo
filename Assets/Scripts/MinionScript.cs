using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    [SerializeField] float speed = 5;
    CharacterController charC;
    // Start is called before the first frame update
    void Start()
    {
        charC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        charC.Move(transform.forward * speed * Time.deltaTime);
    }
}
