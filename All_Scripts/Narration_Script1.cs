using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration_Script1 : MonoBehaviour
{
    //챕터1 - 시작
    public static string player1 = "으음... 보일러도 안틀었는데 왜 이렇게 덥지...?";   
    public static string bed1 = "더워서 다시 잠을 잘 수가 없다.";
    public static string phone1 = "몇 시인지 확인해볼까?";
    public static string phone1_1 = "충전해놓는걸 까먹어 폰이 켜지지 않는다...";
    public static string switch1 = "불이 안켜지네...왜 이럴까?";
    public static string closet1 = "지금 굳이 열어볼 필요는 없다.";
    public static string door1 = "문 앞에 스자 덥다 못해 뜨거운 기운이 느껴진다.";
    public static string door1_1 = "열어볼까...?";

    //챕터2 - 방문 열기
    public static string player2 = "문고리가 너무 뜨거운데 어떻게 열고 나가지...";
    public static string bed2 = "이불로 문고리를 잡으면 되겠다!";
    public static string closet2 = "옷으로 문고리를 잡으면 되겠다!";
    public static string others2 = "딱히 도움이 될만한건 보이지 않는다.";

    //챕터3 - 방문이 열린 후 선택지
    public static string player3 = "거실에 화재가 났다. 어떻게 하면 좋지...?";
    public static string player3_1 = "누군가 보고 신고해줬겠지? 그냥 방 안에서 구조나 기다리자.";//선택지1 골랐을시
    public static string player3_2 = "구조대를 기다리기엔 시간이 없을 것 같아. 탈출 방법을 찾아보자.";//선택지2
    public static string player3_3 = "잠깐만 참으면 나갈 수 있을 것 같은데... 가보자!";//선택지3

    //챕터4 - 선택지2
    public static string player4 = "연기 때문에 그냥 나가면 안될 것 같아...";
    public static string player4_1 = "방에서 도움이 될만한 것들을 찾아보자!";
    public static string closet4 = "옷으로 문을 열고 나가면 되겠다!";
    public static string closet4_1 = "우선 화장실이 있는 옆방으로 가보자.";
    public static string water = "물이 조금 남아있다.";
    public static string water_1 = "물로 옷을 적셔서 입을 막고 나가자!";//옷장을 보고 난 후 물병을 보면

    //챕터5 - 방2 & 화장실
    public static string closet5 = "열쇠가 들어있다. 가져가자.";
    public static string others5 = "딱히 도움이 될만한 건 없어 보인다.";
    public static string shower5 = "...!! 다행히 물은 나온다";
    public static string player5 = "아까 발코니 쪽 불길이 약하던데...";
    public static string player5_1 = "그쪽을 지나갈 방법이 있을까?";
    public static string towel5 = "수건으로 뭘 할 수 있을까...";
    public static string bed5 = "이불을 물에 적신 뒤";//샤워기를 본 뒤
    public static string bed5_1 = "불길을 지나갈 수 있지 않을까?...";//샤워기를 본 뒤

    //챕터6 - 발코니
    public static string bicycle6 = "자전거가 묶여있다.";
    public static string lock6 = "열쇠로 자물쇠를 풀었다.";
    public static string lock6_1 = "열쇠구멍이 있다.";
    public static string warning6 = "경량칸막이라고...?";
    public static string warning6_1 = "부술 수 있을 것 같다.";


}