<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.master" AutoEventWireup="true" CodeFile="Faculty_feedback.aspx.cs" Inherits="Faculty_feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style>
    .green-header {
        background-color:  #00CC66;
        color: black;
        padding: 5px;
    }
</style>

     <style>
    #Table2 
    {
        margin: 0 auto; /* Set left and right margins to auto */
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" style="margin: 0 auto;" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Show" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Download Report" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
    </p>
      <asp:Table ID="Table1" runat="server" style="margin: 0 auto;">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell CssClass="green-header" Width="150px">Score 1 </asp:TableHeaderCell>
        <asp:TableHeaderCell CssClass="green-header" Width="150px">Score 2</asp:TableHeaderCell>
        <asp:TableHeaderCell CssClass="green-header" Width="150px">Score 3</asp:TableHeaderCell>
        <asp:TableHeaderCell CssClass="green-header" Width="150px">Score 4</asp:TableHeaderCell>
        <asp:TableHeaderCell CssClass="green-header" Width="150px">Score 5</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label1" runat="server" TextAlign="Center"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:Label ID="Label2" runat="server" TextAlign="Center" ></asp:Label></asp:TableCell>
        <asp:TableCell><asp:Label ID="Label3" runat="server" TextAlign="Center"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:Label ID="Label4" runat="server" TextAlign="Center" ></asp:Label></asp:TableCell>
        <asp:TableCell><asp:Label ID="Label5" runat="server" TextAlign="Center"></asp:Label></asp:TableCell>
    </asp:TableRow>
</asp:Table>

    <p style="margin-left: 120px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p >
        <asp:Table ID="Table2" runat="server" style="margin: 0 auto;">
            <asp:TableHeaderRow>
        <asp:TableHeaderCell style="text-align: center;" CssClass="green-header" Width="150px">Index</asp:TableHeaderCell>
        <asp:TableHeaderCell  style="text-align: center;" CssClass="green-header" Width="600px">Comment</asp:TableHeaderCell>
    </asp:TableHeaderRow>
        </asp:Table>

        &nbsp;
            <p>
        <br />
&nbsp;&nbsp;&nbsp;</p>
        
    </p>
    <p style="margin-left: 120px">
        &nbsp;</p>
    <p style="margin-left: 120px">
        &nbsp;</p>
    <p style="margin-left: 120px">
        &nbsp;</p>
    <p style="margin-left: 120px">
        &nbsp;</p>
</asp:Content>

