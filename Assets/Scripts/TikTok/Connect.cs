using TMPro;
using UnityEngine;
using System.Threading.Tasks;

public class Connect : MonoBehaviour
{
    public static Connect Instance;
   

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        
    }
  
}
