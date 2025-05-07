using Unity.VisualScripting;
using UnityEngine;

public class StarWave : MonoBehaviour
{
    [SerializeField] GameObject Star;
    //readonly float[] timing ={ 3.5f,5.5f,11f,13f,18.5f,20.5f,26f,28f,29.5f};
    readonly float[] timing = { 2.5f, 4.5f, 10f, 12f, 17.5f, 19.5f, 25f, 27f, 28.5f };
    float time;
    int num;

    private void Start()
    {
        time = 0;
        num = 0;
    }
    private void Update()
    {
        time += Time.deltaTime;

        if (time >= timing[num]) 
        {

            Generation();
            num++;
            if(num == timing.Length) { 
                num = 0;
                time = 0;
            }
            
        }
    }

    private void Generation()
    {
        float x = Random.Range(-3,6);
        float y = Random.Range(2,3);

        Vector3 Pos = new Vector3(x,y,0);
       Instantiate(Star,Pos, Quaternion.identity);
     }
}
