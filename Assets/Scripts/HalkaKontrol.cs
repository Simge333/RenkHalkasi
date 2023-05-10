using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalkaKontrol : MonoBehaviour
{
    public float donmeHizi;
    public bool soladon = true;

    
    private void FixedUpdate()
    {
        if (soladon)//sol
        {
            transform.Rotate(0f, 0f, donmeHizi * Time.deltaTime);
        }
        else//sağ
        {
            transform.Rotate(0f, 0f, -donmeHizi * Time.deltaTime);
        }
        
    }
   
}
