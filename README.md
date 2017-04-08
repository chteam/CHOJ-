Blog: http://chsword.cnblogs.com/

@chsword on WeiBo.com http://weibo.com/chsword

## CHOJ# 2.0 Beta2

* Azure支持
* Live Id 支持
* 编译时状态支持
* 增加可扩展库
* Wiki页面支持

## CHOJ# 2.0 Beta 发布
主要增加了程序的扩展性和稳定性
* 做为OJ程序的健壮性，增加了沙箱(sandbox)控制，但并未因此取消危险代码检测
* 升级至ASP.NET MVC框架
* 移除默认JScript，语言仅留C#及VB（因为只实现了这两个的沙箱），但仅可以使用托管代码编写程序
* 判断逻辑略有更改

未来特性：
Azure支持

## Chsword Online Judge(CHOJ#1.0)

支持语言:
C# / VB.net /C++/C /JScript/J#



## This Programme:
*Support*
.net 2.0
sql server 2005 express

*Folder*
/Web/ is the web site of Online Judge.
/WebCtrl/ is the Control or Class used by Online Judge.
/Compiler/ the Compiler and test file and tempfile.

*Config*
Open the web.config,in the<appSettings> <add key="Path"/> is the Folder of /Compiler/.
<add key="DevCppPath"/>'s value is the path of DevCpp or the Complier g++'s folder.
<add key="DotNet1Path"/>'s value is the path of .net 1.1.
and the <add key="DotNet2Path"/>'s value is the path of .net 2.0.

Please DownLoad this Config file after Download the Application http://www.codeplex.com/download?ProjectName=OnlineJudge&DownloadId=21148




!! 我们为您提供了多种编译器,There are sevevral Compiler for you.
g++ /c++ : 可以编译C语言或C++  代码。for c++ or C language
gcc: 可以编译C语言。for C language
csc: For C# 2.0 Language runat   可以编译 .net framework 2.0/1.1 下运行的C#
vbc:For Vb.net(7.10)/Vb 8.0 Language runat可以编译  .net framework 2.0/1.1 下运行的VB.net
vjc: For J#.net(it's the update Language of Visual J++ 6.0) runat可以编译  .net framework 2.0 下运行的J#
jsc: For JScript 8.0/JScript 7.10 Language runat可以编译  .net framework 2.0/1.1下运行的JScript
例如：e.g.
----------------------------------------
例:题为"加法"
输入input(EOF is Ctrl+Z)
1
EOF

输出output
2
-----------------------------------------
C:(编译后exe文件约为15KB,exe file is about 15KB)
{code:c++}
#include <stdio.h>
int main()/* C-C++   程序的主函数最好为int否则编译可能通不过，建议使用DEVC++ */
{
    int a;
    while(scanf("%d",&a) != EOF)/* 输入以EOF结尾，WIN下输入方式为Ctrl+Z */
        printf("%d\n",a+1);
}
{code:c++}	
	
	C++:(编译后exe文件约为415KB,exe file is about 415KB)
{code:c++}
#include <iostream>
using namespace std;

int main()
{
    int x;
    while(cin >> x)
        cout << x+1 <<endl;
}
{code:c++}

	C# on .net 2.0(C# 2.0):(编译后exe文件约为3KB,exe file is about 3KB)

{code:c#}
using System;
class Program {
	static void Main(string[] args) {
		string s;
	
		while (true) {
			s = Console.ReadLine();
			if (string.IsNullOrEmpty(s)) break;
			Console.WriteLine(int.Parse(s) + 1);

		}
	}
}
{code:c#}
	
	VB.net on .net 2.0(VB 8.0):(编译后exe文件约为2KB exe file is about 2KB)

{code:vb.net}
Module pro1
    Sub Main()
        Dim s As String
        While True
            s = Console.ReadLine()
            If String.IsNullOrEmpty(s) Then
                Exit While
            End If
            Console.WriteLine(s + 1)
        End While
    End Sub
End Module
{code:vb.net}

J# on .net 2.0:(编译后exe文件约为2KB , exe file is about 2KB)

{code:java}
import System.Console;
public class Program
{
    public static void main(String[] args)
    {
        String i;
       
        while(true){
            i = Console.ReadLine();
            if (String.IsNullOrEmpty(i)) break;
            Console.WriteLine(Integer.parseInt(i) + 1);
        }
    }
}
{code:java}
