<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Allocate_Courses.aspx.cs" Inherits="Allocate_Courses" %>

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
           <asp:Panel ID="pnlErrorMessage" runat="server" CssClass="error-box" Visible="false">
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</asp:Panel>
       <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    <asp:Label ID="ErrorMessageLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
       </p>

        <br />
    </p>
    <asp:Table ID="Table1" runat="server" Width="20%" Height="100px" align="center">
          <asp:TableHeaderRow>
        <asp:TableHeaderCell HorizontalAlign="Left" CssClass="green-header" >Course</asp:TableHeaderCell>
        <asp:TableHeaderCell  CssClass="green-header">Teacher</asp:TableHeaderCell>
        <asp:TableHeaderCell  CssClass="green-header">Status</asp:TableHeaderCell>
        <asp:TableHeaderCell  CssClass="green-header">Section</asp:TableHeaderCell>
    </asp:TableHeaderRow>
        <asp:TableRow>
        <asp:TableCell><asp:DropDownList ID="DropDownList1" runat="server" Width="166px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
   <asp:ListItem Text="Select Course" Value="" Selected="True"></asp:ListItem>
</asp:DropDownList></asp:TableCell>
       <asp:TableCell><asp:DropDownList ID="DropDownList2" runat="server" Width="166px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
   <asp:ListItem Text="Select Faculty" Value="" Selected="True"></asp:ListItem>
</asp:DropDownList></asp:TableCell>
            <asp:TableCell><asp:DropDownList ID="DropDownList3" runat="server" Width="166px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
   <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
    <asp:ListItem Text="Allocate" Value="Allocate"></asp:ListItem>
    <asp:ListItem Text="Don't Allocate" Value="Don't Allocatw"></asp:ListItem>
</asp:DropDownList></asp:TableCell>
             <asp:TableCell><asp:DropDownList ID="DropDownList4" runat="server" Width="166px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
   <asp:ListItem Text="Select" Value="" Selected="True"></asp:ListItem>
    <asp:ListItem Text="A" Value="A"></asp:ListItem>
    <asp:ListItem Text="B" Value="B"></asp:ListItem>
</asp:DropDownList></asp:TableCell>
    </asp:TableRow>
    </asp:Table>
     <br />
     <br />
     <div style="text-align: center;">
    <asp:Button ID="Button1" runat="server" Text="Allocate" OnClick="Button1_Click"/>
    &nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Download Report" />
    </div>
</asp:Content>



