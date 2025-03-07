using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
   
    
    public void ShowFrm(GameObject gameObject)
    {
        gameObject.SetActive(true);  
    }

    public void HideFrm(GameObject gameObject)
    {
         gameObject.SetActive(false);
    }

    public void LoadSenceHome()
    {
        SceneManager.LoadScene("WhiteScreen");
    }    
    
}
