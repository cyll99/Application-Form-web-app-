<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Etudiant.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FORME EMPLOYES</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body style="height: 144px">
    <div class="jumbotron text-center">
        
            <h1 class="display-1" >FORMULAIRE EMPLOYES</h1>

    </div>

    <%-- PERSONAL INFORMATIONS --%>

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
                            <asp:TextBox ID="txtDateNaissance" runat="server" CssClass="form-control" Placeholder="Date de naissance" TextMode="DateTime" ValidateRequestMode="Enabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtDateNaissance" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>                    
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control" Placeholder="Telephone" TextMode="Phone" ValidateRequestMode="Enabled"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTelephone" ErrorMessage="000-000-00" ForeColor="Red" ValidationExpression="\d{3}-\d{3}-\d{2}"></asp:RegularExpressionValidator>                    
                        </div>                    
                                       
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtDateEmbauche" Placeholder="Date d'embauche" runat="server" CssClass="form-control" TextMode="DateTime" ValidateRequestMode="Enabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDateEmbauche" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>                    
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtEmail" Placeholder="Email" runat="server" CssClass="form-control" TextMode="Email" ValidateRequestMode="Enabled" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>                    
                        </div>

                        <div class="col-lg-4">
                            <asp:TextBox ID="txtAdresse" Placeholder="Adresse" runat="server" CssClass="form-control" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAdresse" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                     </div>
                    <div class="col-lg-4">
                         <asp:DropDownList ID="DropSex" runat="server" ValidateRequestMode="Enabled"  Placeholder="Sexe" >
                    <asp:ListItem Selected="True">Sexe</asp:ListItem>
                    <asp:ListItem>Femme</asp:ListItem>
                    <asp:ListItem>Homme</asp:ListItem>
                </asp:DropDownList>
                        </div>
                    </div>                    
                </div>
            </div>

        <asp:Label ID="Label1" class="label label-primary" runat="server"></asp:Label>
        <br />
               <%-- CONTACT INFORMATION --%>
                <br />
                <br />
                <br />
                 <div class="jumbotron text-center">
        
            <h2 class="display-1" >PERSONNE A CONTACTER</h2></div>
                 <div class="row">
                <div class="col-lg-12">
                <div class="col-lg-12">
                    <div class="col-lg-4">
                            <asp:TextBox ID="txtNomContact" runat="server"  CssClass="form-control" Placeholder="Nom" EnableViewState="False" ValidateRequestMode="Enabled" ViewStateMode="Disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNomContact" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>                    
                        </div>
                        <div class="col-lg-4">
                            <asp:TextBox ID="txtPrenomContact" runat="server"  CssClass="form-control" Placeholder="Prenom" ValidateRequestMode="Enabled" ViewStateMode="Disabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPrenomContact" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>                    
                        </div>
                     <div class="col-lg-4">
                            <asp:TextBox ID="txtTelContact" runat="server" CssClass="form-control" Placeholder="Telephone" TextMode="Phone" ValidateRequestMode="Enabled"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTelContact" ErrorMessage="000-000-00" ForeColor="Red" ValidationExpression="\d{3}-\d{3}-\d{2}"></asp:RegularExpressionValidator>                    
                        </div> 
                     <div class="col-lg-4">
                         <asp:DropDownList ID="DropLien" runat="server" ValidateRequestMode="Enabled"  Placeholder="Lien de parente" TabIndex="1" >
                    <asp:ListItem Selected="True">Lien de parente</asp:ListItem>
                    <asp:ListItem>Epouse</asp:ListItem>
                    <asp:ListItem>Epoux</asp:ListItem>
                             <asp:ListItem>Mere</asp:ListItem>
                             <asp:ListItem>Pere</asp:ListItem>
                             <asp:ListItem>Frere</asp:ListItem>
                             <asp:ListItem>Soeur</asp:ListItem>
                             <asp:ListItem>Autres</asp:ListItem>
                </asp:DropDownList>
                        </div>
                    </div>
                    </div>
                     </div>
                <%-- DIFFERENT DEPARTEMENTS --%>
                   <br />
               
                <br />
                <br />
                <br />
                 <div class="jumbotron text-center">
        
            <h2 class="display-1" >PACOURS AU SEIN DE L'ORGANISATION</h2></div>
                 <div class="row">
                <div class="col-lg-12">
                <div class="col-lg-12">
                   
                     <div class="col-lg-4">
                         <asp:DropDownList ID="DropDepartement" runat="server" ValidateRequestMode="Enabled"  Placeholder="Lien de parente" TabIndex="1" >
                    <asp:ListItem Selected="True">Departement</asp:ListItem>
                    <asp:ListItem>Conception</asp:ListItem>
                    <asp:ListItem>Comptabilite</asp:ListItem>
                             <asp:ListItem>Communication</asp:ListItem>
                             <asp:ListItem>Formation</asp:ListItem>
                             <asp:ListItem>Logistique</asp:ListItem>
                             <asp:ListItem>Production</asp:ListItem>

                </asp:DropDownList>
                        </div>
                    <div class="col-lg-4">
                         <asp:DropDownList ID="DropPoste" runat="server" ValidateRequestMode="Enabled"  Placeholder="Lien de parente" TabIndex="1" >
                    <asp:ListItem Selected="True">Fonction</asp:ListItem>
                    <asp:ListItem >34</asp:ListItem>
                </asp:DropDownList>
                        </div>
                    
                    <div class="col-lg-4">
                            <asp:TextBox ID="txtDebutFonction" Placeholder="Date d'entree en fonction" runat="server" CssClass="form-control" TextMode="DateTime" ValidateRequestMode="Enabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDebutFonction" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>  
                                 <div class="col-lg-4">
                            <asp:TextBox ID="txtFinFonction" Placeholder="Date fin de fonction" runat="server" CssClass="form-control" TextMode="DateTime" ValidateRequestMode="Enabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFinFonction" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div> 
                    </div>
                    </div>
                     </div>

                        <%-- DIFFERENT DEGREE --%>
                   <br />
               
                <br />
                <br />
                <br />
                 <div class="jumbotron text-center">
        
            <h2 class="display-1" >PACOURS PROFESSIONNEL</h2></div>
                 <div class="row">
                <div class="col-lg-12">
                <div class="col-lg-12">
                   
                     <div class="col-lg-4">
                         <asp:DropDownList ID="DropDetention" runat="server" ValidateRequestMode="Enabled"  Placeholder="Lien de parente" TabIndex="1" >
                    <asp:ListItem Selected="True">Certificat</asp:ListItem>
                    <asp:ListItem>Licence</asp:ListItem>
                    <asp:ListItem>Maitrise</asp:ListItem>
                             <asp:ListItem>Doctorat</asp:ListItem>
                </asp:DropDownList>
                         </div>
            
                    
                    <div class="col-lg-4">
                            <asp:TextBox ID="txtDiscipline" Placeholder="Discipline" runat="server" CssClass="form-control" TextMode="DateTime" ValidateRequestMode="Enabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtDiscipline" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                                 <div class="col-lg-4">
                            <asp:TextBox ID="txtDate" Placeholder="Annee de l'obtention" runat="server" CssClass="form-control" TextMode="DateTime" ValidateRequestMode="Enabled"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDate" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div> 
                    </div>
                    </div>
                     </div>


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
