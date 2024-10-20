# RMC Tutorial - 1 ClockMini

- [RMC Tutorial - 1 ClockMini](#rmc-tutorial---1-clockmini)
  - [MVCS](#mvcs)
  - [General Function](#general-function)
  - [Test](#test)
  - [Ref](#ref)

## MVCS

- ClockWithMiniExample > clockSimpleMini.Initialize()
- public class ClockSimpleMini: SimpleMiniMvcs
  <Context,
    ClockModel,
    ClockView,
    ClockController,
    ClockService>
    Initialize()
- ClockModel: BaseModel
  - Observable. Observable Pattern
- ClockService : BaseService
  - LoadedUnityEvent : UnityEvent
  - async Task LoadAsync
    - OnLoaded.Invoke();
  - TextAsset textAsset = `Resources.Load<TextAsset>("Texts/ClockWithMiniText");` //讀取 Resources folder 實體檔案
- ClockController: BaseController
  - Unity Stopwatch
  - Bind M V S
  - on Event Handlers
  - C# CommandManager. Command pattern
- ClockHelper
  - async await
  - C# TaskCompletionSource
  - await fun.Invoke();

## General Function

- Debug.Log($"message"): Unity > Console
- Application.isPlaying

## Test

- Editor (Unity Test)
  - ControllerTest: Controller_InvokesTimeChangedCommand_WhenModelTimeChanges
  - ClockModelTest: ClockModelTest_DefaultValues_WhenCreated
- Runtime (Integration Test)
  - ClockModelPlayModeTest
  - ClockServicePlayModeTest
  - ClockViewPlayModeTest
- MockClockMini

## Ref

- ScriptableObject
  - [【阿空】Unity的可編程物件：ScriptableObject！ ( ScriptableObject in Unity!)](https://www.youtube.com/watch?v=0nW5PhQTWbQ)
  - [Unity手札 初探ScriptableObject](https://chrislin1015.medium.com/unity%E6%89%8B%E6%9C%AD-%E5%88%9D%E6%8E%A2scriptableobject-3827b6f30740)
  - [Unity — uEvent & ScriptableObjects](https://samuel-asher-rivello.medium.com/unity-ueventdispatcher-scriptableobjects-d1e6038b8345)
  - [ScriptableObject（可编程对象）为团队和代码带来的六个好处](https://unity.com/cn/blog/engine-platform/6-ways-scriptableobjects-can-benefit-your-team-and-your-code)
- Observable Pattern
  - [UnityObservables](https://github.com/Adam4lexander/UnityObservables)
  - [如何在 Unity 裡寫出具有一定擴充性的遊戲(17) — Observer模式(一)](https://medium.com/@ShailaRuza70245/%E5%A6%82%E4%BD%95%E5%9C%A8-unity-%E8%A3%A1%E5%AF%AB%E5%87%BA%E5%85%B7%E6%9C%89%E4%B8%80%E5%AE%9A%E6%93%B4%E5%85%85%E6%80%A7%E7%9A%84%E9%81%8A%E6%88%B2-17-observer%E6%A8%A1%E5%BC%8F-%E4%B8%80-9c5077f298e5)
- Command Pattern
