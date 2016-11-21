using UnityEngine;

public delegate void SelectedChangedDelegate(bool selected);

public class Data
{
    //visus
    public string itemEthnieString;
    public string itemBodyString;
    public string itemHandicapString;
    public string itemGenderString;
    public string itemSexualityString;
    //description ecite
    public Player.ethnie itemEthnie;
    public Player.body itemBody;
    public bool itemHandicap;
    public bool itemGender;
    public bool itemSexuality;

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
