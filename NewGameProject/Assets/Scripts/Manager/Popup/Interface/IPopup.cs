using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPopup
{
    PopupType Type { get; }
    
    /// <summary>
    /// 팝업을 열기전 각 텍스트 등을 초기화 하는 함수
    /// </summary>
    /// <param name="titleText">제목</param>
    /// <param name="contentText">내용</param>
    /// <param name="okBtnText">확인 버튼의 글자를 변경해야 할 시 사용 가능(OK, Yes 등등)</param>
    /// <param name="cancelBtnText">취소 버튼의 글자를 변경해야 할 시 사용 가능(Cancel, No 등등)</param>
    /// <param name="closePopupFunc">팝업을 닫을때 닫는 것 외에 따로 할일이 있으면 사용</param>
    public void SetPopup(string titleText, string contentText, string okBtnText = "OK", string cancelBtnText = "Cancel", Action okFunc = null);
    public void Open();
    public void Close();
}
