using UnityEngine;

public class CardControl : MonoBehaviour
{
    [SerializeField] private readonly float swingSpeed;
    private CardView cardLogic;
    private Vector3 offset;
    private Vector3 defaultPosition;
    private float zRotation;
    private bool isCardDragging = false;
    private bool isChoiceLeft;

    public void Start()
    {
        defaultPosition = transform.position;
        cardLogic = GetComponentInParent<CardView>();
    }

    public void Update()
    {
        if (!isCardDragging)
            ReturnToDefaultPosition();
    }

    public void OnMouseDown()
    {
        isCardDragging = true;

        offset = transform.position - 
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    public void OnMouseUp()
    {
        isCardDragging = false;

        if (Mathf.Abs(zRotation) >= 7.5f)
        {
            cardLogic.ConfirmChoice(isChoiceLeft);
        }
    }

    public void OnMouseDrag()
    {
        zRotation = SetDirectionOfRotation(Mathf.Abs(transform.position.x * 6.5f));

        transform.rotation = Quaternion.Lerp(
            transform.rotation, 
            Quaternion.Euler(transform.position.x, transform.position.y, zRotation), 
            Time.deltaTime * swingSpeed
        );
        transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Input.mousePosition.x, 
                Input.mousePosition.y, 
                10f
                )
            ) + offset;
        
        cardLogic.UpdateVisibility(zRotation / 4);
    }

    private void ReturnToDefaultPosition()
    {
        transform.position = Vector3.Lerp(transform.position, defaultPosition, Time.deltaTime * 6);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), Time.deltaTime * 6);
        cardLogic.UpdateVisibility(0);
    }

    private float SetDirectionOfRotation(float rotation)
    {
        if (transform.position.x <= 0)
        {
            isChoiceLeft = true;
        }
        else
        {
            isChoiceLeft = false;
        }

        return transform.position.x <= 0 ? rotation : rotation * -1;;
    }

    public void RandomPick()
    {
        cardLogic.ConfirmChoice(Random.value > 0.5f);
    }
}