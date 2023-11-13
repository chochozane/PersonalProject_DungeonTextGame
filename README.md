# 개인과제_스파르타 던전 (Text 게임) 만들기(미완성)

### ✨Things i did :
- ShowGameStartScene() 함수를 만들어 게임 시작 씬 생성.
- 게임 시작 화면(스파르타 마을 입장)_ShowSpartaVill()
  - 원하는 행동의 숫자를 타이핑하면 실행.(→ switch 문 사용)<br>1 ~ 2 이외 입력 시 "잘못된 입력입니다" 출력.
  - ❗ 추가 작업 필요 :
    - 잘못된 입력값을 입력했을 때의 로직 세팅하기

- 상태보기_ShowStatus()
  - 캐릭터 정보는 Character 라는 class 를 만들어 필드값을 설정하고 생성자 활용.
  - GameDataSetting() 함수에 캐릭터 기본 정보 작성.
  - 캐릭터 정보 표시 (w/ Console.WriteLine() & 문자열 보간)
  - 원하는 행동의 숫자를 타이핑하면 실행.(→ switch 문 사용)<br>0 이외 입력 시 "잘못된 입력입니다" 출력.
  - ❗ 추가 작업 필요 :
    - 잘못된 입력값을 입력했을 때의 로직 세팅하기
    - 이후 장착한 아이템에 따라 수치가 변경 될 수 있도록 세팅하기

- 인벤토리_ShowInvent()
  - 우선, 아이템 정보는 Item 이라는 class 를 만들고, 자동 프로퍼티(읽기 전용 속성으로 설정)와 생성자 활용.
  - GameDataSetting() 함수에 아이템 정보 작성.
  - ConsoleTables 패키지를 활용해 인벤토리 레이아웃 고정.
    - ShowItem() 함수를 만들어 table 정보 저장.
  - 원하는 행동의 숫자를 타이핑하면 실행.(→ switch 문 사용)<br>0 ~ 1 이외 입력 시 "잘못된 입력입니다" 출력.
  - ❗ 추가 작업 필요 :
    - 잘못된 입력값을 입력했을 때의 로직 세팅하기
 
- console 창 꾸미기
  - 각 화면의 제목 텍스트 색 입히기
    - color 지정(텍스트) :
      `Console.ForegroundColor = ConsoleColor.colorname;`
    - color 지정(텍스트의 배경) :
      `Console.BackgroundColor = ConsoleColor.colorname;`
    - color 리셋 :
      `Console.ResetColor();`
      
---
### 📌TO-DOs :
- "잘못된 입력입니다" 로직 세팅하기
- 장착 관리 구현하기 (\+ 상태보기와 연동)
  - 장착중인 아이템 앞에는 \[E\] 표시하기
  - 장착관리가 시작되면 아이템 목록 앞에 숫자 표시하기
  - 일치하는 아이템을 선택했다면
    - 장착중이지 않다면 → 장착 & \[E\] 표시 추가
    - 이미 장착중이라면 → 장착 해제 & \[E\] 표시 없애기
  - 일치하는 아이템을 선택했지 않았다면
    - 잘못된 입력입니다 출력
  - 아이템의 중복 장착을 허용
    - 창과 검을 동시에 장착가능
    - 갑옷도 동시에 착용가능
    - 장착 갯수 제한 X
- Table format 을 default 로 설정했을 때 하단에 Count 뜨지 않도록 하기
---
🔥
