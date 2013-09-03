<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" 
CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="grid_10" style="width: 75%; float: left; margin-left: 2%;">
            <div class="box round first grid">
                <h2>
                    All Matters</h2>
                <div style="">
                    <div id="add-new">
                        <table id="add-new-table">
                            <tr>
                                <td>
                                    <a class='inline' href="#inline_content">Add Matter</a>
                                </td>
                                <td>
                                    <a href="#">Add Stage</a>
                                </td>
                                <td>
                                    <a href="#">Add Hearing</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="block">
                        <style>
                            .gradeA.odd
                            {
                                background-color: #F3F3F3;
                            }
                        </style>
                        <table id="example" class="data display datatable">
                            <thead>
                                <tr>
                                    <th class="sorting_asc" rowspan="1" colspan="1" style="width: 226px;">
                                        Matter Name
                                    </th>
                                    <th class="sorting" rowspan="1" colspan="1" style="width: 280px;">
                                        Matter Type
                                    </th>
                                    <th class="sorting" rowspan="1" colspan="1" style="width: 263px;">
                                        Client
                                    </th>
                                    <th class="sorting" rowspan="1" colspan="1" style="width: 189px;">
                                        Date
                                    </th>
                                    <th class="sorting" rowspan="1" colspan="1" style="width: 135px;">
                                        Action
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="gradeA odd">
                                    <td class=" sorting_1">
                                        Loram ipsum
                                    </td>
                                    <td>
                                        legal case
                                    </td>
                                    <td>
                                        c-1101
                                    </td>
                                    <td class="center">
                                        11-2-2013
                                    </td>
                                    <td class="center">
                                        <input type="image" title="Edit" src="images/icn_edit.png">
                                        <input type="image" title="Trash" src="images/icn_trash.png">
                                    </td>
                                </tr>
                                <tr class="gradeA even">
                                    <td class=" sorting_1">
                                        Loram ipsum
                                    </td>
                                    <td>
                                        legal case
                                    </td>
                                    <td>
                                        c-1104
                                    </td>
                                    <td class="center">
                                        12-2-2013
                                    </td>
                                    <td class="center">
                                        <input type="image" title="Edit" src="images/icn_edit.png">
                                        <input type="image" title="Trash" src="images/icn_trash.png">
                                    </td>
                                </tr>
                                <tr class="gradeA odd">
                                    <td class=" sorting_1">
                                        Loram ipsum
                                    </td>
                                    <td>
                                        legal case
                                    </td>
                                    <td>
                                        c-1151
                                    </td>
                                    <td class="center">
                                        13-2-2013
                                    </td>
                                    <td class="center">
                                        <input type="image" title="Edit" src="images/icn_edit.png">
                                        <input type="image" title="Trash" src="images/icn_trash.png">
                                    </td>
                                </tr>
                                <tr class="gradeA even">
                                    <td class=" sorting_1">
                                        Loram ipsum
                                    </td>
                                    <td>
                                        legal case
                                    </td>
                                    <td>
                                        c-1141
                                    </td>
                                    <td class="center">
                                        14-2-2013
                                    </td>
                                    <td class="center">
                                        <input type="image" title="Edit" src="images/icn_edit.png">
                                        <input type="image" title="Trash" src="images/icn_trash.png">
                                    </td>
                                </tr>
                                <tr class="gradeA odd">
                                    <td class=" sorting_1">
                                        Loram ipsum
                                    </td>
                                    <td>
                                        legal case
                                    </td>
                                    <td>
                                        c-1301
                                    </td>
                                    <td class="center">
                                        15-2-2013
                                    </td>
                                    <td class="center">
                                        <input type="image" title="Edit" src="images/icn_edit.png">
                                        <input type="image" title="Trash" src="images/icn_trash.png">
                                    </td>
                                </tr>
                                <tr class="gradeA even">
                                    <td class=" sorting_1">
                                        Loram ipsum
                                    </td>
                                    <td>
                                        legal case
                                    </td>
                                    <td>
                                        c-7501
                                    </td>
                                    <td class="center">
                                        16-2-2013
                                    </td>
                                    <td class="center">
                                        <input type="image" title="Edit" src="images/icn_edit.png">
                                        <input type="image" title="Trash" src="images/icn_trash.png">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div style='display: none'>
                <div class="box round first fullpage" id='inline_content'>
                    <h2>
                        Add New Matter</h2>
                    <div class="block add-matter">
                        <form>
                        <table class="form">
                            <tbody>
                                <tr>
                                    <td class="col1">
                                        <label>
                                            Matter Name</label>
                                    </td>
                                    <td class="col2">
                                        <input type="text" id="grumble">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Type of Matter</label>
                                    </td>
                                    <td>
                                        <select name="select" id="select">
                                            <option value="1">Value 1</option>
                                            <option value="2">Value 2</option>
                                            <option value="3">Value 3</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">
                                        <label>
                                            Matter Description</label>
                                    </td>
                                    <td class="col2">
                                        <input type="textarea" id="matter-des">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Matter Date</label>
                                    </td>
                                    <td>
                                        <input type="text" id="date-picker" class="hasDatepicker"><img class="ui-datepicker-trigger"
                                            src="img/calendar.gif" alt="..." title="...">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Attach File</label>
                                    </td>
                                    <td>
                                        <input type="file">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <button class="btn btn-large">
                                            Submit</button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
</asp:Content>

