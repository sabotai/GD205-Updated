using UnityEngine;

public class HighlightPath : MonoBehaviour
{
    public Transform gridParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gridParent.childCount; i++)
        {
            if (transform.position - new Vector3(0f, 1f, 0f) == gridParent.GetChild(i).position)
            {
                Debug.Log("over this one");
                gridParent.GetChild(i).gameObject.GetComponent<Renderer>().material.color += new Color (0.003f, 0f, 0f, 0f);
                
            }

        }
    }
}
