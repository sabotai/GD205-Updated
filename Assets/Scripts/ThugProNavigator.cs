using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class ThugProNavigator : MonoBehaviour
{
    InputAction cursorAction;
    InputAction clickAction;
    NavMeshAgent DvaAgent;
  public Transform target;
  public Transform cursorPreview;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        DvaAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        cursorAction = InputSystem.actions.FindAction("Point");
        clickAction = InputSystem.actions.FindAction("Attack");
    }
    // Update is called once per frame
    void Update()
  {
      
      cursorPreview.position = new Vector3(-9999f,0f,0f);
        //transform.LookAt(target); //example for scott
        //DvaAgent.SetDestination(target.position);
      if (DvaAgent.remainingDistance > 0.5f){
        anim.SetFloat("Run", 1);
      } else {
        anim.SetFloat("Run", 0);
      }

      Ray laser = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());

      RaycastHit laserImpactReport = new RaycastHit();

      if (Physics.Raycast(laser, out laserImpactReport)){
      cursorPreview.gameObject.GetComponent<Renderer>().material.color += new Color(.005f, .005f, .005f, .005f);
      cursorPreview.position = laserImpactReport.point;

        if (clickAction.IsPressed()){

            cursorPreview.gameObject.GetComponent<Renderer>().material.color = Color.black;
            DvaAgent.SetDestination(laserImpactReport.point);
        }
      }
    
    }

    void OnTriggerStay(Collider col){
      if (col.tag == "breakable" && Input.GetKeyDown(KeyCode.E)){
        Debug.Log("trigger is running and destroying " + col.gameObject.name);
        Destroy(col.gameObject);
      }
    }
}
