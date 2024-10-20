# RMC Tutorial - 2 LoginMini

- [RMC Tutorial - 2 LoginMini](#rmc-tutorial---2-loginmini)
  - [MVCS](#mvcs)
  - [General Function](#general-function)
  - [Test](#test)
  - [Ref](#ref)

## MVCS

- LoginWithMiniExample > LoginMini: SimpleMiniMvcs
- LoginModel: BaseModel. Observable
  - UserData: DTO
- LoginView: MonoBehaviour, IView
- LoginService: BaseService
  - async void LoginAsync(UserData)
  - OnLoginCompletedUnityEvent : UnityEvent<UserData, bool>
- Controller
  - LoginController: BaseController. M V C
  - Commands
    - LoggedInUserDataChangedCommand : `ValueChangedCommand<UserData>`
    - LoginCompletedCommand : ICommand. UserData
    - LoginSubmittedCommand : ICommand. UserData, WasSuccess
    - LogoutCommand : ICommand

## General Function

- ContextWithLocator

## Test

- Editor
  - LoginControllerTest: Controller_InvokesTimeChangedCommand_WhenModelTimeChanges
  - LoginModelTest
- Runtime
  - LoginServicePlayModeTest
    - UserDataOutput_IsSameAsInput_WhenLoginCompleted
    - WasSuccess_IsFalse_WhenIncorrectPassword
    - WasSuccess_IsTrue_WhenCorrectPassword
  - LoginViewPlayModeTest
    - Initialize_DoesNotThrow_WhenCalled

## Ref

- [DAO, DTO 啥鬼？還有 GTO 嗎](https://justinhollly.medium.com/dao-dto-%E5%95%A5%E9%AC%BC-%E9%82%84%E6%9C%89-gto-%E5%97%8E-39a42f13768b)
- [DTO、VO、BO、DAO、POJO 各種 Object](https://hackmd.io/@OceanChiu/HJBvCZcQ8)
