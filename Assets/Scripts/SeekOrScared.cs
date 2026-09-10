using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekOrScared : MonoBehaviour
{
    Rigidbody rb; //declare a new rigidbody in our script to manipulate
    public Transform target; //declare a new public transform for our object to seek or run away from

    //public float so we can change it in the inspector ... positive values move toward the target, negative away
    public float forceMultiplier = 2f; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //assign this rigidbody to the one attached to the same gameobject
    }

    // Fixed Update is called at standardized intervals
    void FixedUpdate()
    {
        //to find the direction, we subtract our position from our destination position, which gives us the distance/offet for each axis (x, y, z)
        //and then normalize that, which turns it in terms of -1 to 1, which is how directions are referenced
        Vector3 targetOffset = target.position - transform.position;
        Vector3 targetDirection = Vector3.Normalize(targetOffset); //Vector3.Normalize will convert a regular Vector3 into a direction
        //we then use addforce on our rigidbody in the direction we just calculated and multiply it by our multiplier float
        rb.AddForce(targetDirection * forceMultiplier);

        //shorthand way of doing all of the above
        //rb.AddForce(Vector3.Normalize(target.position - transform.position));
    }
}
