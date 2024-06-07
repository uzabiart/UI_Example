using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject creditsPanel;

        public void openSettingsPanel()
        {
            settingsPanel.SetActive(true);
        }

        public void OpenCreditsPanel()
        {
            creditsPanel.SetActive(true);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        
        
    }   
}
