using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private float fScore;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private TMP_Text scoreTextValue;
    [SerializeField] private Animator animator;
    [SerializeField] private ScoreManager scoreManager;

    private bool bPlaying;

    // Start is called before the first frame update
    void Start()
    {
        fScore = 0;
        bPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        while(bPlaying == true) {
            fScore = Mathf.Abs(animator.GetFloat("Speed"));
        }
        scoreTextValue.text = fScore.ToString();
    }

    //call this when pausing or ending the level
    public void StopScoring() {
        bPlaying = false;
        scoreManager.addScore(new Score(fScore));
    }
}
