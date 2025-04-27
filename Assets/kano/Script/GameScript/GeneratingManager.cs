using System.Collections;
using UnityEngine;

public class GeneratingManager : MonoBehaviour
{
    [SerializeField] TargetItem target;

    [SerializeField] GameObject[] star;

    [SerializeField] BoxCollider2D BoxRoof;

   public void Generation()
    {
        for (int i = 0; i < target.PushItem.Length; i++)
        {
            Instantiate(target.PushItem[i], this.transform.position, Quaternion.identity);
            for (int j = 0; j < 4; j++)
            {
                Instantiate(star[i], this.transform.position, Quaternion.identity);
            }

        }
        StartCoroutine(NonColl());
    }

    IEnumerator NonColl()
    {
        BoxRoof.enabled = false;
        yield return new WaitForSeconds(2f);
        BoxRoof.enabled = true;
    }
}
