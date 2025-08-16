using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonTransition : MonoBehaviour
{
    public void SceneChange(string _loadSceneName)
    {
        SoundManager.Instance.PlaySE(SESource.ButtonClick);
        SceneManager.LoadScene(_loadSceneName);
    }
}
