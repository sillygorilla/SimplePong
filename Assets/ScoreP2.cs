using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreP2 : MonoBehaviour
{
    public static int ScoreP2Value = 0;
    TextMeshProUGUI scorep2;
    void Start()
    {
        scorep2 = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scorep2.text = ScoreP2Value.ToString();
        
    }
}
