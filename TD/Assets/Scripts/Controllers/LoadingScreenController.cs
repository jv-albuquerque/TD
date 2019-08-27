using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
    // This is used to pass the feeling of a real game to the player
    // It isn't required, If You dont whant to use, you must go to the Load scene and un mark the useDelay
    [Header("Player Experience")]
    [SerializeField] private bool useDelay = true;
    [SerializeField] private float delayToLoad = 2f;

    // Slider used to see the progress of the loading
    [Header("Load Bar Properties")]
    [SerializeField] private GameObject sliderObj = null;
    [SerializeField] private Slider slider = null;

    private ImportantDatas datas = null;

    private bool alreadyCalledLoadingScreen = false;

    private Cooldown delayCD;

    AsyncOperation async;

    private void Awake()
    {
        Time.timeScale = 1f; //Need this if the scene comes from a pause

        datas = GameObject.FindGameObjectWithTag("Datas").GetComponent<ImportantDatas>();      

        if(!useDelay) // if don't want to force a loading
            StartCoroutine(LoadingScreen());
        else
        {
            //start the cooldown timer randomly, to pass the feel it is real
            delayCD = new Cooldown(Random.Range(0.1f , delayToLoad)); 
            delayCD.Start();
        }
    }

    private void Update()
    {
        if(useDelay)
            if(!delayCD.IsFinished)
            {
                slider.value = (delayCD.Percent/100)*(3f/4f); // it will fill three-quarter of the bar
            }
            else if(!alreadyCalledLoadingScreen)
            {
                alreadyCalledLoadingScreen = true; //make this call singleton
                StartCoroutine(LoadingScreen());
            }
    }

    IEnumerator LoadingScreen()
    {
        sliderObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(datas.NextScene);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            if (!useDelay)
                slider.value = async.progress;
            else
                slider.value = async.progress/2 + 0.75f;

            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
