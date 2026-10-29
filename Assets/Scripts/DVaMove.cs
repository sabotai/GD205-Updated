using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DVaMove : MonoBehaviour
{
    InputAction doAction;
    InputAction jumpAction;
    InputAction moveAction;
    // Start is called before the first frame update
    void Start()
    {
        
      doAction = InputSystem.actions.FindAction("Interact");
      jumpAction = InputSystem.actions.FindAction("Jump");
      moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<NavMeshAgent>().SetDestination(target.position);
        GetComponent<Animator>().SetInteger("Jump", 0); //default to 0
        GetComponent<Animator>().SetBool("Action", false); 

        GetComponent<Animator>().SetFloat("Run", moveAction.ReadValue<Vector2>().y);
        Debug.Log(moveAction.ReadValue<Vector2>().y);

        // if (moveAction.ReadValue<Vector2>().y > 0f){
            
        // } else if (moveAction.ReadValue<Vector2>().y < 0f){

        //     GetComponent<Animator>().SetInteger("Run", -1); //do walk value for parameter


        // }
        if (doAction.IsPressed()){
            
            GetComponent<Animator>().SetBool("Action", true); 
        }

        if (jumpAction.WasPressedThisFrame()){ //if run key in addition to walk key

            GetComponent<Animator>().SetInteger("Jump", 1); //do run value for parameter
        }
        
    
    }
}
