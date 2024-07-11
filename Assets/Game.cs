using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI tmp;
    [SerializeField] private TextMeshProUGUI clicker;
    [SerializeField] private TextMeshProUGUI handler;
    [SerializeField] private GameObject abler;
    [SerializeField] private GameObject spacetoplay;
    [SerializeField] private GameObject pannel;
    private float clicks;
    private bool isGamming;
    // Start is called before the first frame update
    void Start()
    {
        spacetoplay.SetActive(true);
        pannel.SetActive(false);
        abler.SetActive(false);
        clicks = 0;
        isGamming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isGamming)
        {
            spacetoplay.SetActive(false);
            pannel.SetActive(false);
            abler.SetActive(true);
            StartCoroutine(Timer());
            
        }
    }

    IEnumerator Timer()
    {
        isGamming = true;
        clicks = 0;
        for (float i = PlayerPrefs.GetInt("ClickMode"); i > 0 ; i-=Time.deltaTime)
        {
            clicker.text = clicks.ToString();
            tmp.text = ((int)i).ToString();
            yield return null;
        }
        Upload();
    }

    private void Upload()
    {
        if (clicks/(PlayerPrefs.GetInt("ClickMode")-1) > PlayerPrefs.GetFloat("Highest"))
        {
            PlayerPrefs.SetFloat("Highest",clicks/(PlayerPrefs.GetInt("ClickMode")-1));
            StartCoroutine(OnSuccessFlow());
        }
        else
        {
            StartCoroutine(OnFailFlow());
        }
    }

    IEnumerator OnSuccessFlow()
    {
        pannel.SetActive(true);
        handler.text = "당신의 cps(" + clicks/(PlayerPrefs.GetInt("ClickMode")-1) + ")는 최고기록에 도달하여 최고기록이 갱신됩니다!";
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }

    IEnumerator OnFailFlow()
    {
        pannel.SetActive(true);
        handler.text = "당신의 cps(" + clicks/(PlayerPrefs.GetInt("ClickMode")-1) + ")는 최고기록에 도달하지 못했습니다..";
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(0);
    }
    public void Click()
    {
        if (isGamming)
        {
            clicks++;
        }
    }
}
