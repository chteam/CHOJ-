<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Sort.aspx.cs" Inherits="Sort" Title="Ranklist" Theme="MemberShipSkin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="GetUser" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%#Container.DataItemIndex+1%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="username" />
            <asp:BoundField DataField="Accepted" SortExpression="Accepted" />
            <asp:BoundField DataField="Submit" SortExpression="Submit" />
            <asp:BoundField DataField="Ratio" SortExpression="Ratio" />
        </Columns>
    </asp:GridView>
</asp:Content>
