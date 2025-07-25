using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingNextScene : MonoBehaviour
{
    public int sceneNumber = 2;
    public Slider loadingSlider;
    public TextMeshProUGUI loadingText;

    void Start()
    {
        StartCoroutine(TransitionNextScene(sceneNumber));
    }

    IEnumerator TransitionNextScene(int num)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(num);

        ao.allowSceneActivation = false; // 로드가 왼료가 되어도 로드 X

        while (!ao.isDone)
        {
            loadingSlider.value = ao.progress;
            loadingText.text = $"{ao.progress * 100f}%";

            if (ao.progress >= 0.9f)
                ao.allowSceneActivation = true;

            yield return null;
        }
    }
}