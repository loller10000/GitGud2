using UnityEngine;

public class Selectionarrow : MonoBehaviour
{
    [SerializeField] private RectTransform[] options;
    private RectTransform rect;
    private int currentPosition;
    [SerializeField] private AudioClip change;
    [SerializeField] private AudioClip interact;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) &&!Input.GetKeyDown(KeyCode.UpArrow))
                ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.DownArrow))
                ChangePosition(1);
    }

    private void ChangePosition(int _change)
    {
        currentPosition += _change;

        if (_change != 0)
            SoundManager.instance.PlaySound(change);

        if (currentPosition < 0)
            currentPosition = options.Length - 1;
        else if (currentPosition > options.Length - 1)
            currentPosition = 0;

        rect.position = new Vector3(rect.position.x, options[currentPosition].position.y, 0);
    }
}
