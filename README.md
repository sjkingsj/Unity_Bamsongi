# 실행 예시
![7 1](https://user-images.githubusercontent.com/87646938/126866742-1138e00e-915f-4d35-9bea-44faced45fc1.jpg)
 - 초기 화면

![7 2](https://user-images.githubusercontent.com/87646938/126866688-00d749e8-82c0-4ed7-b810-52aef21a1829.jpg)
 - 화면을 누르면 지정한 방향으로 밤송이 발사

![7 3](https://user-images.githubusercontent.com/87646938/126866689-cd7a8a60-79be-4aa0-811b-c843fa3f25fa.jpg)
 - 과녁과 충돌시 파티클이 나타나는 모습





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





#### 7.4 Physics를 사용해 밤송이 날리기

##### 7.4.1 과녁 배치하기

- 과녁 3D 오브젝트 배치 (target) POS(0, 0, 10)

- 밤송이가 과녁에 닿았는지 감지할 수 있도록 사각형 콜라이더 적용

  - (target) -> Add Component -> Physics -> Box Collider

- 과녁의 머리 부분에 콜라이더가 오도록 매개변수 조절

  - (target) -> Box Collider 항목 (Center (0, 6.5, 0), Size (3.8, 3.8, 1))

    

  **[ 움직이는 오브젝트를 만드는 방법 ]**

  1. Scene 뷰에 오브젝트 배치
  2. 오브젝트 움직이는 방법을 쓴 스크립트 작성
  3. 작성한 스크립트를 오브젝트에 적용

  

##### 7.4.2 씬 위에 밤송이 배치하기

- (bamsongi) 드래그&드롭 -> POS(0, 5, -9)



##### 7.4.3 밤송이에 Physics 적용하기

- 밤송이를 물리 법칙대로 움직이도록 Rigidbody 컴포넌트 적용
  - (bamsongi) -> Add Component -> Physics -> Rigidbody
- 과녁과 충돌 판정을 할 수 있도록 Collider 컴포넌트 적용
  - (bamsongi) -> Add Component -> Physics -> Sphere Collider
  - Sphere Collider 항목의 (Radius (0.35))



##### 7.4.4 밤송이를 날리는 스크립트 작성

- 밤송이에 힘을 가하는 밤송이 컨트롤러 (BamsongiController)

  ```c#
  public class BamsongiController : MonoBehaviour
  {
  	// AddForce 매서드를 사용해 매개변수 방향으로 힘을 가하도록 Shoot 매서드
  	public void Shoot(Vector3 dir)
  	{
  		GetComponent<Rigidbody>().AddForce(dir);
  	}
  	
      void Start()
  	{
          // +Z축 방향으로 날아가도록 매개변수
   		// +Y축 방향으로는 밤송이가 과녁에 닿기 전 중력의 영향을 받는 것을 방지
          Shoot (new Vector3(0, 200, 2000));
   	}
  }
  ```

  

##### 7.4.5 밤송이에 스크립트 적용하기

- (BamsongiController)를 (bamsongi)에 적용



##### 7.4.6 밤송이를 과녁에 꽂기

- 과녁에 충돌하는 순간 밤송이에 들어가는 힘을 무효로 만들면 된다.

  ```c#
  // (BamsongiController 수정)
  public class BamsongiController : MonoBehaviour
  {
  	...
  	void OnCollisionEnter(Collision other)
  	{
   	GetComponent<Rigidbody>().isKinematic = true;
   	// OnCollisionEnter : 충돌을 감지하는 매서드
   	// isKinematic : true로 하면 오브젝트에 작용하는 힘을 무시하고 밤송이를 정지시킬 수 있다.
  	}
  	...
  }
  ```





#### 7.5 파티클을 사용해 이펙트 표시하기

##### 7.5.1 파티클

- 파티클을 이용해서 이펙트를 추가

- **[ 파티클에서 자주 사용하는 매개변수 ]**

  | 파티클에서 중요한 매개변수 |                                          |
  | -------------------------- | ---------------------------------------- |
  | Duration                   | 파티클 방출 시간                         |
  | Looping                    | 파티클 무한 방출                         |
  | Start Delay                | 파티클을 방출하기 시작하는데 걸리는 시간 |
  | Start Lifetime             | 파티클 표시 시간                         |
  | Start Speed                | 파티클 방출 속도                         |
  | Start Size                 | 파티클 크기                              |
  | Start Color                | 파티클 초기 색상                         |
  | Gravity Modifier           | 파티클에 가하는 중력                     |
  | Max Particles              | 최대 파티클 수                           |
  | Rate                       | 1초당 생성되는 파티클 수                 |
  | Bursts                     | 지정 시간에 생성되는 파티클 수           |
  | Shape                      | 파티클 방출 형태                         |

  

##### 7.5.2 확 퍼지는 이펙트 표시하기

**[ 파티클 표시 ]**

1. 오브젝트에 ParticleSystem 컴포넌트 적용
2. ParticleSystem 컴포넌트의 매개변수를 조절해 이펙트를 작성
3. 스크립트에서 파티클이 재생되도록 설정



**[ 밤송이에 ParticleSystem 컴포넌트 적용 ]**

- (bamsongi) -> Add Component -> Effects -> Particle System
  - 밤송이에서 분홍색 색종이가 방출되는 것을 확인



**[ 파티클에 Material 설정 ]**

- 분홍색 색종이는 Material을 설정하지 않는 상태
- (bamsongi) -> Particle System 항목 -> Renderer -> Material -> (Default-Particle)



**[ ParticleSystem 매개변수를 조절해 확 퍼지는 이펙트 생성 ]**

- 파티클 방출 형태 조절
  - (bamsongi) -> Particle System 항목 -> Shape -> (Sphere) -> (Radius 0.01)

- 파티클 생성 패턴을 조절
  - Rate를 사용한 파티클 생성 : 매 프레임마다 같은 개수의 파티클 생성
  - Bursts를 사용한 파티클 생성 : 간헐적으로 파티클 생성
    - Particle System 항목 -> Emission -> Rate over Time 0
    - 과녁에 닿았을 때 방출 -> Emission -> Bursts -> + -> (Time 0, Count 50)
    - 파티클이 사라질 때 까지의 재생 시간을 줄이기 -> (Duration, StartLifeTime 1)
- 파티클이 부드럽게 사라지도록 (페이드아웃)
  - Particle System 항목 -> (Size over Lifetime 체크), (Size 우측하단 검은 부분 클릭) -> Particle System Curves창 -> 감쇠곡선 모양 선택

- 재생 시점 설정
  - 반복재생 X -> Looping 체크 해제
  - 과녁에 닿았을 때만 첫 이펙트 표시 -> Play On Awake 체크 해제



**[ 과녁과 밤송이 충돌을 감지해 파티클 재생 ]**

```c#
//(BamsongiController 수정)
public class BamsongiController : MonoBehaviour
{
	...
	void OnCollisionEnter(Collision other)
	{
 		GetComponent<Rigidbody>().isKinematic = true;
 		GetComponent<ParticleSystem>().Play();
 		// 밤송이 충돌 시 ParticleSystem 컴포넌트 구하고, Play 매서드로 파티클 재생
	}
	...
}
```





#### 7.6 밤송이 공장 만들기

##### 7.6.1 밤송이 프리팹 만들기

- 화면을 탭할 때마다 밤송이를 만들기 위해 공장 필요
- **[ 공장을 만드는 방법 ]**
  1. 이미 있는 오브젝트를 사용해 프리팹 만들기
  2. 제너레이터 스크립트 만들기
  3. 빈 오브젝트에 제너레이터 스크립트 적용
  4. 제너레이터 스크립트에 프리팹을 전달
- (bamsongi) -> Project창으로 드래그&드롭 -> Original Prefab 클릭 -> (bamsongiPrefab)
- Hierarchy 창의 밤송이는 필요없으므로 제거



##### 7.6.2 밤송이 제너레이터 스크립트 작성하기

```c#
//(BamsongiGenerator)
public class BamsongiGenerator : MonoBehaviour
{
	// 아웃렛 접속을 사용해 대입할 수 있도록 public을 붙여서 선언
	public GameObject bamsongiPrefab;
	
    void Update()
	{
		// 화면을 누르면
		if (Input.GetMouseButton(0))
 		{
  			// 밤송이 인스턴스를 만들기
  			GameObejct bamsongi = Instantiate(bamsongiPrefab) as GameObject;
  			// 날리고자 하는 방향의 벡터를 전달하고 Shoot 매서드 실행
  			bamsongi.GetComponent<BamsongiController>().Shoot(new Vector3(0, 200, 2000));
 		}
	}
}
```



**[ Shoot 매서드의 주석 처리 ]**

- BamsongiGenerator에서 발사 방향을 정했기 때문에 BamsongiController의 Start 매서드의 Shoot 매서드를 호출하는 부분을 주석으로 처리한다.

  

##### 7.6.3 밤송이 공장 오브젝트 만들기

- 빈 오브젝트 만들기 (BamsongiGenerator) -> (BamsongiGenerator) 스크립트 적용



##### 7.6.4 프리팹을 공장으로 전달하기

- 스크립트에서 선언한 변수에 오브젝트 실체를 대입하려면 아웃렛 접속을 사용

  **[ 아웃렛 접속 ]**

  1. 스크립트 변수 앞에 public 접근 수식자 붙이기
     - (BamsongiGenerator)의 public GameObject bamsongiPrefab;
  2. public 접근 수식자를 붙인 변수가 Inspector 창에 보인다
  3. 콘센트 구멍에 대입할 오브젝트를 Inspector 창으로 드래그&드롭
     - (BamsongiGenerator) -> bamsongi Prefab 칸에 (bamsongiPrefab) 넣기



##### 7.6.5 탭한 곳으로 밤송이 날리기

- 탭한 좌표는 (Input.mousePosition) 매서드로 구할 수 있지만, 3D 에서는 (mousePosition) 값을 그대로 사용할 수 없다.

  >(mousePosition) 값은 스크린 좌표계 값이기 때문
  >
  >월드 좌표계와 스크린 좌표계는 다른 척도를 사용한다.
  >
  >
  >
  >(ScreenPointToRay) 매서드는 스크린 좌표를 전달하면 카메라에서 스크린 좌표로 향하는 월드 좌표계로 벡터를 구할 수 있다. 따라서 밤송이 생성과 동시에 이 매서드로 얻은 방향으로 밤송이에 힘을 가하면 탭한 방향으로 밤송이가 발사 된다.

  ```c#
  //(BamsongiGenerator 수정)
  public class BamsongiGenerator : MonoBehaviour
  {
      ...
  	void Update()
  	{
   		if (Input.GetMouseButtonDown(0))
   		{
    			...
    			// 카메라에서 탭 좌표로 향하는 벡터에 따른 Ray 클래스 반환, 좌표 전달
    			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    			Vector3 worldDir = ray.direction;
    			// 탭 좌표로 향하는 벡터를 normalized로 크기가 1 * 2000으로 Shoot 매서드
    			bamsongi.GetComponent<BamsongiController>().Shoot(worldDir. normalized * 2000);
  		}
      }
  }
  ```

  
