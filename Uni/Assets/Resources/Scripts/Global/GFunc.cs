using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static partial class GFunc 
{
    // static으로 사용하는 함수
    // 랩핑

    // 전처리기의 이름 (디파인 심볼)
    [System.Diagnostics.Conditional("DEBUG_MODE")]

    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    // 이런거 칠 때 복사 붙여넣기로 하는것이 좋음(연습한다고 따라 치지말기!)
    [System.Diagnostics.Conditional("DEBUG_MODE")]

    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject를 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }

        textComponent.text = text;

    }

    // LoadScene 함수 래핑
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 두 벡터를 더하는 함수
    // this, origin 모든 함수 확장자 뒤에 나오기 시작함
    public static Vector2 AddVector(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    
    }

}
