Imports System.Globalization

Public Class ChecksumHelp


    Public Shared Function ConvertHexadecimalStringToByteArray(ByVal hexadecimalString As String) As Byte()
        If hexadecimalString.Length Mod 2 <> 0 Then
            Throw New ArgumentException(String.Format(CultureInfo.InvariantCulture, "HexaDecimal cannot have an odd number of digits: {0}", hexadecimalString))
        End If

        Dim hexByteArray As Byte() = New Byte(hexadecimalString.Length / 2 - 1) {}

        For index As Integer = 0 To hexByteArray.Length - 1
            Dim byteValue As String = hexadecimalString.Substring(index * 2, 2)
            hexByteArray(index) = Byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture)
        Next

        Return hexByteArray
    End Function

    Public Shared Function calculateCheckSum(ByVal byteData As Byte()) As Byte
        Dim chkSumByte As Byte = &H0

        For i As Integer = 0 To byteData.Length - 1
            chkSumByte = chkSumByte Xor byteData(i)
        Next

        Return chkSumByte
    End Function

    Public Shared Function isCheckSum(ByVal tagSinChecksum As String, ByVal codigoVerificaCheckSum As String) As Boolean
        Dim hexByteArray As Byte()
        Dim hexByteArrayVerificaCheckSum As Byte()
        Dim resByte As Byte
        Dim res As Boolean = False

        hexByteArray = ChecksumHelp.ConvertHexadecimalStringToByteArray(tagSinChecksum)
        hexByteArrayVerificaCheckSum = ChecksumHelp.ConvertHexadecimalStringToByteArray(codigoVerificaCheckSum)
        resByte = ChecksumHelp.calculateCheckSum(hexByteArray)

        If resByte = hexByteArrayVerificaCheckSum(0) Then
            res = True
        End If

        Return res
    End Function

End Class
