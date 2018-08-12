using UnityEngine;

public abstract class Tooltip<Todisplay> : MonoBehaviour
{
    public void show(Todisplay thing)
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        _update(thing);
    }

    protected abstract void _update(Todisplay thing);

    public void hide()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        //gameObject.SetActive(false);
    }

    private void Awake()
    {
        //hide();
    }
}