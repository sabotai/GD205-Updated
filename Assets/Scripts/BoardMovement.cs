using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //need to add this

public class BoardMovement : MonoBehaviour
{
    public Transform myHazard;
    public Transform[] myHazards; //we declare an array of transforms which we will determine the size of in the inspector

    //public int myInt = 5;
    Vector3 startPos;

    public AudioClip impact;
    AudioSource audioSource; 
    
    InputAction moveAction; //an input action to map to the action in the InputSystem Actions

    // Start is called before the first frame update
    void Start()
    {
      startPos = transform.position;
      audioSource = GetComponent<AudioSource>();
      moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 rawMove = moveAction.ReadValue<Vector2>();
      Vector3 move = new Vector3(rawMove.x, 0f, rawMove.y);

      if (moveAction.WasPressedThisFrame()){
      //if (moveAction.IsPressed()){
        transform.position += move;
      }
/*
      //if (condition == true) { do the thing; }
      //in this case, if the GetKeyDown() method of the Input class is true
      //using this argument
        if (Input.GetKeyDown(KeyCode.A)) {
          //modify the position property of the transform of the same game object this script is attached to
          //add an offset of 1 unit on the x axis
          //transform.position += new Vector3(-1f,0f,0f);
          transform.position += Vector3.left;
        }
          if (Input.GetKeyDown(KeyCode.D)) {
            transform.position += Vector3.right;
          }
          if (Input.GetKeyDown(KeyCode.W)) {
            transform.position += Vector3.forward;
          }
          if (Input.GetKeyDown(KeyCode.S)) {
            transform.position += Vector3.back;
          }
*/
        //example for using one hazard
        // if (transform.position == myHazard.position){
        //   Debug.Log("BOOM");
        //   transform.position = startPos;
        // }

        //using a loop to run through each position in our array
        //for (declaration and assignment; a condition to determine whether it should run each time; an update to our variable following each run);
        for (int howManyTimesLoopHasRun = 0; howManyTimesLoopHasRun < myHazards.Length; howManyTimesLoopHasRun++){

          //we are checking if the position of the same transform as this gameobject is the same as each of our hazards
          //to check each position in the array, we specify the position inside the square brackets
          //by using the variable we created, it will run through each position in the array
          if (transform.position == myHazards[howManyTimesLoopHasRun].position){
            transform.position = startPos;
            audioSource.PlayOneShot(impact, 0.7F);
          }
        }
        //basic for loop example
        for (int howManyTimesLoopHasRun = 0; howManyTimesLoopHasRun < 5; howManyTimesLoopHasRun++){
          Debug.Log("howManyTimesLoopHasRun = " + howManyTimesLoopHasRun);
        }

    }
}
