using UnityEngine;

public delegate void SelectedChangedDelegate(bool selected);

public class Data
{
    public string itemEthnie;
    public string itemBody;
    public string itemHandicap;
    public string itemGender;
    public string itemSexuality;
    public Texture itemTexture;

    public SelectedChangedDelegate selectedChanged;
    private bool _selected;
    public bool Selected
    {
        get { return _selected; }
        set
        {
            if (_selected != value)
            {
                _selected = value;
                if (selectedChanged != null) selectedChanged(_selected);
            }
        }
    }

    private string _spritePath;
    public string SpritePath
    {
        get { return _spritePath; }
        set
        {
            _spritePath = value;
            Sprite = Resources.Load<Sprite>(_spritePath);
        }
    }
    public Sprite Sprite { get; private set; }
}
