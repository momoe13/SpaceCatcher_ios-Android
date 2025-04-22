using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public enum State
    {
        ZERO,
        ONE,
        TWO,
        THREE,
        FOUR,
        BURST,
    }
    private State state;
    [SerializeField] private GameObject powerErea;
    [Header("ゲージが上がる値")]
    [SerializeField] private float[] craneLevelUpValue;
    [SerializeField] private GameObject[] gaugeAry;

    private void Start()
    {
        StartCoroutine(StateChange());
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    GaugeReset();
        //}
    }

    private IEnumerator StateChange()
    {
        while (true)
        {
            switch (state)
            {
                case State.ZERO:
                    //craneLevelUpValueの配列にあるState番目の値より、クレーンの吸引力が大きい場合ゲージが一つ上がる
                    //forceMagnitudeの値はマイナスが大きければ大きいほど吸引力が強い
                    if(powerErea.GetComponent<PointEffector2D>().forceMagnitude > craneLevelUpValue[(int)State.ZERO]) { break; }
                    //一段階目
                    gaugeAry[(int)State.ZERO].gameObject.SetActive(true);
                    state = State.ONE;
                    break;
                case State.ONE:
                    if (powerErea.GetComponent<PointEffector2D>().forceMagnitude > craneLevelUpValue[(int)State.ONE]) { break; }
                    //二段階目
                    gaugeAry[(int)State.ONE].gameObject.SetActive(true);
                    state = State.TWO;
                    break;
                case State.TWO:
                    if (powerErea.GetComponent<PointEffector2D>().forceMagnitude > craneLevelUpValue[(int)State.TWO]) { break; }
                    //三段階目
                    gaugeAry[(int)State.TWO].gameObject.SetActive(true);
                    state = State.THREE;
                    break;
                case State.THREE:
                    if (powerErea.GetComponent<PointEffector2D>().forceMagnitude > craneLevelUpValue[(int)State.THREE]) { break; }
                    //四段階目
                    gaugeAry[(int)State.THREE].gameObject.SetActive(true);
                    state = State.FOUR;
                    break;
                case State.FOUR:
                    if (powerErea.GetComponent<PointEffector2D>().forceMagnitude > craneLevelUpValue[(int)State.FOUR]) { break; }
                    //上限突破
                    gaugeAry[(int) State.FOUR].gameObject.SetActive(true);
                    state = State.BURST;
                    break;
            }
            yield return null;
        }
    }

    public void GaugeReset()
    {
        foreach (var gauge in gaugeAry)
        {
            gauge.SetActive(false);
        }
        state = State.ZERO;
    }
}
