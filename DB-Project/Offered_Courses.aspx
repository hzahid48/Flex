<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Offered_Courses.aspx.cs" Inherits="Offered_Courses" %>

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

     <asp:Table ID="Table1" runat="server" align="center" CellSpacing="15">
          <asp:TableHeaderRow>
        <asp:TableHeaderCell HorizontalAlign="Left"  CssClass="green-header">Course Code</asp:TableHeaderCell>
        <asp:TableHeaderCell HorizontalAlign="Left"  CssClass="green-header">Course Name</asp:TableHeaderCell>
        <asp:TableHeaderCell HorizontalAlign="Left"  CssClass="green-header">Pre-Requisite</asp:TableHeaderCell>
        <asp:TableHeaderCell  CssClass="green-header">Add</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    </asp:Table>


     <div style="text-align: center;">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
         <br />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Offer Courses" OnClick="Button1_Click"/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Download Report" />
    </div>

</asp:Content>

