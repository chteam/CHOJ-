<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Group.aspx.cs" Inherits="PageGroup" EnableViewState="false" Title="Question List - Online Judge"
    Theme="MemberShipSkin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <asp:ObjectDataSource ID="OQ" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetData" TypeName="GetQuestionByGroupTableAdapters.SelectAllQuestionbyGroupTableAdapter">
        <SelectParameters>
            <asp:QueryStringParameter Name="groupid" QueryStringField="id" Type="Int64" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:Repeater ID="RG" runat="server">
        <ItemTemplate>
            <h3>
                <%#Eval("name") %>
                (<%#Eval("count") %>)</h3>
        </ItemTemplate>
    </asp:Repeater>
    <asp:GridView ID="GV" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
        DataKeyNames="id" DataSourceID="OQ" EnableViewState="False" PageSize="80">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                SortExpression="id" />
            <asp:TemplateField>
                <HeaderTemplate>
                    标题</HeaderTemplate>
                <ItemTemplate>
                    <a href="Question.aspx?id=<%#Eval("id") %>">
                        <%#Eval("title") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="AcceptedCount" HeaderText="通过" SortExpression="AcceptedCount">
                <HeaderStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="SubmitCount" HeaderText="提交" SortExpression="SubmitCount">
                <HeaderStyle Width="40px" />
            </asp:BoundField>
            <asp:BoundField DataField="Ratio" HeaderText="比例" ReadOnly="True" SortExpression="Ratio">
                <HeaderStyle Width="40px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
