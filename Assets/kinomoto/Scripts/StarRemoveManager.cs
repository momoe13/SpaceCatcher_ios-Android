using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRemoveManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem starDestroyParticle;
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
        starDestroyParticle.Play();
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
