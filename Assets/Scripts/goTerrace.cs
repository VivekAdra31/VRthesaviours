using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class goTerrace : MonoBehaviour
{
    public UnityEvent onGazeClick;
    public Image ButtonImage;
    public float GazeTriggerTime = 1f;

    private bool isLoading = false;
    private float counter;
    public UnityEvent move;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isLoading)
        {
            counter += Time.deltaTime;
            ButtonImage.fillAmount = counter / GazeTriggerTime;
            if (ButtonImage.fillAmount == 1)
            {
                SceneManager.LoadScene("Scenes/terrace");
            }
            if (counter > GazeTriggerTime)
            {
                onGazeClick.Invoke();
                isLoading = false;
            }
        }
        /*if (ButtonImage.fillAmount == 1)
        {
            SceneManager.LoadScene(sceneName: "scene2");
        }*/
    }
    //public void WhiteColour()
    //{
    //    ButtonImage.color = Color.white;
    //}
    //public void RedColour()
    //{
    //    ButtonImage.color = Color.red;
    //}

    public void OnGazeEnter()
    {
        isLoading = true;
    }

    public void OnGazeExit()
    {
        isLoading = false;
        ButtonImage.fillAmount = 0;
        counter = 0;
    }
}

