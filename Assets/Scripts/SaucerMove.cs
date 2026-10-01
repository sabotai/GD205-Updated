using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem; //need to add this

public class SubMove : MonoBehaviour
{
    //Rigidbody allows for independent physics movement with the physics engine
    Rigidbody myRb; //create a new local Rigidbody called myRb
    //public Rigidbody publicRb;
    public AudioClip boomClip;
    InputAction moveAction; //an input action to map to the action in the InputSystem Actions
    InputAction brakeAction;
    InputAction lookAction;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //assign our rigidbody to be the component of the type rigidbody
        //attached to the same gameobject as our script
        myRb = GetComponent<Rigidbody>();
      moveAction = InputSystem.actions.FindAction("Move");
      brakeAction = InputSystem.actions.FindAction("Interact");
      lookAction = InputSystem.actions.FindAction("Look");
    }

    //We have to use FixedUpdate to make sure the physics forced aren't linked
    //to our framerate. We would hate for the movement to slow or speed up according to FPS.
    void Update()
    {
      Vector2 rawMove = moveAction.ReadValue<Vector2>();
      Vector3 move = new Vector3(rawMove.x, 0f, rawMove.y);
        
      myRb.AddRelativeForce(move); //add force to our rigidbody in this direction


      Vector2 rawLook = lookAction.ReadValue<Vector2>();
      Vector3 look = new Vector3(-rawLook.y, rawLook.x, 0f);
      transform.Rotate(look);
        
        //create a brake
        if (brakeAction.IsPressed())
        {
          Debug.Log("BRAKE!!");
            myRb.linearVelocity *= 0.99f; //decrease the velocity by 1% each loop
        }

      
    }
    //this function is called whenever this gameobject collides with another one
    //at least one of the objects must have a rigidbody
    void OnCollisionEnter(Collision colReport) //it creates a new Collision object with the info about the collision, similar to the police report when jeremy hit yeyzer
    {
        Debug.Log("collision you died :)"); //a message in the console showing that this is working
        
        //use getcomponent to access the audiosource attached to the same gameobject
        //then access the playoneshot method, which will play an audioclip from the audiosource one time
        //the first parameter is which audioclip
        //the second is the volume percentage represented by a decimal
        GetComponent<AudioSource>().PlayOneShot(boomClip, .95f);
    }
}