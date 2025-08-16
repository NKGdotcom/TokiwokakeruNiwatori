using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : ButtonTransition
{
    private Button retryButton;
    private string nowSceneName;
    // Start is called before the first frame update
    void Start()
    {
        retryButton = GetComponent<Button>();
        retryButton.onClick.AddListener(OnButtonClick);

        nowSceneName = SceneManager.GetActiveScene().name;
    }
    /// <summary>
    /// ボタンをクリックしたら
    /// </summary>
    private void OnButtonClick()
    {
        SceneChange(nowSceneName);
    }
}
