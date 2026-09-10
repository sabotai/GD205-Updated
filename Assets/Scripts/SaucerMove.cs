using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerMove : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    float floatExampleFunction(){
      return 5f;
    }


    void FixedUpdate()
    {
      if (Input.GetKey(KeyCode.W)){
        rb.AddForce(0, 0, 1f, ForceMode.Impulse);
      }
        if (Input.GetKey(KeyCode.S)){
          rb.AddForce(0, 0, -1f, ForceMode.Impulse);
        }
          if (Input.GetKey(KeyCode.A)){
            rb.AddForce(-1f, 0, 0, ForceMode.Impulse);
          }
            if (Input.GetKey(KeyCode.D)){
              rb.AddForce(1f, 0, 0, ForceMode.Impulse);
            }
              if (Input.GetKey(KeyCode.Q)){
                rb.AddForce(0, -1f, 0, ForceMode.Impulse);
              }
                if (Input.GetKey(KeyCode.E)){
                  rb.AddForce(0, 1f, 0, ForceMode.Impulse);
                }
      //BRAKE
      //every time FixedUpdate runs and the space bar is pressed, make
      //the velocity 90% of how fast it was before
      if (Input.GetKey(KeyCode.Space)){
        rb.linearVelocity *= 0.9f;
      }
    }


    //OnCollisionEnter gets called by the engine any time a collision
    //happens between this gameObject and another one when one has a rigidbody
    //When it runs, it creates a new Collision object that has all the information
    //about the collision ... aka Aaron the cop takes down all the collision information
    //from when Siul hit Juno on the expressway.
    void OnCollisionEnter(Collision collisionReport){
      //this will tell us where the object we collided with is located
      Debug.Log("collision at " + collisionReport.transform.position);

      //This will destroy the gameObject specified
      //in this case, it's the gameObject we collided with
      Destroy(collisionReport.gameObject);
    }


    //Function Examples
    //when declaring a function, you first specify the type
    //which indicates what the function returns

    //an int function returns an integer
        int intExampleFunction(int myInt){
          return 5;
        }
        int intExampleFunction(){
          return 20;
        }
    //a void function just does whatever is in the code without returning a value
        void voidConsoleMessageExampleFunction(int myInt){
          Debug.Log("function received int of " + myInt);
        }
        void CancelAppointment(int emplID){
          //do the cancellation thing with the emplid
        }
}
