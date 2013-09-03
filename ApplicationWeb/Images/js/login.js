function FetchLoginData() {
    document.getElementById("divProgress").style.visibility = "visible";
    var txtLoginName = $("#txtLoginName").val();
    var dataString = 'txtLoginName=' + txtLoginName;
    $.ajax({
        type: "POST",
        //url: "../../Async/bin/BackAsyncData.aspx",
        url: "Images/frmAsyncLogin.aspx",
        data: dataString,
        success: function(returnValue) {
            var a1 = new Array();
            a1 = returnValue.split(",");
            if (a1[2] > 0) {
                document.getElementById("dvloginName").innerHTML = a1[0] + ", " + a1[1];
                document.getElementById("dvloginName").style.color = "Green";

            }
            else {
                document.getElementById("dvloginName").innerHTML = "Record Does Not Exist !"
                document.getElementById("dvloginName").style.color = "Red";
            }
            document.getElementById("divProgress").style.visibility = "hidden";
        }
    });
   
    return false;
}
