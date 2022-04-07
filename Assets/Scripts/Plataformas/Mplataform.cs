using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mplataform : MonoBehaviour
{
    public float speed;
    public int StartingPoint;
    public Transform[] points;
    private int i;

    private void Start()
    {
        transform.position = points[StartingPoint].position;
        // Iguala a posi��o inicial da plataforma � posi��o do StartingPoint
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if(i == points.Length)
            {
                i = 0;
            }
        }
        
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    // Verifica se a posi��o da plataforma � igual a posi��o dos pontos, movendo a plataforma de ponto para ponto

}
