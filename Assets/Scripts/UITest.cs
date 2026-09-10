using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITest : MonoBehaviour
{
    Dropdown myDrop;
    // Start is called before the first frame update
    void Start()
    {
        myDrop = GetComponent<Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropChoice(){
        SceneManager.LoadScene(myDrop.value);
    }
}
