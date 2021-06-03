# OCR

### 디자인 
<img src="https://user-images.githubusercontent.com/72601028/120605972-a3a51200-c489-11eb-8632-64815352f9ef.PNG">

### 실행화면 .1
<img src="https://user-images.githubusercontent.com/72601028/120607602-4c07a600-c48b-11eb-951f-a5971cdcd0ec.PNG">

### 실행화면.2
<img src="https://user-images.githubusercontent.com/72601028/120607909-94bf5f00-c48b-11eb-80e0-78dfe6b6ed0c.PNG">

### 디자인 패턴
#### 디자인 패턴은 옵저버 패턴을 사용하였습니다.

##### subject는 mainform이고 opserver는 translate,Table,Ocr입니다.
##### mainform에서의 combobox의 아이템이 바뀔 경우 notify메소드를 통해 알리고
<img src="https://user-images.githubusercontent.com/72601028/120606612-54131600-c48a-11eb-829d-6d0ae40081f0.PNG">

##### opserver의 update메소드를 통해 구독한 객체에게 알려 현재 선택된 인덱스의 정보를 갱신합니다.
<img src="https://user-images.githubusercontent.com/72601028/120606604-51b0bc00-c48a-11eb-9466-417997a0e219.PNG">





