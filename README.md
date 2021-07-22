# Week5_Unity

## Ch.7 3D Game

### Bamsongi

#### 7.1 게임 설계하기

##### 7.1.1 게임 기획하기

- 화면을 탭 한 부분을 향해 밤송이가 날아가고, 과녁에 닿으면 달라붙고 이펙트 표시

  

##### 7.1.2 게임 리소스 생각하기

1. 화면에 놓일 오브젝트 모두 나열
   - 밤송이, 과녁, 나무, 지면
2. 오브젝트를 움직일 수 있는 컨트롤러 스크립트
   - 밤송이 컨트롤러
3. 오브젝트를 자동으로 생성할 수 있도록 제너레이터 스크립트
   - 밤송이 제너레이터
4. UI를 갱신할 수 있도록 감독 스크립트
   - UI나 씬이 변경되지 않으므로 필요 없음
5. 스크립트 만드는 흐름
   - 밤송이 컨트롤러 : 화면을 탭하면 탭한 장소를 향해 밤송이가 날아간다. 밤송이가 과녁에 닿으면 닿은 장면에서 멈추고 눈송이 파티클을 표시
   - 밤송이 제너레이터 : 화면을 탭할 때마다 밤송이를 하나씩 생성하는 기능을 구현.



#### 7.2 프로젝트와 씬 만들기

##### 7.2.1 프로젝트 만들기

- File -> New Project -> 3D -> (Bamsongi)

- 프로젝트에 리소스 추가

  - bamsongi.fbx, target.fbx

- 실행할 때 화면 표시 설정

  - VSync 체크

    

##### 7.2.2 스마트폰용으로 설정하기

- Platform -> iOS/Android 선택
- 화면 크기 설정 -> 대상 스마트폰의 화면 크기에 맞는 크기 선택



##### 7.2.3 씬 저장하기

- File -> Save As -> (GameScene)





#### 7.3 Terrain을 사용해 지형 만들기

##### 7.3.1 3D 게임 좌표계

- Main Camera가 원점을 향해 배치됨.
- Vertigo : 3D 게임에서는 게임 공간을 돌면서 오브젝트를 배치하기 때문에 어느 쪽을 향하고 있는지 잃기 쉬운 현상
- 씬 기즈모 : Vertigo 현상을 보완하기 위해 자신이 향하는 방향을 확인할 수 있는 길잡이 역할



##### 7.3.2 Lighting 설정

- 3D 게임에서는 주변 환경 밝기에 따라 3D 모델의 보이는 방향이 변한다.
- Directional Light가 기본적으로 있지만, 이 라이트만으로는 어둡게 보인다.
- Window -> Rendering -> Lighting -> Scene 탭 -> Generate Lighting 클릭 -> Auto Generate 체크 해제



##### 7.3.3 Terrain

- 유니티에 준비된 지형 오브젝트로 산이나 강 등 지형을 간단히 만들 수 있다.



##### 7.3.4 Terrain 배치하기

- Scene 탭 -> + -> 3D Object -> Terrain

- Terrain의 Pivot을 나타내기 위해서 이동 도구 -> Terrain 선택 -> Center 도구를 Pivot으로 바꾸기

- 시점의 회전

  - Alt 를 누른 채로 Scene 뷰를 드래그

- Terrain의 위치 조정

  - Terrain의 중심이 원점에 오도록 이동시킨다
  - Terrain -> POS(-500, 0, -500)

- 지면의 높낮이 설정

  - Terrain -> Paint Terrain -> Raise or Lower Terrain 선택

  - 파란색 동그라미가 지면을 올라오게 하는 범위를 나타냄

    - 드래그한 지형 부분이 올라간다.

      | 브러시 종류 |                    |
      | ----------- | ------------------ |
      | Brushes     | 브러시 종류 선택   |
      | Brush Size  | 브러시 굵기        |
      | Opacity     | 브러시 효과의 강도 |

      > Shift 누른 채로 드래그하면 내려간다.

- 산맥 만들기
  - +Z축 방향으로 산맥을 작성
  - (builtin_brush_2), (Brush Size 150), (Opacity 50)으로 설정



##### 7.3.5 Terrain으로 재질 칠하기

- 자주 사용하는 풀, 나무, 물 등 재질이나 나무 3D 모델이 Environment Package로 제공된다.

- 이는 Standard Assets라는 에셋에 포함되어있으며, 에셋 스토어에서 받을 수 있다.

  > [https://assetstore.unity.com](https://assetstore.unity.com/)
  >
  > - standard assets 검색하여 클릭 -> Add to My Assets -> Accept -> Open in Unity -> Download -> Import
  >   - 3D 나무 모델 : Standard Assets -> Environment -> SpeedTree -> Broadleaf
  >   - 풀 & 바위 모델 : Standard Assets -> Envrionment -> TerrainAssets -> SurfaceTextures

- Standard Assets의 오류 대처 방법
  1. Project창 -> Assets -> Standard Assets -> Utility 선택
  2. 폴더 내의 오류가 발생한 파일을 삭제
  3. Console 창에서 Clear 클릭

- 풀 재질
  - Scene 탭 -> Terrain -> Paint Terrain -> Paint Texture -> Terrain Layers -> Edit Terrain Layers -> Create Layer 선택 -> (GrassHillAlbedo)로 칠하기

- 바위 재질
  - 똑같이 Create Layers -> (GrassRockyAlbedo) 선택
  - (Brush Size 60)으로 설정하고 산 부분을 칠하기



##### 7.3.6 카메라 위치 조절하기

- Main Camera의 POS (0, 5, -10)



##### 7.3.7 지면에 나무 심기

- 3D 나무 브러시를 만들어 칠하면 나무 배치 가능

- Terrain -> Paint Trees 도구 -> Edit Trees -> Add Tree -> Tree Prefab 오른쪽 끝에 있는 아이콘 -> Select GameObject창에서 (Broadleaf_Mobile) -> Add

- (Brush Size 60), (Tree Density 30), (Tree Height의 Random? 해제, 1.8) 설정 후 산기슭 주위를 드래그해서 나무 추가

  | 나무 브러시 설정     |                         |
  | -------------------- | ----------------------- |
  | Brush Size           | 브러시 굵기             |
  | Tree Density         | 나무 밀도               |
  | Tree Height          | 나무 높이               |
  | Lock Width to Height | 너비와 높이 비율을 고정 |
  | Random Tree Rotation | 무작위로 나무 회전      |