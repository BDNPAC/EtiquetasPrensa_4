Option Strict On
Option Explicit On
Imports System
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Module MBloquearTeclas
    ' para guardar el gancho creado con SetWindowsHookEx
    Private mHook As Integer
    '
    ' para indicar a SetWindowsHookEx que tipo de gancho queremos instalar
    Private Const WH_KEYBOARD_LL As Integer = 13
    ' este es para el ratón
    'Private Const WH_MOUSE_LL As Long = 14&
    '
    Private Structure tagKBDLLHOOKSTRUCT
        Dim vkCode As Integer
        Dim scanCode As Integer
        Dim flags As Integer
        Dim time As Integer
        Dim dwExtraInfo As Integer
    End Structure
    '
    Private Const VK_TAB As Integer = &H9
    Private Const VK_CONTROL As Integer = &H11 ' tecla Ctrl
    'Private Const VK_MENU As Long = &H12        ' tecla Alt
    Private Const VK_ESCAPE As Integer = &H1B
    'Private Const VK_DELETE As Integer = &H2E      ' tecla Supr (Del)
    '
    Private Const LLKHF_ALTDOWN As Integer = &H20
    '
    ' códigos para los ganchos (la acción a tomar en el gancho del teclado)
    Private Const HC_ACTION As Integer = 0
    '
    ' Funciones del API de Windows
    '-----------------------------
    ' para asignar un gancho (hook)
    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" _
            (ByVal idHook As Integer, ByVal lpfn As LLKeyBoardProcDelegate,
            ByVal hMod As Integer, ByVal dwThreadId As Integer) As Integer
    ' para quitar el gancho creado con SetWindowsHookEx
    Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer
    ' para llamar al siguiente gancho
    Private Declare Function CallNextHookEx Lib "user32" _
            (ByVal hHook As Integer, ByVal nCode As Integer,
            ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    ' para saber si se ha pulsado en una tecla
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
    '
    ' El delegado para usar con AddressOf
    Private Delegate Function LLKeyBoardProcDelegate(ByVal nCode As Integer,
            ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    '
    ' La función a usar para el gancho del teclado
    Private Function LLKeyBoardProc(ByVal nCode As Integer,
            ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        Dim pkbhs As tagKBDLLHOOKSTRUCT
        Dim ret As Integer = 0
        '
        ' copiar el parámetro en la estructura
        pkbhs = CType(Marshal.PtrToStructure(New IntPtr(lParam), pkbhs.GetType), tagKBDLLHOOKSTRUCT)
        '
        If nCode = HC_ACTION Then
            '
            ' si se pulsa Ctrl+Esc
            If pkbhs.vkCode = VK_ESCAPE Then
                If (GetAsyncKeyState(VK_CONTROL) And &H8000S) <> 0 Then
                    ret = 1
                End If
            End If
            '
            ' si se pulsa Alt+Tab
            If pkbhs.vkCode = VK_TAB Then
                If (pkbhs.flags And LLKHF_ALTDOWN) <> 0 Then
                    ret = 1
                End If
            End If
            '
            ' si se pulsa Alt+Esc
            If pkbhs.vkCode = VK_ESCAPE Then
                If (pkbhs.flags And LLKHF_ALTDOWN) <> 0 Then
                    ret = 1
                End If
            End If
            '
            '' si se pulsa Alt+Supr
            '' (esto no funciona con Ctrl)
            'If pkbhs.vkCode = VK_DELETE Then
            '    If (pkbhs.flags And LLKHF_ALTDOWN) <> 0 Then
            '        ret = 1
            '    End If
            'End If
        End If
        '
        If ret = 0 Then
            ret = CallNextHookEx(mHook, nCode, wParam, lParam)
        End If
        '
        Return ret
        '
    End Function
    '
    Public Sub HookKeyB(ByVal hMod As Integer)
        ' instalar el gancho para el teclado
        ' hMod será el valor de App.hInstance de la aplicación
        mHook = SetWindowsHookEx(WH_KEYBOARD_LL, New LLKeyBoardProcDelegate(AddressOf LLKeyBoardProc), hMod, 0)
    End Sub
    '
    Public Sub UnHookKeyB()
        ' desinstalar el gancho para el teclado
        ' Es importante hacerlo antes de finalizar la aplicación,
        ' normalmente en el evento Unload o QueryUnload
        If mHook <> 0 Then
            UnhookWindowsHookEx(mHook)
        End If
    End Sub
End Module
