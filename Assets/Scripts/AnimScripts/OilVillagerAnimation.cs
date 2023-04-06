using UnityEngine;

public class OilVillagerAnimation : MonoBehaviour
{
    public GameObject objectToShow;  // объект, который нужно показать/скрыть
    public bool box;

    private Animator anim;  // компонент аниматора
    private Vector3 lastPosition;  // последняя позиция игрока

    public bool Box
    {
        get => box;
        set => box = value;
    }

    void Start()
    {
        anim = GetComponent<Animator>();  // получаем компонент аниматора у игрока
        lastPosition = transform.position;  // запоминаем текущую позицию игрока
    }

    void Update()
    {
        // проверяем, двигается ли игрок с коробкой
        if (transform.position != lastPosition && box)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Box", true);  // включаем анимацию ходьбы

            if (objectToShow != null)
            {
                // если объект задан, показываем его
                objectToShow.SetActive(true);
            }
        }
        // проверяем, двигется ли игрок без коробки
        if (transform.position != lastPosition && !box)
        {
            anim.SetBool("Walk", true);  // включаем анимацию ходьбы
            anim.SetBool("Box", false);

            if (objectToShow != null)
            {
                // если объект задан, показываем его
                objectToShow.SetActive(false);
            }
        }
        // проверяем, стоит ли игрок
        if (transform.position == lastPosition)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Box", false);  // включаем анимацию простоя

            if (objectToShow != null)
            {
                // если объект задан, скрываем его
                objectToShow.SetActive(false);
            }
        }

        lastPosition = transform.position;  // запоминаем текущую позицию игрока для сравнения в следующем кадре
    }
}
