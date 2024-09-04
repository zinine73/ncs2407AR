using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 씬전환을 위해서는 이게 필요
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI progressText;

    public void OnChangeScene(string value)
    {
        // 간단한 씬 전환에는 LoadScene을 사용
        //SceneManager.LoadScene(value);

        // 시간이 걸리는 씬 전환에는 LoadSceneAsync를 사용
        StartCoroutine(LoadScene(value));
    }

    IEnumerator LoadScene(string value)
    {
        AsyncOperation ao 
        = SceneManager.LoadSceneAsync(value);
        while (!ao.isDone)
        {
            progressText.text 
            = $"Loading : {ao.progress * 100}%";
            yield return null;
        }
    }
}
