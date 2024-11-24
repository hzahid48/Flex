<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.master" AutoEventWireup="true" CodeFile="FacultyGrades.aspx.cs" Inherits="FacultyGrades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style>
    .green-header {
        background-color:  #00CC66;
        color: black;
        padding: 5px;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />

     

&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Download Report" />
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Count Grade" />
&nbsp;<asp:Table ID="Table1" runat="server" align="center" CellSpacing="10">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell CssClass="green-header" HorizontalAlign="Left">Grade</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="green-header" HorizontalAlign="Left">GPA</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="green-header">Minimum Marks</asp:TableHeaderCell>
            <asp:TableHeaderCell CssClass="green-header">Maximum Marks</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
&nbsp; 

</asp:Content>

