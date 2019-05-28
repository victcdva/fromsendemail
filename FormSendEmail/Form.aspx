<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="FormSendEmail.Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="width: 690px; float: left;">               
        <div style="width: 400px; float: right;">           
            <div id="forma_contacto" style="background-color: #eff1f7; padding: 10px; border: solid 1px #8691b2;">
                <form id="forma_cotizacion" runat="server" action="#" clientidmode="Static">
                    <input type="hidden" name="oid" value="00Di0000000HPRa" />
                    <input type="hidden" name="retURL" value="http://www.sporturfintl.com/Sitio/gracias.aspx?from=sf" />
                    <table style="width: 99%; margin: auto;">
                        <tr>
                            <td>
                                <!--<label for="first_name">
                                    Nombre</label><br />-->
                                <input id="first_name" value="Name" maxlength="40" name="first_name" style="width: 90%;" type="text"
                                    class="validate[required]" data-validation-placeholder="Nombre" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <!--<label for="last_name">
                                    Apellido</label><br />-->
                                <input id="last_name" value="Last Name" maxlength="80" name="last_name" style="width: 90%;" type="text"
                                    class="validate[required]" data-validation-placeholder="Apellido" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <!--<label for="phone">
                                    Telefono</label><br />-->
                                <input id="phone" value="Phone" maxlength="40" name="phone" style="width: 90%;" type="text" class="validate[required]"  data-validation-placeholder="Telefono" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <!--<label for="email">
                                    Email</label><br />-->
                                <input id="email" value="Email" maxlength="80" name="email" style="width: 90%;" type="text" class="validate[required,custom[email]]" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <!--<label for="city">
                                    Ciudad</label><br />-->
                                <input id="city" value="City" maxlength="40" name="city" style="width: 90%;" type="text" class="validate[required]" data-validation-placeholder="Ciudad" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <!--<label for="country">
                                    Pais</label><br />-->
                                <input id="country" value="Country" maxlength="40" name="country" style="width: 90%;" type="text"
                                    class="validate[required]" data-validation-placeholder="Pais" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="doNotCall">
                                    I wish to receive information?</label>&nbsp;
                                <input id="doNotCall" name="doNotCall" type="checkbox" value="1" checked />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="industry">
                                    Industry</label><br />
                                <select id="industry" name="industry" style="width: 100%;" class="validate[required]">
                                 <option value="">Select proyect</option>
                                    <option value="Deportivo">Deportivo</option>
                                    <option value="Áreas Verdes">Áreas Verdes</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label for="lead_source">
                                    How did you hear about us?
                                </label>
                                <br />
                                <select id="lead_source" name="lead_source" style="width: 100%;" class="validate[required]" >
                                  <option value="">Select a medium</option>
                                    <option value="Búsqueda en Google">Búsqueda en Google</option>
                                    <option value="Por medio de Linked In">Por medio de Linked In</option>
                                    <option value="Por Facebook">Por Facebook</option>
                                    <option value="Por Twitter">Por Twitter</option>
                                    <option value="Por Instragram">Por Instragram</option>
                                      <option value="Por Expo CIHAC">Por Expo CIHAC</option> 
                                    <option value="Por Expo AgroBaja">Por Expo AgroBaja</option>
                                    <option value="Recomendación">Recomendación</option>
                                    <option value="Otro">Otro</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                             <td>
                                <label for="description">
                                    Description</label><br />
                                <textarea id="description" name="description" rows="2" cols="30" style="width: 100%;"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td>                             
                                <asp:Button ID="sendRequest" runat="server" Text="Submit" OnClick="SendRequest_Click"/>
                            </td>
                        </tr>
                    </table>
                    </form>
            </div>              
        </div>
        <div style="clear: both">
        </div>
    </div>
</body>
</html>
