**인게임에 기능이 추가됨에 따라 쓸모 없어졌습니다**

# Geometry Dash Borderless Fullscreen

WinAPI를 사용하여 지메를 테두리 없는 전체화면으로 만들어주는 2% 부족한 프로그램입니다.
This is a 2% lacking program that uses WinAPI to make Geometry Dash borderless full screen.

## 적용 방법 (How to apply)

1. 지메 실행
2. 전체화면 끄기
3. 프로그램 실행
4. 끝!

참고: 지메 ㅈ망겜이라 그 어떤 짓을 해도 제 실력으로는 비율을 완전히 16:9로 만들지 못했습니다.  

---

1. Run Geometry Dash
2. Turn off full screen
3. Run program
4. End!

Note: Geometry Dash is a shit game, so I tried a lot, but I can't make the ratio completely 16:9 with my skills.

## 작동 원리 (How it Works)

1. 모든 프로세스 목록을 구한 후, 'GeometryDash'라는 이름을 가진 프로세스를 찾습니다. (Process.GetProcesses())
2. 가져온 프로세스의 메인 창의 핸들을 구합니다. (Process.MainWindowHandle)
3. user32.dll 함수를 사용하여 가져온 창의 핸들의 속성 값을 변경합니다 (SetWindowLongPtrA())
4. 적용한 속성을 창에 적용시킵니다 (SetWindowPos())

---

1. After getting a list of all processes, find the process with the name ‘GeometryDash’. (Process. GetProcesses())
2. Obtain the handle of the main window of the imported process. (Process. MainWindowHandle)
3. Change the property value of the handle of the imported window using the user32.dll function (SetWindowLongPtrA())
4. Apply the applied properties to the window (SetWindowPos())