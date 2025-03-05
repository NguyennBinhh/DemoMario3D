using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public static InputManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject); /// Huỷ gameobj khi đã tồn tại 1 đối tượng khác

    }

    public bool EscKeyDown()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }    

}
