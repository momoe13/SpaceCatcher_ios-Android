using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRemoveManager : MonoBehaviour
{
    [Header("バースト演出")]
    [SerializeField] private ParticleSystem starDestroyParticle2;
    [Header("消去演出")]
    [SerializeField] private ParticleSystem starDestroyParticle4;

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

        starDestroyParticle2.Play();
        yield return new WaitForSeconds(0.4f);

        //指定したタグ（星）のオブジェクトを配列に入れる
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");

        AudioManager.Instance.StarRemoveSEPlay();

        //配列に入れたオブジェクトを一つずつ繰り返し消している
        foreach (GameObject star in stars)
        {
            Destroy(Instantiate(starDestroyParticle4, star.transform.position, Quaternion.identity), starDestroyParticle4.main.startLifetime.constant);//消去演出を再生し、1秒後に削除
            Destroy(star);
        }
    }
}
