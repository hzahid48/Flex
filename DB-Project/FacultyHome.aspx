<%@ Page Title="" Language="C#" MasterPageFile="~/Faculty.master" AutoEventWireup="true" CodeFile="FacultyHome.aspx.cs" Inherits="FacultyHome" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <br />
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
          <table style="width: 100%; table-layout: fixed;">
        <tr>
            <th colspan="4" style="background-color: #00CC66; color: black; text-align: left; padding: 5px; margin-bottom: 10px;">University Information</th>
        </tr>
        <tr>
            <td style="padding: 5px;"><strong>Faculty ID:</strong>&nbsp;&nbsp; <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
            <td style="padding: 5px;"><strong>Campus:</strong>&nbsp;&nbsp; <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
            <td style="padding: 5px;"><strong>Num of Courses:</strong>&nbsp;&nbsp; <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
        </tr>
               <tr height="50"></tr>
        <tr>
            <th colspan="4" style="background-color: #00CC66; color: black; text-align: left; padding: 5px; margin-bottom: 10px;">Personal Information</th>
        </tr>
        <tr>
            <td style="padding: 5px;"><strong>First Name:</strong>&nbsp;&nbsp; <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                <br />
            </td>
            <td style="padding: 5px;"><strong>Last Name:</strong>&nbsp;&nbsp; <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                <br />
            </td>
        </tr>
               <tr height="50"></tr>
        <tr>
            <th colspan="4" style="background-color: #00CC66; color: black; text-align: left; padding: 5px; margin-bottom: 10px;">Contact Details</th>
        </tr>
        <tr>
            <td style="padding: 5px;"><strong>Email:</strong>&nbsp;&nbsp;&nbsp; <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label></td>
            <td style="padding: 5px;"><strong>Phone Number:</strong>&nbsp;&nbsp; <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
    </asp:Content>

