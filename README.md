# interview_test
# Interaction System + Rest API를 활용하기

## 열기 시 주의사항

- 파일을 열 때 컴파일 에러가 뜨기 때문에 Enter Safe Mode는 Ignore를 누르고 진행하세요.
- Windows에서 파일 열기 시에는 **Build Settings - Target Platform**을 **Windows**로 변경한 다음 진행하세요.
- MacOS에서 프로젝트 다운로드 후 압축파일 해제 후 프로젝트 열기 시 **libburst-llvm-12.dylib** 관련 오류가 뜰 경우 **설정 - 보안 - 일반 - 다음** 탭에서 **다운로드한 앱 허용** 부분에서 아래쪽에 뜨는**’확인 없이 허용’을 눌러주면서 열기를 진행하세요.**
- 오류로 인해 패키지가 누락될 경우 아래의 패키지들을 Package Manager에서 받아서 설치해주세요
    - Cinemachine
    - Input System
    - TextMeshPro
    - Starter Assets - Third Person Character Controller | URP
- 실행은 Scenes 폴더 내에 있는 Playground Scene을 열어서 진행하세요.

1번 동영상 - 1번 문제

https://youtu.be/iBnKtWG46nc

1. 먼저 Scripts - Interaction - InteractableBIM 스크립트를 열어서 OpenPanel() 함수 내에 있는 StartCoroutine(GetBuildingInfo()) 부분을 주석 처리한 후 진행하세요. *하지 않아도 상관없지만 컴파일 오류 때문에 먼저 주석처리를 해야 플레이 할 수 있기 때문에 2번 문제에서부터 활용하시는 게 좋습니다.
2. Scripts - Interaction 폴더에 있는 Interactor 스크립트를 열어서 Update() 함수 내에 있는 주석 처리된 부분을 작성하여 1번 동영상처럼 작동하게 만드세요.
    - 구글링 및 유튜브 서치 후 작성해도 상관없습니다.

---

2번 동영상 - 2번 문제

https://youtu.be/9PwdJMF9O9s

1. InteractableBIM 스크립트를 열어서 주석 처리된 부분에 따라 작성완료 후 2번 동영상처럼 작동하게 만드세요.
    - UnityEngine.Networking 라이브러리에 포함된 UnityWebRequest를 활용하세요.
    - 스크립트 내에 주어진 url + _pk 주소로부터 정보를 가져와서 출력합니다.
    - JSON 데이터를 저장할 클래스를 선언 후 내부에 키 값을 선언해주세요. (JSON to C# Class를 활용하세요)
    - JSON Parsing 라이브러리는 NewtonSoft.Json을 사용하세요. (프로젝트 파일 안에 이미 포함되어 있습니다)
