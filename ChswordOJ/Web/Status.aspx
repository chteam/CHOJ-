<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Status.aspx.cs" Inherits="Status" Theme="MemberShipSkin" Title="Answer Status - Online Judge"
    EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" EnableViewState="false"
    runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="StatusSelect" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:QueryStringParameter Name="questionid" QueryStringField="id" Type="Int64" DefaultValue="0" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="SqlDataSource1"
        PageSize="20" EnableViewState="false" DataKeyNames="id" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                SortExpression="id">
                <HeaderStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Addtime" HeaderText="提交时间" SortExpression="Addtime" HtmlEncode="False"
                DataFormatString="{0:yyyy-MM-dd hh:mm}">
                <HeaderStyle Width="150px" />
            </asp:BoundField>
            <asp:TemplateField>
                <HeaderTemplate>
                    标题<%--Ploblem Title--%>
                </HeaderTemplate>
                <ItemTemplate>
                    <a href="question.aspx?id=<%#Eval("Questionid") %>">
                        <%#Eval("title") %>
                    </a>(<%#Eval("Questionid") %>)
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle Width="150px" />
                <HeaderTemplate>
                    评判结果<%--Judge Status--%></HeaderTemplate>
                <ItemTemplate>
                    <%#ChswordOJ.ChString.GetStatus(Eval("status").ToString(),Int64.Parse(Eval("id").ToString()))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderStyle Width="150px" />
                <HeaderTemplate>
                    编译器<%--Compiler--%></HeaderTemplate>
                <ItemTemplate>
                    <%#ChswordOJ.ChString.GetCompiler(Eval("exe").ToString())%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="username" HeaderText="用户名" SortExpression="username">
                <HeaderStyle Width="80px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
