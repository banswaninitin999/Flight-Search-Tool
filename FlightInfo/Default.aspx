<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FlightInfo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">

            <div class="col-md-3">
                <div class="form-group">
                    <label for="usr">Origin Airport:</label>
                    <%--<input type="text" class="form-control" id="origin">--%>
                    <asp:DropDownList CssClass="form-control" ID="origin" runat="server">

                    </asp:DropDownList>
                </div>
            </div>

            <div class="col-md-3">
                <div class="form-group">
                    <label for="pwd">Destination Airport:</label>
                    <asp:DropDownList CssClass="form-control" ID="destination" runat="server"></asp:DropDownList>
                </div>
            </div>

           <%-- <div class="col-md-3">
                <div class="form-group">
                    <label >Start Date:</label>
                    <div id="datetimepicker1" class="input-append date">
                        <asp:TextBox runat="server" data-format="dd/MM/yyyy hh:mm:ss" CssClass="form-control" ID="startDate"></asp:TextBox>
                        <span class="add-on">
                            <i data-time-icon="icon-time" data-date-icon="icon-calendar"></i>
                        </span>
                    </div>
                </div>
            </div>--%>
            <div class="col-md-3 ">
             <label >Start Date:</label>  
                <asp:TextBox type="text" class="form-control cal" ID="startOrgDate" runat="server" Height="30px" autocomplete="off"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <div class="form-group">
                    <label >End Date:</label>   
                        <asp:TextBox type="text" class="form-control cal2" ID="endDestDate" runat="server" Height="30px" autocomplete="off"></asp:TextBox>
                    </div>                
            </div>

            <div class="col-md-3">
                <asp:Button CssClass="btn btn-primary btn-md" Name="Sarch"  Text="SEARCH" id="btnSearch" runat="server" OnClick="btnSearch_Click">
                   
                </asp:Button>
            </div>
        </div>

    </div>

    <div class="row">
        <table class="table">
            <thead>
                <tr>
                <th>Actual Ident</th>
                <th>Aircraft Type</th>
                <th>Origin</th>
                <th>Destination</th>
                <th>Arrival Time</th>
                <th>Departure Time</th>
            </tr>
            </thead>
            <tbody id="tabResult" runat="server">

            </tbody>

        </table>
    </div>

   
   <script>

          $(function(){
              $('.cal').datepicker({
            
        // options here
              });
              $('.cal2').datepicker({
                 
        // options here
        });
        });
  
  </script>


</asp:Content>
