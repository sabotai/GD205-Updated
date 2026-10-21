using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //need to add this

public class ScottSummersLaser : MonoBehaviour
{
    public float explosionForce = 18f;
    public float explosionRadius = 39f;
    InputAction clickAction;
    InputAction cursorAction;
    // Start is called before the first frame update
    void Start()
    {

      clickAction = InputSystem.actions.FindAction("Attack");
      cursorAction = InputSystem.actions.FindAction("Point");
    }

    // Update is called once per frame
    void Update()
    {

      Ray laser = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());

      RaycastHit laserImpactReport = new RaycastHit();

      if (Physics.Raycast(laser, out laserImpactReport)){

      if (clickAction.IsPressed()){
          //Destroy(laserImpactReport.transform.gameObject);
          Debug.Log("BLASTED THAT WORKS! OH WAIT");
          laserImpactReport.rigidbody.AddExplosionForce(explosionForce,laserImpactReport.point,explosionRadius);
        } 
      }


    }
}
