<%@ Page Title="" Language="C#" MasterPageFile="~/Student.master" AutoEventWireup="true" CodeFile="StudentHome.aspx.cs" Inherits="StudentHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

      <style>
        #sgpaChartContainer {
            width: 300px;
            height: 250px;
        }
    </style>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table style="width: 100%; table-layout: fixed;">
        <tr>
            <th colspan="4" style="background-color: #00CC66; color: black; text-align: left; padding: 5px; margin-bottom: 10px;">University Information</th>
        </tr>
        <tr>
            <td style="padding: 5px;"><strong>Student_ID:</strong>&nbsp;&nbsp; <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label></td>
            <td style="padding: 5px;"><strong>Campus:</strong>&nbsp;&nbsp; <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label></td>
            <td style="padding: 5px;"><strong>Section:</strong>&nbsp;&nbsp; <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label></td>
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
        <tr height="50"></tr>
          <tr>
               <th colspan="4" style="background-color: #00CC66; color: black; text-align: left; padding: 5px; margin-bottom: 10px;">
       <%-- <img src="C:\Users\Dell\Desktop\WebSite1\WebSite1\chart.png" alt="Logo" style="width: 100px; height: 100px; margin-right: 10px;">--%>Semester GPA
    </th>
         </tr>
    </table>

   
   
    <div id="sgpaChartContainer">
        <canvas id="sgpaChart" width="300" height="200"></canvas>
    </div>

    <script>
        // Chart creation code goes here
    </script>
</asp:Content>


 
