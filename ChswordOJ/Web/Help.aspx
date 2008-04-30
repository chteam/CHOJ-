<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" Title="Help - Online Judge"  Theme="MemberShipSkin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
<div style="margin-left:10%">
我们为您提供了多种编译器
<%--There are sevevral Compiler for you--%>.<br />
g++/c++: 可以编译C语言或C++代码。<%--for c++ or C language--%><br />
gcc: 可以编译C语言。<%--for C language--%><br />
csc: <%--For C# 2.0 Language runat--%>可以编译 .net framework 2.0/1.1 下运行的C#<br />
vbc: <%--For Vb.net(7.10)/Vb 8.0 Language runat--%>可以编译  .net framework 2.0/1.1 下运行的VB.net<br />
vjc: <%--For J#.net(it's the update Language of Visual J++ 6.0) runat--%>可以编译  .net framework 2.0 下运行的J#<br />
jsc: <%--For JScript 8.0/JScript 7.10 Language runat--%>可以编译  .net framework 2.0/1.1下运行的JScript<br />
例如：<%--e.g.--%><br />
<br />
id为6的题<a href="question.aspx?id=6">加法运算</a>&nbsp;<br />
<br />
C:(编译后exe文件约为15KB)<br />
<pre>#include &lt;stdio.h&gt;<br />
int main()/*C-C++程序的主函数最好为int否则编译可能通不过，建议使用DEVC++*/<br />
{<br />
    int a;<br />
    while(scanf("%d",&a) != EOF)/*输入以EOF结尾，WIN下输入方式为Ctrl+Z*/<br />
        printf("%d\n",a+1);<br />
}
	</pre>
	<br />
	C++:(编译后exe文件约为415KB)<br />
	<pre>
#include &lt;iostream&gt;<br />
using namespace std;<br />

int main()<br />
{<br />
    int x;<br />
    while(cin &gt;&gt; x)<br />
        cout &lt;&lt; x+1 &lt;&lt;endl;<br />
}<br />
	</pre>
	<br />
	C# on .net 2.0(C# 2.0):(编译后exe文件约为3KB)
<br />
<pre>
using System;<br />
class Program {<br />
	static void Main(string[] args) {<br />
		string s;<br />
	
		while (true) {<br />
			s = Console.ReadLine();<br />
			if (string.IsNullOrEmpty(s)) break;<br />
			Console.WriteLine(int.Parse(s) + 1);<br />

		}<br />
	}<br />
}<br />
</pre>
	<br />
	VB.net on .net 2.0(VB 8.0):(编译后exe文件约为2KB)
<br />
<pre>
Module pro1<br />
    Sub Main()<br />
        Dim s As String<br />
        While True<br />
            s = Console.ReadLine()<br />
            If String.IsNullOrEmpty(s) Then<br />
                Exit While<br />
            End If<br />
            Console.WriteLine(s + 1)<br />
        End While<br />
    End Sub<br />
End Module<br />
</pre>
<br />
J# on .net 2.0:(编译后exe文件约为2KB)
<br />
<pre>
import System.Console;<br />
public class Program
{<br />
    public static void main(String[] args)
    {<br />
        String i;<br />
       
        while(true){<br />
            i = Console.ReadLine();<br />
            if (String.IsNullOrEmpty(i)) break;<br />
            Console.WriteLine(Integer.parseInt(i) + 1);<br />
        }<br />
    }<br />
}<br />
</pre></div>
</asp:Content>

