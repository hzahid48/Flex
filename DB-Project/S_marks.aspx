<%@ Page Title="" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeFile="S_marks.aspx.cs" Inherits="S_marks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

     <style>
    .green-header 
    {
        background-color:  #00CC66;
        color: black;
        padding: 5px;
    }
</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p style="margin-left: 560px">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" />
        &nbsp;
    </p>
    <p style="margin-left: 480px">
       
        <asp:Table ID="Table2" runat="server" style="margin: 0 auto; height: 200px;">
       <asp:TableHeaderRow>
        <asp:TableHeaderCell CssClass="green-header">Assessment Type</asp:TableHeaderCell>
<asp:TableHeaderCell CssClass="green-header">Marks</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow Height="50px">
        <asp:TableCell>Quizzes</asp:TableCell>
        <asp:TableCell><asp:Label ID="QuizzesLabel" runat="server" align="center"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow Height="50px">
        <asp:TableCell>Assignments</asp:TableCell>
        <asp:TableCell><asp:Label ID="AssignmentsLabel" runat="server" align="center"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow Height="50px">
        <asp:TableCell>Sessional 1</asp:TableCell>
        <asp:TableCell><asp:Label ID="Sessional1Label" runat="server" align="center"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow Height="50px">
        <asp:TableCell>Sessional 2</asp:TableCell>
        <asp:TableCell><asp:Label ID="Sessional2Label" runat="server" align="center"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow Height="50px">
        <asp:TableCell>Final Marks</asp:TableCell>
        <asp:TableCell><asp:Label ID="FinalLabel" runat="server" align="center"></asp:Label></asp:TableCell>
    </asp:TableRow>
             <asp:TableRow Height="50px">
        <asp:TableCell>ObtainedMarks</asp:TableCell>
        <asp:TableCell><asp:Label ID="ObtainedLabel" runat="server" align="center"></asp:Label></asp:TableCell>
    </asp:TableRow>
             <asp:TableRow Height="50px">
        <asp:TableCell>Total Marks</asp:TableCell>
        <asp:TableCell><asp:Label ID="TotalLabel" runat="server" align="center"></asp:Label></asp:TableCell>
    </asp:TableRow>
        </asp:Table>

    </p>
</asp:Content>

