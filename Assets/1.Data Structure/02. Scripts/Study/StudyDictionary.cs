using System.Collections.Generic;
using UnityEngine;

public class PersonData
{
    public int age;
    public string name;
    public float height;
    public float weight;

    public PersonData(int _age, string _name, float _height, float _weight)
    {
        this.age = _age;
        this.name = _name;
        this.height = _height;
        this.weight = _weight;
    }
}
public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData> ();

    private void Start()
    {
        persons.Add("Ã¶¼ö", new PersonData(10, "Ã¶¼ö",150,10));
        persons.Add("¿µÈñ", new PersonData(10, "¿µÈñ", 150, 10));
        persons.Add("µ¿¼ö", new PersonData(10, "µ¿¼ö", 150, 10));
    }
}