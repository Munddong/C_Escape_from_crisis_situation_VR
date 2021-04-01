using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration_Script : MonoBehaviour
{
    public string Ahri = "아리";
    public string Villain = "양아치";
    // public string Police = "경찰";

    //대사//
    //나래이션
    public static string Fir_Player_Narration0 = "여기는 어디지?";
    public static string Fir_Player_Narration1 = "집에 가는 것까지는 기억이 나는데....";
    public static string Fir_Player_Narration2 = "으으...머리가 핑핑도는 느낌이야.";
    public static string Fir_Player_Narration3 = "네...(아까부터 머리가 계속 아프다 약을 달라고 해볼까?)";//1번 선택
    public static string Fir_Player_Narration4 = "(아니야 약을 달라고 하면 뭔가를 요구할 수도 있어.)";

    public static string Fir_Villain_Narration0 = "이제야 깨어났군.";
    public static string Fir_Villain_Narration1 = "미안하게 됐지만 넌 납치당했어.";
    public static string Fir_Villain_Narration2 = "협조만 잘해준다면 더는 안 다치고 풀려날 거야";

    //선택지1-1 호의적(약 요구)
    public static string Sel1_1_Player_Narration0 = "저기요.";
    public static string Sel1_1_Player_Narration1 = "아까부터 너무 머리가 아파요.";
    public static string Sel1_1_Player_Narration2 = "약 좀 주세요.";

    public static string Sel1_1_Villain_Narration0 = "왜.";
    public static string Sel1_1_Villain_Narration1 = "흠... 알겠어.";
    public static string Sel1_1_Villain_Narration2 = "입만 벌리고 있어 내가 먹여줄게.";

    //선택지1-2 적대적(그냥 참음)
    public static string Sel1_2_Player_Narration0 = "아까보다 더 심하게 아픈 것 같아....";
    public static string Sel1_2_Player_Narration1 = "우에엑...";
    public static string Sel1_2_Player_Narration2 = "죄송합니다... 아까부터 머리가 너무 아파서요.";
    public static string Sel1_2_Player_Narration3 = "죄송합니다...";

    public static string Sel1_2_Villain_Narration0 = "갑자기 왜 토를 하는 거야!";
    public static string Sel1_2_Villain_Narration1 = "아 씨...아프면 아프다고 말을 하던가....";
    public static string Sel1_2_Villain_Narration2 = "일만 더 만드는구만...";

    //나래이션_2
    public static string Sec_Player_Narration0 = "(그래도 속이 많이 좋아진 것 같다.)";

    public static string Sec_Villain_Narration0 = "그래서 기분은 좀 어떠냐.";

    //선택지2-1 호의적(호의적인 대답)
    public static string Sel2_1_Player_Narration0 = "많이 좋아졌어요.";
    public static string Sel2_1_Player_Narration1 = "감사합니다.";

    public static string Sel2_1_Villain_Narration0 = "납치당한 사람치고는 꽤 밝구만.";
    public static string Sel2_1_Villain_Narration1 = "생각보다 협조적으로 나오니까 고맙군.";

    //선택지2-2 적대적(적대적인 대답)
    public static string Sel2_2_Player_Narration0 = "납치당했는데 좋을 수가 있겠어요?";
    public static string Sel2_2_Player_Narration1 = "어이가 없어서.";

    public static string Sel2_2_Villain_Narration0 = "하...말하는 거봐라.";
    public static string Sel2_2_Villain_Narration1 = "잘 알아둬 넌 납치당한 거고 네 목숨은 나한테 달렸다.";

    //나래이션_3
    public static string Thr_Player_Narration0 = "하..왜이런 일이 생긴 거야 집에 가고 싶다.";
    public static string Thr_Player_Narration1 = "(헉 어떡하지? 내가 한 말은 들은 건가? 적당히 말을 돌릴까?)";
    public static string Thr_Player_Narration2 = "(아니야 쓸데없는 말을 할 수도 있으니까 적당히 무시하자.)";

    public static string Thr_Villain_Narration0 = "응? 뭐라고 했냐?";

    //선택지3-1 호의적(적당한 대답)
    public static string Sel3_1_Player_Narration0 = "아..그냥요.";
    public static string Sel3_1_Player_Narration1 = "집에서 가족들이 걱정할 거 같아서요.";

    public static string Sel3_1_Villain_Narration0 = "뭐 나도 납치를 좋아서 하는 건 아니니까.";
    public static string Sel3_1_Villain_Narration1 = "사실 최근에 많이 힘들어져서";
    public static string Sel3_1_Villain_Narration2 = "돈만 아니면 나도 이런 선택은 안 하는대.";
    public static string Sel3_1_Villain_Narration3 = "미안하다...";

    //선택지3-2 적대적(무시)
    public static string Sel3_2_Player_Narration0 = ".......";

    public static string Sel3_2_Villain_Narration0 = "하...이젠 말도 무시하는 거냐?";
    public static string Sel3_2_Villain_Narration1 = "이 자식이...하 말을 말자.";

    //나래이션_4
    public static string Fou_Player_Narration0 = "(범인이 전화로 무언가 말하는 소리가 들린다.)";
    public static string Fou_Player_Narration1 = "(내용을 들어보니 협상에 차질이 있는 것 같다.)";
    public static string Fou_Player_Narration2 = "(어떻게 말하는 게 좋을까?)";

    public static string Fou_Villain_Narration0 = "(...)";
    public static string Fou_Villain_Narration1 = "경찰이 네가 안전하단 증거로 통화를 시켜 달랜다.";

    //선택지4-1 호의적(긍정적 대답)
    public static string Sel4_1_Player_Narration0 = "전 잘 있어요.";
    public static string Sel4_1_Player_Narration1 = "범인분도 대해주고 있어요.";
    public static string Sel4_1_Player_Narration2 = "부모님께 너무 걱정 말라고 해주세요.";

    public static string Sel4_1_Villain_Narration0 = "(...)";
    public static string Sel4_1_Villain_Narration1 = "네 덕분에 경찰들과 협상이 잘 끝났다.";
    public static string Sel4_1_Villain_Narration2 = "고맙다. 나도 웬만하면 잘 끝났으면 좋겠다.";

    //선택지4-2 적대적(소리치며 관심을 끈다)
    public static string Sel4_2_Player_Narration0 = "아!!";
    public static string Sel4_2_Player_Narration1 = "살려주세요!";
    public static string Sel4_2_Player_Narration2 = "미친놈이 절 죽이려고 해요.";
    public static string Sel4_2_Player_Narration3 = "퍽!";

    public static string Sel4_2_Villain_Narration0 = "이 자식이!";


    //나래이션_5
    public static string Fif_Player_Narration0 = "꼬르륵~";
    public static string Fif_Player_Narration1 = "(큰일이 지나가서 그런지 갑자기 배가 고프다.)";
    public static string Fif_Player_Narration2 = "(과자를 건네고 있다.)";
    public static string Fif_Player_Narration3 = "(일단 받아먹고 에너지를 보충할까?)";
    public static string Fif_Player_Narration4 = "(아니야 범죄자가 준 건데 무슨 이상한 짓을 할지도 몰라.)";

    public static string Fif_Villain_Narration0 = "?...뭐냐?";
    public static string Fif_Villain_Narration1 = "너도 배고프냐? 왜 이거라도 먹을래?";

    //선택지5-1 호의적(먹는다)
    public static string Sel5_1_Player_Narration0 = "네 사실 많이 배고팠거든요.";

    public static string Sel5_1_Villain_Narration0 = "참...이런 상황에 잘 받아 먹는 구만.";
    public static string Sel5_1_Villain_Narration1 = "별난 건지 대단한 건지.";

    //선택지5-2 적대적(먹지않는다)
    public static string Sel5_2_Player_Narration0 = "아니요. 범죄자가 주는 건 의심스러워서 못 먹겠는데요.";
    public static string Sel5_2_Player_Narration1 = "꼬르륵";
    public static string Sel5_2_Player_Narration2 = "(결국 아무것도 먹지 못했다.)";

    public static string Sel5_2_Villain_Narration0 = "하...나도 너 같은 놈 생각해준 내가 한심스럽다.";
    public static string Sel5_2_Villain_Narration1 = "안 먹겠다는 사람치곤 배에서 요동을 치는구만";
    public static string Sel5_2_Villain_Narration2 = "건방 떨더니 꼴좋다.";

    //마지막 나래이션
    public static string Last_Player_Narration0 = "이때다. 최대한 빨리 탈출해보자.";
    public static string Last_Player_Narration1 = "먼저 복면을 벗고 이 밧줄을 풀어보자.";

    public static string Last_Villain_Narration0 = "난 할 일이 있으니까 꼼짝 말고 있어.";

    //문 나레이션
    public static string Find_Door_Player_Narration0 = "문이다.";
    public static string Find_Door_Player_Narration1 = "열어볼까?";

    public static string Lope_Player_Narration0 = "일단, 이 로프부터 풀자.";

    public static string Door_Open_Player_Narration0 = "방금 주운 칼을 이용해보자";
    public static string Door_Open_Player_Narration1 = "(딸깍딸깍)";
    public static string Door_Open_Player_Narration2 = "열렸다!";

    public static string Cannot_Open_Player_Narration0 = "문이 잠겨있다.";
    public static string Cannot_Open_Player_Narration1 = "문을 열 만한 도구가 필요하다.";

    public static string Stay_Player_Narration0 = "좀 더 둘러보자.";

    //범인 문 나레이션
    public static string Vill_Door_Player_Narration0 = "문이다.";
    public static string Vill_Door_Player_Narration1 = "음?";
    public static string Vill_Door_Player_Narration2 = "인기척이 있어 범인이 있는게 분명해.";

    //칼 나레이션
    public static string Get_Knife_Player_Narration0 = "칼이 다 어서 밧줄을 자르자.";
    public static string Get_Knife_Player_Narration1 = "(서걱서걱)";
    public static string Get_Knife_Player_Narration2 = "휴... 다 잘랐으니까 여기가 어딘지 확인 좀 하보자.";

    public static string JGet_Knife_Player_Narration0 = "칼이다.";
    public static string JGet_Knife_Player_Narration1 = "(달그락)";
    public static string JGet_Knife_Player_Narration2 = "쓸모 있을지 모르지만 챙겨보자.";

    //기름 나레이션
    public static string Get_Oil_Player_Narration0 = "기름으로 손을 빼자";
    public static string Get_Oil_Player_Narration1 = "(미끌미끌)";
    public static string Get_Oil_Player_Narration2 = "휴...일단 로프는 풀었다.";

    public static string Unuse_Oil_Player_Narration0 = "기름이네?";
    public static string Unuse_Oil_Player_Narration1 = "무겁기만 하고 필요 없어 보인다.";

    //기차 소리 나레이션
    public static string Train_Sound_Player_Narration0 = "(철컹철컹...철컹철컹...)";
    public static string Train_Sound_Player_Narration1 = "이게 무슨 소리지?";
    public static string Train_Sound_Player_Narration2 = "잘 들어보니 커다란 기차가 움직이는 소리가 들린다.";
    public static string Train_Sound_Player_Narration3 = "여긴 철로 근처인가보다.";

    //종이 나레이션
    public static string Paper_Player_Narration0 = "쓰레기가 잔뜩 모여있다.";
    public static string Paper_Player_Narration1 = "뭔가 쓸모 있는 게있을 수도 있어.";
    public static string Paper_Player_Narration2 = "(부스럭...)";
    public static string Paper_Player_Narration3 = "응? 이건 뭐지?";
    public static string Paper_Player_Narration4 = "오래된 전단지 같아 보인다.";
    public static string Paper_Player_Narration5 = "가족 같은 한림 .... 흠 많이 지워져 있네.";
    public static string Paper_Player_Narration6 = ".....교동.....16번지";
    public static string Paper_Player_Narration7 = "아...아쉽지만 그 뒤에 주소가 있는 부분은 찟어져 있다.";

    public static string Can_not_Paper_Player_Narration0 = "쓰레기가 많이 모여있다.";
    public static string Can_not_Paper_Player_Narration1 = "일단 이 줄부터 풀고 보자.";

    //폰 나레이션
    public static string Phone_Player_Narration0 = "앗! 저건!";
    public static string Phone_Player_Narration1 = "스마트폰이다.";
    public static string Phone_Player_Narration2 = "드디어 연락할 수 있겠다!!";
    public static string Phone_Player_Narration3 = "잠깐 아까 있던 곳 근처에 쓰레기가 모여있던 곳이 있던데?";
    public static string Phone_Player_Narration4 = "위치를 알만한 정보가 있을 수도 있어 다녀와 볼까?";

    public static string Calling_Player_Narration0 = "이미 전화는 했으니까 어서 가까운 문으로 가자.";

    public static string Call_Cop_Narration0 = " 아니야, 이미 충분한 정보를 모은 거 같다.";
    public static string Call_Cop_Narration1 = "어서 전화하자.";

    public static string Dont_Cop_Narration0 = "그래, 아직 전화를 하긴 이른 거 같아.";

    //전화_나레이션_1(장소)
    public static string Say_Where1_Player_Narration0 = "앗 받았다.";
    public static string Say_Where1_Player_Narration1 = "제발 도와주세요. 지금 납치당했어요.";
    public static string Say_Where1_Player_Narration2 = "네 알겠습니다.";

    public static string Say_Where1_Cop_Narration0 = "네 경찰서입니다.";
    public static string Say_Where1_Cop_Narration1 = "일단 침착하시고 물어보는 거에 정확하게 대답해주세요.";
    public static string Say_Where1_Cop_Narration2 = "혹시 지금 어떤 곳에 감금되어있으세요?";

    //1-1(폐공장)
    public static string Say_1_1_Narration0 = "공장...지금 폐공장에 있어요.";
    public static string Say_1_1_Narration1 = "네 지금 폐공장이에요.";

    public static string Say_1_1_Cop_Narration0 = "네 그럼 지금 공장에 있다는 거죠?";

    //1-2(폐가)
    public static string Say_1_2_Narration0 = "주택...오래되고 허름한 주택같아요.";
    public static string Say_1_2_Narration1 = "네 폐가에요.";

    public static string Say_1_2_Cop_Narration0 = "네 그럼 지금 폐가에 있다는 거죠?";

    //1-3(폐병원)
    public static string Say_1_3_Narration0 = "공사중인 병원같아요.";
    public static string Say_1_3_Narration1 = "네 병원에요.";

    public static string Say_1_3_Cop_Narration0 = "네 그럼 지금 병원에 있다는 거죠?";

    //전화_나레이션_2(주소)
    public static string Say_Where2_Player_Narration0 = "어.......";
    public static string Say_Where2_Player_Narration1 = "여기는요.....";

    public static string Say_Where2_Cop_Narration0 = "혹시 주소를 알만한 것은 없나요?";

    //2-1(검암동)
    public static string Say_2_1_Narration0 = "아마 검암동 근처인 거 같아요.";
    public static string Say_2_1_Narration1 = "네 검암동 근처에요.";

    public static string Say_2_1_Cop_Narration0 = "검암동 근처라는 거죠?";

    //2-2(교동)
    public static string Say_2_2_Narration0 = "아마 교동 근처인 거 같아요.";
    public static string Say_2_2_Narration1 = "네 교동 근처에요.";

    public static string Say_2_2_Cop_Narration0 = "교동 근처라는 거죠?";

    //2-3(장기동)
    public static string Say_2_3_Narration0 = "아마 장기동 근처인 거 같아요.";
    public static string Say_2_3_Narration1 = "네 장기동 근처에요.";

    public static string Say_2_3_Cop_Narration0 = "장기동 근처라는 거죠?";

    //전화_나레이션_3(특징)
    public static string Say_Where3_Player_Narration0 = "음.....잠시만요.";

    public static string Say_Where3_Cop_Narration0 = "마지막으로 근처에 알만한 특징이 있나요?";

    //2-1(철도)
    public static string Say_3_1_Narration0 = "아! 맞다. 기차 소리! 기차 소리가 났어요.";
    public static string Say_3_1_Narration1 = "네 아마 철도 옆인 거 같아요.";

    public static string Say_3_1_Cop_Narration0 = "기차 소리요?";

    //2-2(고속도로)
    public static string Say_3_2_Narration0 = "아! 맞다. 비행기 소리! 비행기 소리가 났어요.";
    public static string Say_3_2_Narration1 = "네 아마 비행장 옆인 거 같아요.";

    public static string Say_3_2_Cop_Narration0 = "비행기 소리요?";

    //2-3(항구)
    public static string Say_3_3_Narration0 = "아! 맞다. 뱃소리! 뱃고동 소리가 났어요.";
    public static string Say_3_3_Narration1 = "네 아마 항구 옆인 거 같아요.";

    public static string Say_3_3_Cop_Narration0 = "뱃고동 소리요?";

    //전화_나레이션_4(출발)
    public static string Say_go_Player_Narration0 = "네 감사합니다. 정말 감사합니다.";
    public static string Say_go_Player_Narration1 = "이제 문 옆으로 가야겠다.";

    public static string Say_go_Cop_Narration0 = "네 협조 감사합니다. 지금 바로 경찰을 보내겠습니다.";

    //결말_나레이션(경찰등장)
    public static string Game_End_Player_Narration0 = "휴 겨우다 신고했다.";
    public static string Game_End_Player_Narration1 = "헉 들킨 건가? 어떡하지.";
    public static string Game_End_Player_Narration2 = "(이제 이렇게 죽는 건가 ㅠㅠ)";
    public static string Game_End_Player_Narration3 = "(경찰이다!)";
    public static string Game_End_Player_Narration4 = "(위험하니까 피할까? 아니면 엎드릴까?)";

    public static string Game_End_Villain_Narration0 = "야! 너 뭐하는 거야!";
    public static string Game_End_Villain_Narration1 = "이 자식이 미쳤나!";
    public static string Game_End_Villain_Narration2 = "뭐!! 뭐야!!";

    public static string Game_End_Cop_Narration0 = "꼼짝마! 경찰이다.";

    //결말_나레이션(서있기)
    public static string Stand_Up_Player_Narration0 = "모..모르겠다 일단 피하자!";
    public static string Stand_Up_Player_Narration1 = "억!";

    public static string Stand_Up_Cop_Narration0 = "꼼짝마! (범인은 2인조인 건가?)";
    public static string Stand_Up_Cop_Narration1 = "탕! 탕!";

    public static string Stand_Up_Villain_Narration1 = "윽!";

    public static string Stand_Up_news_Narration0 = "얼마 전에 납치되었던 학생 -모 씨가 구출 중 사고로 사망했습니다.";
    public static string Stand_Up_news_Narration1 = "현장에서의 갑작스러운 행동으로 오인사격을 받은 거로 추측됩니다.";

    //결말_나레이션(엎드린다)
    public static string Stand_Down_Player_Narration0 = "빨리 엎드리자!";

    public static string Stand_Down_Cop_Narration0 = "꼼짝마!";
    public static string Stand_Down_Cop_Narration1 = "탕! 탕!";

    public static string Stand_Down_Villain_Narration1 = "윽!";

    public static string Stand_Down_news_Narration0 = "얼마 전에 납치되었던 학생 -모 씨가 안전하게 구조되었습니다.";
    public static string Stand_Down_news_Narration1 = "납치 중에 뛰어난 기지로 경찰을 유도하여 구출되었습니다.";


    //게임오버_나레이션
    public static string Game_Over_Player_Narration0 = "헉!";
    public static string Game_Over_Player_Narration1 = "으으...죄..죄송합니다.";
    public static string Game_Over_Player_Narration2 = "사.....살려주세요.";
    public static string Game_Over_Player_Narration3 = "으아아악!";

    public static string Game_Over_Villain_Narration0 = "야!";
    public static string Game_Over_Villain_Narration1 = "이 자식이 감히 탈출 시도를 해?";
    public static string Game_Over_Villain_Narration2 = "안 되겠다. 내 얼굴을 본 이상 살려둘 수 없다.";
    public static string Game_Over_Villain_Narration3 = "잘가라.";

    public static string Game_Over_news_Narration0 = "얼마 전에 납치되었던 학생 -모 씨가 결국 숨진 채 발견되었습니다.";
    public static string Game_Over_news_Narration1 = "정황상 탈출을 시도하던 중에 사망한 것으로 보입니다.";

    //타임오버_나레이션
    public static string Time_Over_Player_Narration0 = "헉!";
    public static string Time_Over_Player_Narration1 = "드...들켰다.";
    public static string Time_Over_Player_Narration2 = "헉! 숨어야 하는데...(부스럭)";
    public static string Time_Over_Player_Narration3 = "사.....살려주세요.";

    public static string Time_Over_Villain_Narration0 = "뭐야!";
    public static string Time_Over_Villain_Narration1 = "이자식이 어디로 간거지?";
    public static string Time_Over_Villain_Narration2 = "응? 거기 있었구만!";

    public static string Time_Over_news_Narration0 = "얼마 전에 납치되었던 학생 -모 씨가 결국 숨진 채 발견되었습니다.";
    public static string Time_Over_news_Narration1 = "정황상 탈출을 시도하던 중에 사망한 것으로 보입니다.";

    public string[] narration;
    public string[] Quest;
    public string[] Alarm;
    public string[] ship;
    public string[] shipFail;

    public bool inputAllowed = true;
    public bool handtower = false;
    public int fireOff = 0;

    //! ToolBar
    [HideInInspector]
    public int toolbarTab, toolbarTab2;
    [HideInInspector]
    public string currentTab;

    /*
    //-----------------------------------------------------------------------------------------
    // 싱글턴 인스턴스에 접근하기 위한 C# 프로퍼티
    // get 접근자만 가지는 읽기 전용의 프로퍼티
    public static Narration_Script Instance
    {
        // private 변수 instance의 참조를 반환한다
        get
        {
            return instance;
        }
    }
    //------------------------------------------------------------------------------------------
    private static Narration_Script instance = null;
    //------------------------------------------------------------------------------------------
 
    void Awake()
    {
        //Application.targetFrameRate = 60;
 
        // --------------------------------- 싱글턴 -------------------------------------
        // 씬에 이미 인스턴스가 존재하는지 검사한다
        // 존재하는 경우 이 인스턴스는 소멸시킨다
        if (instance)
        {
            DestroyImmediate(gameObject);
 
            return; // return은 메소드 중간에 호출되어 메소드를 종결시킨다.. 따라서 Awake()를 완전히 빠져나온다.
        }
 
        // 이 인스턴스를 유효한 유일 오브젝트로 만든다
        instance = this;

        // 게임 매니저가 지속되도록 한다
        //DontDestroyOnLoad(gameObject);
        //--------------------------------------------------------------------------------
 
    }
    */
}