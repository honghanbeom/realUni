using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static partial class GFunc 
{
    // static���� ����ϴ� �Լ�
    // ����


    // ��ó������ �̸� (������ �ɺ�)
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    // �̷��� ĥ �� ���� �ٿ��ֱ�� �ϴ°��� ����(�����Ѵٰ� ���� ġ������!)
    [System.Diagnostics.Conditional("DEBUG_MODE")]

    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject�� �޾Ƽ� Text ������Ʈ ã�Ƽ� text �ʵ� �� �����ϴ� �Լ�
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }

        textComponent.text = text;

    }

    // LoadScene �Լ� ����
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ���� ���� �̸��� �����Ѵ�.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;    
    }

    // �� ���͸� ���ϴ� �Լ�
    // this, origin ��� �Լ� Ȯ���� �ڿ� ������ ������
    public static Vector2 AddVector(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    
    }


    // Print LogWarning when debug_mode
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }

    // valid component check
    public static bool isValid<T>(this T target) where T : Component // this�� generic
    {
        if (target == null || target == default) { return false; }
        else { return true; }

    }

    // valid list component check
    public static bool isValid<T>(this List<T> target) where T : Component // ���� where
    {
        bool isInvaild = (target == null || target == default);
        isInvaild = isInvaild || target.Count == 0;

        if (isInvaild == true) { return false; }
        else { return true; }

        //List<int> intList;
        //Debug.LogFormat("intList�� ��ȿ����? {0}", intList.isValid());

    }



}
