using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class DVaMove : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<NavMeshAgent>().SetDestination(target.position);
        GetComponent<Animator>().SetFloat("Forward", 0f); //default to 0
        if (Input.GetKey(KeyCode.W)){ //if walk key pressed
            
            GetComponent<Animator>().SetFloat("Forward", 2f); //do walk value for parameter

            if (Input.GetKey(KeyCode.LeftShift)){ //if run key in addition to walk key

            GetComponent<Animator>().SetFloat("Forward", 4f); //do run value for parameter
            }
        } 
    
    }
}
