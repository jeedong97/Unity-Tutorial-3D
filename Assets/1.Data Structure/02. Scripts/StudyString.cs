using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "Hello World";
    public string[] str2 = new string[3] { "Hello", "Unity", "World" };
    private void Start()
    {
        Debug.Log(str1.Contains('H'));
        Debug.Log(str1.Contains('h'));

        Debug.Log(str1.Contains("Hello"));
        Debug.Log(str1.ToUpper()); ; // �빮�� ��ȯ
        Debug.Log(str1.ToLower()); ; // �ҹ��� ��ȯ

        str1 = str1.Replace("World", "Unity");
        Debug.Log(str1);
    }
}
