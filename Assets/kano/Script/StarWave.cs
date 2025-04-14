using Unity.VisualScripting;
using UnityEngine;

public class StarWave : MonoBehaviour
{
    [SerializeField] GameObject Star;
    float[] timing ={ 3.5f,5.5f,11f,13f};
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

        if (time > 14f) { time = 0; 
            return; }
        if (time >= timing[num]) 
        {

            Generation();
            num++;
            if(num == timing.Length) { num = 0; }
            
        }
    }

    private void Generation()
    {
        float x = Random.Range(-5,6);
        float y = Random.Range(0,3);

        Vector3 Pos = new Vector3(x,y,0);
       Instantiate(Star,Pos, Quaternion.identity);
     }
}
