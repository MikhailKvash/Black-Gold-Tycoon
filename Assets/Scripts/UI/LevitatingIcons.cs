using UnityEngine;

public class Levitation : MonoBehaviour
{
    public float amplitude = 0.2f; // амплитуда движения вверх и вниз
    public float frequency = 1f; // частота колебаний
    public float phaseShift = 0f; // фазовый сдвиг для начала колебаний

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // рассчитываем новую позицию на основе времени и заданных параметров
        float y = initialPosition.y + amplitude * Mathf.Sin(2f * Mathf.PI * frequency * Time.time + phaseShift);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}