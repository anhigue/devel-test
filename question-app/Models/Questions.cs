public class Questions {
    private string _name;
    private List<Object> _questions;

    public Questions(string name, List<Object> questions) {
        _name = name;
        _questions = questions;
    }

    public List<Object> QuestionsList {
        get { return _questions; }
        set { _questions = value; }
    }

    public string Name {
        get { return _name; }
        set { _name = value; }
    }
}