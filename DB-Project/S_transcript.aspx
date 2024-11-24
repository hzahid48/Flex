<%@ Page Title="" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeFile="S_transcript.aspx.cs" Inherits="S_transcript" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <style>
		table 
       {
             border-collapse: collapse;
             margin: 20px;
             float: left;
             height: 20px;
             width: 288px;
             
        }

        table + table
        {
            margin-left: 40px;
        }
    </style>

     <style>
    .green-header {
        background-color:  #00CC66;
        color: black;
        padding: 5px;
    }
</style>
    <p>
        &nbsp;</p>
    <p style="margin-bottom:0;" style="margin-left: 40px">
    &nbsp;&nbsp;&nbsp;&nbsp;
        Fall 2021&nbsp;&nbsp; CGPA:3.2&nbsp;&nbsp;&nbsp; SGPA:3.2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Spring 2022&nbsp;&nbsp; CGPA:3.3&nbsp;&nbsp;&nbsp; SGPA:3.4<br />
    </p>

     <asp:Table ID="Table1" runat="server"  Width="30%">
        <asp:TableHeaderRow>
        <asp:TableHeaderCell align="left" CssClass="green-header">Course Name</asp:TableHeaderCell>
        <asp:TableHeaderCell CssClass="green-header">Grade</asp:TableHeaderCell>
                <asp:TableHeaderCell  align="center" CssClass="green-header">GPA</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>Math</asp:TableCell>
        <asp:TableCell  align="center">A</asp:TableCell>
        <asp:TableCell  align="center">4.0</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>English</asp:TableCell>
        <asp:TableCell  align="center">B</asp:TableCell>
        <asp:TableCell  align="center">3.0</asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell>Science</asp:TableCell>
        <asp:TableCell  align="center">C</asp:TableCell>
        <asp:TableCell  align="center">2.0</asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell>Social Studies</asp:TableCell>
        <asp:TableCell  align="center">A</asp:TableCell>
        <asp:TableCell  align="center">4.0</asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell>Geography</asp:TableCell>
        <asp:TableCell  align="center">B</asp:TableCell>
        <asp:TableCell  align="center">3.0</asp:TableCell>
    </asp:TableRow>
        </asp:Table>


   
     &nbsp;


   
     <asp:Table ID="Table2" runat="server"  Width="30%">
            <asp:TableHeaderRow >
        <asp:TableHeaderCell align="left" CssClass="green-header">Course Name</asp:TableHeaderCell>
        <asp:TableHeaderCell CssClass="green-header">Grade</asp:TableHeaderCell>
                <asp:TableHeaderCell  align="center" CssClass="green-header">GPA</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>History</asp:TableCell>
        <asp:TableCell  align="center">A</asp:TableCell>
        <asp:TableCell  align="center">4.0</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Accounts</asp:TableCell>
        <asp:TableCell  align="center">B</asp:TableCell>
        <asp:TableCell  align="center">3.0</asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell>Biology</asp:TableCell>
        <asp:TableCell  align="center">C</asp:TableCell>
        <asp:TableCell  align="center">2.0</asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell>Chemistry</asp:TableCell>
        <asp:TableCell  align="center">A</asp:TableCell>
        <asp:TableCell  align="center">4.0</asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell>Physics</asp:TableCell>
        <asp:TableCell  align="center">A</asp:TableCell>
        <asp:TableCell  align="center">4.0</asp:TableCell>
    </asp:TableRow>
        </asp:Table>

        
   
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />

     <br />

        
   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 


   
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <p style="margin-bottom:0;" style="margin-left: 40px">
    &nbsp;&nbsp;&nbsp;&nbsp;
    Fall 2022&nbsp;&nbsp; CGPA:3.2&nbsp;&nbsp;&nbsp; SGPA:3.0&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Spring 2023&nbsp;&nbsp; CGPA:
        <asp:Label ID="Label1" runat="server" ></asp:Label>
        &nbsp;&nbsp;&nbsp; SGPA:&nbsp;
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
    </p>

     <asp:Table ID="Table3" runat="server"  Width="30%">
        <asp:TableHeaderRow >
        <asp:TableHeaderCell align="left" CssClass="green-header">Course Name</asp:TableHeaderCell>
        <asp:TableHeaderCell CssClass="green-header">Grade</asp:TableHeaderCell>
                <asp:TableHeaderCell  align="center" CssClass="green-header">GPA</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell>Data Structures</asp:TableCell>
        <asp:TableCell  align="center">A</asp:TableCell>
        <asp:TableCell  align="center">4.0</asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>Discrete Structures</asp:TableCell>
        <asp:TableCell  align="center">B</asp:TableCell>
        <asp:TableCell  align="center">3.0</asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell>COAL</asp:TableCell>
        <asp:TableCell  align="center">C</asp:TableCell>
        <asp:TableCell  align="center">2.0</asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell>Linear Alegbra</asp:TableCell>
        <asp:TableCell  align="center">B</asp:TableCell>
        <asp:TableCell  align="center">3.0</asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell>German</asp:TableCell>
        <asp:TableCell  align="center">B</asp:TableCell>
        <asp:TableCell  align="center">3.0</asp:TableCell>
    </asp:TableRow>
        </asp:Table>


   
     &nbsp;


   
   
     <asp:Table ID="Table4" runat="server"  Width="30%">
            <asp:TableHeaderRow >
        <asp:TableHeaderCell align="left" CssClass="green-header">Course Name</asp:TableHeaderCell>
        <asp:TableHeaderCell CssClass="green-header">Grade</asp:TableHeaderCell>
                <asp:TableHeaderCell  align="center" CssClass="green-header">GPA</asp:TableHeaderCell>
    </asp:TableHeaderRow>
   <%-- <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label1" runat="server"></asp:Label></asp:TableCell>
         <asp:TableCell><asp:Label ID="Label2" runat="server"></asp:Label></asp:TableCell>
         <asp:TableCell><asp:Label ID="Label3" runat="server"></asp:Label></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label4" runat="server"></asp:Label></asp:TableCell>
         <asp:TableCell><asp:Label ID="Label5" runat="server"></asp:Label></asp:TableCell>
         <asp:TableCell><asp:Label ID="Label6" runat="server"></asp:Label></asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
          <asp:TableCell><asp:Label ID="Label7" runat="server"></asp:Label></asp:TableCell>
               <asp:TableCell><asp:Label ID="Label8" runat="server"></asp:Label></asp:TableCell>
               <asp:TableCell><asp:Label ID="Label9" runat="server"></asp:Label></asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label10" runat="server"></asp:Label></asp:TableCell>
               <asp:TableCell><asp:Label ID="Label11" runat="server"></asp:Label></asp:TableCell>
               <asp:TableCell><asp:Label ID="Label12" runat="server"></asp:Label></asp:TableCell>
    </asp:TableRow>
          <asp:TableRow>
         <asp:TableCell><asp:Label ID="Label13" runat="server"></asp:Label></asp:TableCell>
               <asp:TableCell><asp:Label ID="Label14" runat="server"></asp:Label></asp:TableCell>
               <asp:TableCell><asp:Label ID="Label15" runat="server"></asp:Label></asp:TableCell>
    </asp:TableRow>--%>
        </asp:Table>
</asp:Content>

