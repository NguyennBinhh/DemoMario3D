using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClick : MonoBehaviour
{
    [SerializeField] private AudioSource m_Source;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            m_Source.PlayOneShot(m_Source.clip);
        }    
    }
}
