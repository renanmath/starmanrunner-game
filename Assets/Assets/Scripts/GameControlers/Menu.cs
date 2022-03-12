using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   
   public GameObject menuScreen;
   public GameObject canvasIcons;
   public GameObject canvasControllers;
   
   public void startGame()
   {
       SceneManager.LoadScene(1);
   }

   public void openMenu()
   {
       menuScreen.SetActive(true);
       GameManeger.instance.changePlayStatus();
       canvasIcons.SetActive(false);
       canvasControllers.SetActive(false);
   }

   public void closeMenu()
   {
       menuScreen.SetActive(false);
       GameManeger.instance.changePlayStatus();
       canvasIcons.SetActive(true);
       canvasControllers.SetActive(true);
   }
}
