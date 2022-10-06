using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NathanHoward
{
    public class TitleScreen : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
