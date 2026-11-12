using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class BasicNav : MonoBehaviour
{
    InputAction cursorAction;
    InputAction clickAction;
    NavMeshAgent myAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        myAgent = GetComponent<NavMeshAgent>();
        cursorAction = InputSystem.actions.FindAction("Point");
        clickAction = InputSystem.actions.FindAction("Attack");
    }
 // Update is called once per frame
    void FixedUpdate()
  {
      
      Ray laser = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());

      RaycastHit laserImpactReport = new RaycastHit();

      if (Physics.Raycast(laser, out laserImpactReport)){

        if (clickAction.IsPressed()){

            myAgent.SetDestination(laserImpactReport.point);
        }
      }
    
    }

}
