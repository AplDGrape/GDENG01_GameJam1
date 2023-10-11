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

    // Start is called before the first frame update
    void Start()
    {
        fScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fScore = Mathf.Abs(animator.GetFloat("Speed"));
        scoreTextValue.text = fScore.ToString();
    }
}
