using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRemoveManager : MonoBehaviour
{
    [Header("収束演出")]
    [SerializeField] private ParticleSystem starDestroyParticle1;
    [Header("バースト演出")]
    [SerializeField] private ParticleSystem starDestroyParticle2;
    [Header("拡散演出")]
    [SerializeField] private ParticleSystem starDestroyParticle3;

    private void Update()
    {
        //Kキーを押した際に星のタグが付いたオブジェクトをすべて削除する
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(AllRemoveStar());
        }
    }
    public IEnumerator AllRemoveStar()
    {
        //収束演出
        starDestroyParticle1.Play();
        //バースト演出まで待機
        yield return new WaitForSeconds(0.8f);
        //バースト演出
        starDestroyParticle2.Play();
        yield return new WaitForSeconds(0.3f);
        starDestroyParticle2.Play();
        yield return new WaitForSeconds(0.3f);
        starDestroyParticle2.Play();
        yield return new WaitForSeconds(0.3f);
        //拡散演出
        starDestroyParticle3.Play();

        //拡散演出中の星が見えなくなるタイミングまで待機
        yield return new WaitForSeconds(0.2f);

        //指定したタグ（星）のオブジェクトを配列に入れる
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");

        //配列に入れたオブジェクトを一つずつ繰り返し消している
        foreach (GameObject star in stars)
        {
            Destroy(star);
        }
    }
}
