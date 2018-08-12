using UnityEngine;

public abstract class Tooltip<Todisplay> : MonoBehaviour
{
    public void show(Todisplay thing)
    {
        gameObject.SetActive(true);
        _update(thing);
    }

    protected abstract void _update(Todisplay thing);

    public void hide()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        //hide();
    }
}