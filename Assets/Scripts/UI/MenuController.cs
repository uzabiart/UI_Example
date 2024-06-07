using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameScripts.UI
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject exitGamePanel;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OpenMenu();
            }
        }

        public void ExitGameButton()
        {
            exitGamePanel.SetActive(true);
        }

        public void NoButton()
        {
            exitGamePanel.SetActive(false);
        }
        
        private void OpenMenu()
        {
            menu.SetActive(!menu.activeSelf);
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}