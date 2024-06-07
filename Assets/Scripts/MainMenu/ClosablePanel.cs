using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.MainMenu
{
    public class ClosablePanel : MonoBehaviour
    {
        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }   
}
