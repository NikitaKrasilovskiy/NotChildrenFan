using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
    public int leftRightLadder;
    private GameObject ladderHero;
    public GameObject LadderHero { get { return ladderHero; } set { ladderHero = value; } }
    private GameObject ladderForreGround;
    public GameObject LadderForreGround { get { return ladderForreGround; } set { ladderForreGround = value; } }
    private GameObject ladderHero_02;
    public GameObject LadderHero_02 { get { return ladderHero_02; } set { ladderHero_02 = value; } }

    private void Start()
    {
        ladderHero = transform.Find("LadderHero").gameObject;
        ladderHero_02 = transform.Find("LadderHero_02").gameObject;
        ladderForreGround = transform.Find("LadderForeground").gameObject;
    }

    public void LadderStart()
    {
        ladderHero.SetActive(true);
        ladderForreGround.SetActive(false);
    }

    public void LadderFinish()
    {
        ladderHero.SetActive(false);
        ladderForreGround.SetActive(true);
    }
}
