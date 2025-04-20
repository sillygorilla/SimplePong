
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int PointsP1 = 0;
    public int PointsP2 = 0;

    public TextMeshProUGUI PointsTexts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RestartMatch();
        }
    }
    public void IncreaseP1Points()
    {
        PointsP1 += 1;
        UpdatePoints();

    }
    public void IncreaseP2Points()
    {
        PointsP2 +=1;
        UpdatePoints();

    }

    public void UpdatePoints()
    {
        PointsTexts.text = PointsP1 + "-" + PointsP2;
    }
    private void RestartMatch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}   

