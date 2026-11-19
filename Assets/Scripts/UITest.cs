using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
//using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    TMP_Dropdown myDrop;
    public TMP_Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        myDrop = GetComponent<TMP_Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = Time.time.ToString();
    }

    public void DropChoice(){
        SceneManager.LoadScene(myDrop.value);
    }
}
