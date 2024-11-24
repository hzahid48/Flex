<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.master" AutoEventWireup="true" CodeFile="FacultyCourses.aspx.cs" Inherits="FacultyCourses" %>

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
    <p>
        <br />
    </p>
    <asp:Table ID="Table1" runat="server" Width="40%" align="center">
          <asp:TableHeaderRow>
        <asp:TableHeaderCell HorizontalAlign="Left" CssClass="green-header">Code-Title</asp:TableHeaderCell>
    
        <asp:TableHeaderCell CssClass="green-header" >Section</asp:TableHeaderCell>
               <asp:TableHeaderCell CssClass="green-header">Teacher</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>

