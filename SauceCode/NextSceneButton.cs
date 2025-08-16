using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextSceneButton : ButtonTransition
{
    private Button nextSceneButton;
    private string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneButton = GetComponent<Button>();
        nextSceneButton.onClick.AddListener(OnButtonClick);

        nextSceneName = SceneManager.GetActiveScene().name;
        nextSceneName.Replace("Stage", "");
        int _sceneNum = int.Parse(nextSceneName);
        _sceneNum++;
        nextSceneName = $"Stage{_sceneNum}";
    }
    /// <summary>
    /// ボタンをクリックしたら
    /// </summary>
    private void OnButtonClick()
    {
        SceneChange(nextSceneName);
    }
}
