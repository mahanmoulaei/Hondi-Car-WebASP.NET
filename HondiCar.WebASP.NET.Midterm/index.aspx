<%--AUTHOR : MAHAN MOULAEI--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HondiCar.WebASP.NET.Midterm.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HONDI CARS</title>
    <style type="text/css">
        .form-style {
            margin:auto;
            right:50%;
            left:50%;
            width:710px;
            height:730px;
        }

        .title-style {
            text-align:center;
            color:brown;
        }

        .car-information-table {
            width:400px;
        }

        .user-entry {
            width:270px;
        }

        .label-style {
            width:250px;
        }

        .table-style {
            width:780px;
        }

        .td-column {
            height:120px;
            width: 50%;
        }
        .round-border {
            border-radius:15px;
        }
    </style>
</head>
<body style="background-color:antiquewhite;">
    <form id="form1" runat="server" class="form-style" style="">
        <div >
            <h1 class="title-style">Hondi Build &amp; Price</h1>
            <br />

            <table class="table-style">
                <tr style="vertical-align:top;">
                    <td class="td-column">
                        <!--Car Informations Panel-->
                        <asp:Panel ID="PanelCar" CssClass="round-border" BackColor="LightSkyBlue" runat="server" GroupingText="Car Informations" Height="100%" Width="100%">
                            <table class="car-information-table">
                                <!--City-->
                                <tr>
                                    <td class="label-style">
                                        <asp:Label ID="labelCity" runat="server" Text="Your City:"></asp:Label>
                                    </td>
                                    <td class="user-entry">
                                        <asp:TextBox ID="textCity" runat="server" Width="120px" Height="30px" CssClass="round-border"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                <!--Zip Code-->
                                <tr>
                                    <td class="label-style">
                                        <asp:Label ID="labelZipcode" runat="server" Text="Zip Code:"></asp:Label>
                                    </td>
                                    <td class="user-entry">
                                        <asp:TextBox ID="textZipCode" runat="server" Width="120px" Height="30px" CssClass="round-border"></asp:TextBox>
                                    </td>
                                </tr>

                                <!--Car Model-->
                                <tr>
                                    <td class="label-style">
                                        <asp:Label ID="labelCarModel" runat="server" Text="Select Car Model:"></asp:Label>
                                    </td>
                                    <td class="user-entry">
                                        <asp:DropDownList ID="dropdownCarModel" runat="server" Width="200px" OnSelectedIndexChanged="dropdownCarModel_Changed" AutoPostBack="true">
                                            <asp:ListItem>Select A Car Model...</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <!--Interior Colour-->
                                <tr>
                                    <td class="label-style">
                                        <asp:Label ID="labelInteriorColour" runat="server" Text="Interior Colour:"></asp:Label>
                                    </td>
                                    <td class="user-entry">
                                        <asp:ListBox ID="listInteriorColour" runat="server" Width="200px" OnSelectedIndexChanged="listInteriorColour_Changed" AutoPostBack="true"></asp:ListBox>
                                    </td>
                                </tr>

                                <!--Accessories-->
                                <tr>
                                    <td class="label-style">
                                        <asp:Label ID="labelAccessories" runat="server" Text="Accessories:"></asp:Label>
                                    </td>
                                    <td class="user-entry">
                                        <asp:CheckBoxList ID="checkboxAccessories" runat="server" OnSelectedIndexChanged="checkboxAccessories_Changed" AutoPostBack="true"></asp:CheckBoxList>
                                    </td>
                                </tr>

                                <!--Warranty-->
                                <tr>
                                    <td class="label-style">
                                        <asp:Label ID="labelWarranty" runat="server" Text="Warranty:"></asp:Label>
                                    </td>
                                    <td class="user-entry">
                                        <asp:RadioButtonList ID="radiobuttonWarranty" runat="server" OnSelectedIndexChanged="radiobuttonWarranty_Changed" AutoPostBack="true"></asp:RadioButtonList>
                                    </td>
                                </tr>   

                                <!--Should Dealer Contact You?-->
                                <tr>
                                    <td class="label-style">
                                        <asp:Label ID="labelDealerContactYou" runat="server" Text="Should Dealer Contact You By Phone?"></asp:Label>
                                    </td>
                                    <td class="user-entry">
                                        <asp:CheckBox ID="checkboxShouldDealerContactYou" runat="server" OnCheckedChanged="checkboxShouldDealerContactYou_Changed" AutoPostBack="true"></asp:CheckBox>
                                    </td>
                                </tr>

                                <!--Phone Number-->
                                <tr>
                                    <td class="label-style">
                                        <asp:Label ID="labelPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
                                    </td>
                                    <td class="user-entry">
                                        <asp:TextBox ID="textPhoneNumber" runat="server" Width="120px" Height="30px" CssClass="round-border"></asp:TextBox>
                                    </td>
                                </tr>          
                            </table>
                        </asp:Panel>
                    </td>

                    <td class="td-column">
                        <!--Price Resume Panel-->
                        <asp:Panel ID="PanelPrice" CssClass="round-border" BackColor="#ff9900" runat="server" GroupingText="Price Resume"  Height="250px" Width="100%">
                            <!--Price Literal Text-->
                            <asp:Literal ID="literalPrice" runat="server"></asp:Literal>

                            <br />

                            <!--Price Conclude Button-->    
                            <asp:Button ID="buttonConclude" runat="server" Text="Conclude" OnClick="buttonConclude_Click" style="float:right;"/>
                        </asp:Panel>

                        <br />

                        <!--Final Information Panel-->
                        <asp:Panel ID="PanelFinal" CssClass="round-border" BackColor="#ff9900" runat="server" GroupingText="Final Information"  Height="225px" Width="100%">
                            <!--Final Information Literal Text-->
                            <asp:Literal ID="literalFinalInformation" runat="server"></asp:Literal>
                        </asp:Panel>
                    </td>
                </tr>

                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
