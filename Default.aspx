<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Etudiant.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Application Form</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body style="height: 144px">
    <div class="jumbotron text-center">
        
            <h1 class="display-1" >SIMPLE FORMULAIRE</h1>

    </div>



    <div class="form-group">
            <form id="form1" runat="server">
        <br />
        <br />
        <br />
            <div class="row">
                <div class="col-lg-12">
                <div class="col-lg-12">
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtNom" runat="server"  CssClass="form-control" Placeholder="Nom" EnableViewState="False" ValidateRequestMode="Enabled" ViewStateMode="Disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNom" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>                    
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtPrenom1" runat="server"  CssClass="form-control" Placeholder="Prenom" ValidateRequestMode="Enabled" ViewStateMode="Disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrenom1" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>                    
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtPrenom2" CssClass="form-control" Placeholder="Prenom" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPrenom1" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>                    

                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" Placeholder="Age" ></asp:TextBox>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="Range 1-150" ForeColor="Red" MaximumValue="150" MinimumValue="1" Type="Integer"></asp:RangeValidator>                    
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control" Placeholder="Telephone"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTelephone" ErrorMessage="000-000-0000" ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>                    
                        </div>                    
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtNationalite" Placeholder="Nationalite" CssClass="form-control" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNationalite" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>                    
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtPays" Placeholder="Pays" runat="server" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPays" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>                    
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtVille" Placeholder="Ville" runat="server" CssClass="form-control" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVille" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>                    
                        </div>

                        <div class="col-lg-4">
                            <asp:TextBox ID="txtAdresse" Placeholder="Adresse" runat="server" CssClass="form-control" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAdresse" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                     </div>
                    </div>                    
                </div>
            </div>

        <asp:Label ID="Label1" class="label label-primary" runat="server"></asp:Label>
        <br />
        <br />
        <br />

        <div class="col-lg-8">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="214px" class="btn btn-primary btn-lg" OnClick="btnSave_Click" />
        </div>
         <div class="col-lg-4">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="214px" class="btn btn-primary btn-lg" OnClick="btnCancel_Click" />
        </div>
        <br />
        <br />
        <br />
        <br />
        <div class="col-lg-12" style="margin-left:40px">
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1002px">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        <br />
        
        <br />
        <br />
        <script src="Scripts/jquery-1.9.0.js"></script>
        <script src="Scripts/bootsrap.js"></script>
    </form>

    </div>
     <!-- Datatables-->
    <script src="bootstrap/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="bootstrap/vendors/datatables.net-bs4/js/dataTables.bootstrap4.min.js">
    </script>
</body>
</html>
