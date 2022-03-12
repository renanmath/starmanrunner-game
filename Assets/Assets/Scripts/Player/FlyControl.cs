 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.EventSystems;

     public class FlyControl : MonoBehaviour,IUpdateSelectedHandler,IPointerDownHandler,IPointerUpHandler
     {
         public bool isPressed;
         public int control;
     
         // Start is called before the first frame update
         public void OnUpdateSelected(BaseEventData data)
         {
             if (isPressed)
             {
              
              if(control == 1)
              {
                  MainPlayer.instance.flyUp();
              }

              if(control == 2)
              {
                  MainPlayer.instance.flyDown();
              }

              if(control == 3)
              {
                  MainPlayer.instance.flyLeft();
              }

              if(control == 4)
              {
                  MainPlayer.instance.flyRight();
              }
              
             }
         }
         
         public void OnPointerDown(PointerEventData data)
         {
             isPressed = true;
         }
         
         public void OnPointerUp(PointerEventData data)
         {
             isPressed = false;
         }
     }
     