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
        persons.Add("ö��", new PersonData(10, "ö��",150,10));
        persons.Add("����", new PersonData(10, "����", 150, 10));
        persons.Add("����", new PersonData(10, "����", 150, 10));
    }
}