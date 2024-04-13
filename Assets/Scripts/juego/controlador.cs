using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador : MonoBehaviour
{
    public Sprite s1;
   void Update()
   {
       if (Input.GetMouseButtonDown(0))
       {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = s1;
        spriteRenderer.enabled = true;
       }
   }
}