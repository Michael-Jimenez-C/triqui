using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class celda : MonoBehaviour
{
    public Sprite s1;
    public Sprite s2;
    public int state;
    public bool active = true;

    public GameObject master;
   void Start(){
    state = 0;
   }
   void Update(){
   }

   void OnMouseDown(){
        if (active){
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = (master.GetComponent<controlador>().current_player ==1)? s1:s2;
            spriteRenderer.enabled = true;
            state += master.GetComponent<controlador>().current_player;
            active = false;
            master.GetComponent<controlador>().Change();
        }
   }

}