using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private ButtonConnect _ButtonConnect;

    private void Awake()
    {
        _ButtonConnect = gameObject.GetComponent<ButtonConnect>();
    }
    public void ShowFrm(GameObject gameObject)
    {
        gameObject.SetActive(true);
        
    }

    public void HideFrm(GameObject gameObject)
    {
        _ButtonConnect.ResetTextFrmLogin();
        gameObject.SetActive(false);
    }

    
}
